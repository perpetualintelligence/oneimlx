/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using OneImlx.Iam.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Iam
{
    public class MutableInMemoryStoreTests
    {
        [Fact]
        public async Task ClearAsync_ShouldClearAllEntities()
        {
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object };
            var store = new MutableInMemoryStore<IId>(entities);

            await store.ClearAsync();

            (await store.AllAsync()).Should().BeEmpty();
        }

        [Fact]
        public async Task Concurrent_Add_Remove_Clear_Operations_ShouldNotCauseExceptions()
        {
            // Arrange
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object };
            var store = new MutableInMemoryStore<IId>(entities);

            // Concurrent tasks for Add, Remove, and Clear
            var tasks = new List<Task>
            {
                store.TryAddAsync(entity2Mock.Object),
                store.TryAddAsync(entity3Mock.Object),
                store.TryRemoveAsync("1"),
                store.ClearAsync()
            };

            // Act & Assert
            await Task.WhenAll(tasks);

            // No exceptions should be thrown during concurrent operations
        }

        [Fact]
        public async Task Concurrent_High_Operations_ShouldNotCauseExceptions()
        {
            // Arrange
            const int entityCount = 1000;
            var entities = new List<IId>();

            for (int i = 1; i <= entityCount; i++)
            {
                var entityMock = new Mock<IId>();
                entityMock.Setup(e => e.Id).Returns(i.ToString());
                entities.Add(entityMock.Object);
            }

            var store = new MutableInMemoryStore<IId>(entities);

            // Concurrent tasks for Add, Remove, Clear, and TryFind operations
            var tasks = new List<Task>
            {
                // Add 100 more entities
                Task.Run(async () =>
                {
                    for (int i = entityCount + 1; i <= entityCount + 100; i++)
                    {
                        var entityMock = new Mock<IId>();
                        entityMock.Setup(e => e.Id).Returns(i.ToString());
                        await store.TryAddAsync(entityMock.Object);
                    }
                }),

                // Remove 50 entities
                Task.Run(async () =>
                {
                    for (int i = 1; i <= 50; i++)
                    {
                        await store.TryRemoveAsync(i.ToString());
                    }
                }),

                // Try to find entity "50"
                Task.Run(async () =>
                {
                    await store.TryFindAsync("50");
                })
            };

            // Act & Assert
            await Task.WhenAll(tasks);

            // Verify that the remaining entities are still present
            for (int i = 51; i <= entityCount + 100; i++)
            {
                var result = await store.TryFindAsync(i.ToString());
                result.Found.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Concurrent_Operations_ShouldNotCauseExceptions()
        {
            // Arrange
            const int entityCount = 100;
            var entities = new List<IId>();

            for (int i = 1; i <= entityCount; i++)
            {
                var entityMock = new Mock<IId>();
                entityMock.Setup(e => e.Id).Returns(i.ToString());
                entities.Add(entityMock.Object);
            }

            var store = new MutableInMemoryStore<IId>(entities);

            var entityAdd = new Mock<IId>();
            entityAdd.Setup(e => e.Id).Returns("5000");

            // Concurrent tasks for Add, Remove, Clear, and TryFind operations
            var tasks = new List<Task>
            {
                store.TryAddAsync(entityAdd.Object),
                store.TryRemoveAsync("1"),
                store.ClearAsync(),
                store.TryFindAsync("50")
            };

            // Act & Assert
            await Task.WhenAll(tasks);

            // No exceptions should be thrown during concurrent operations
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenEntitiesIsNull()
        {
            Action act = () => new MutableInMemoryStore<IId>(null!);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task TryAddAsync_ShouldAddEntity_WhenEntityDoesNotExist()
        {
            var entityMock = new Mock<IId>();
            entityMock.Setup(e => e.Id).Returns("1");

            var store = new MutableInMemoryStore<IId>(Enumerable.Empty<IId>());
            bool added = await store.TryAddAsync(entityMock.Object);

            added.Should().BeTrue();

            FindResult<IId> foundResult = await store.TryFindAsync(entityMock.Object.Id);
            foundResult.Found.Should().BeTrue();
            foundResult.Entity.Should().NotBeNull();
            foundResult.Entity!.Id.Should().Be("1");
        }

        [Fact]
        public async Task TryAddAsync_ShouldNotAddEntity_WhenEntityExists()
        {
            var entityMock = new Mock<IId>();
            entityMock.Setup(e => e.Id).Returns("1");

            var store = new MutableInMemoryStore<IId>(new List<IId> { entityMock.Object });
            bool added = await store.TryAddAsync(entityMock.Object);

            added.Should().BeFalse();
        }

        [Fact]
        public async Task TryRemoveAsync_ShouldNotRemoveEntity_WhenEntityDoesNotExists()
        {
            var store = new MutableInMemoryStore<IId>(Enumerable.Empty<IId>());
            RemoveResult<IId> removedResult = await store.TryRemoveAsync("unknown-id");

            removedResult.Removed.Should().BeFalse();
            removedResult.Entity.Should().BeNull();
        }

        [Fact]
        public async Task TryRemoveAsync_ShouldRemoveEntity_WhenEntityExists()
        {
            var entityMock = new Mock<IId>();
            entityMock.Setup(e => e.Id).Returns("1");

            var store = new MutableInMemoryStore<IId>(new List<IId> { entityMock.Object });
            (await store.TryFindAsync(entityMock.Object.Id)).Found.Should().BeTrue();

            RemoveResult<IId> removedResult = await store.TryRemoveAsync(entityMock.Object.Id);

            removedResult.Removed.Should().BeTrue();
            removedResult.Entity.Should().NotBeNull();
            removedResult.Entity!.Id.Should().Be("1");

            (await store.TryFindAsync(entityMock.Object.Id)).Found.Should().BeFalse();
        }
    }
}