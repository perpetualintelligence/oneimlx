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
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Iam
{
    public class ImmutableInMemoryStoreTests
    {
        [Fact]
        public async Task AllAsync_ShouldReturnAllEntities()
        {
            
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            
            var result = await store.AllAsync();

            
            result.Should().BeEquivalentTo(entities, options => options.WithStrictOrdering());
        }

        [Fact]
        public async Task AllAsync_ShouldReturnEmpty_WhenInitializedWithNoEntities()
        {
            
            var store = new ImmutableInMemoryStore<IId>(new List<IId>());

            
            var result = await store.AllAsync();

            
            result.Should().BeEmpty();
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenEntitiesIsNull()
        {
            
            var action = new Action(() => new ImmutableInMemoryStore<IId>(null!));

            
            action.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void Constructor_ShouldThrow_WhenGivenDuplicateEntities()
        {
            
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("1"); // Duplicate ID

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object };

            Action act = () => new ImmutableInMemoryStore<IId>(entities);
            act.Should().Throw<ArgumentException>().WithMessage("An item with the same key has already been added. Key: 1");
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnConsistentResults_AcrossMultipleCalls()
        {
            
            var entityMock = new Mock<IId>();
            entityMock.Setup(e => e.Id).Returns("1");
            var store = new ImmutableInMemoryStore<IId>(new List<IId> { entityMock.Object });

            
            var result1 = await store.TryFindAsync(entityMock.Object.Id);
            var result2 = await store.TryFindAsync(entityMock.Object.Id);

            
            result1.Found.Should().BeTrue();
            result1.Entity.Should().Be(entityMock.Object);
            result2.Found.Should().BeTrue();
            result2.Entity.Should().Be(entityMock.Object);
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnCorrectEntity_WhenEntityDoesNotExists()
        {
            
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            
            var result = await store.TryFindAsync("unknown-id");

            
            result.Found.Should().BeFalse();
            result.Entity.Should().BeNull();
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnCorrectEntity_WhenEntityExists()
        {
            
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            
            var result = await store.TryFindAsync(entity2Mock.Object.Id);

            
            result.Found.Should().BeTrue();
            result.Entity.Should().Be(entity2Mock.Object);
        }
    }
}