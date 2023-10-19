﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using PerpetualIntelligence.OneImlx.Iam.Stores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PerpetualIntelligence.OneImlx.Iam
{
    public class ImmutableInMemoryStoreTests
    {
        [Fact]
        public void Constructor_ShouldThrow_WhenEntitiesIsNull()
        {
            // Act
            var action = new Action(() => new ImmutableInMemoryStore<IId>(null!));

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task AllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            // Act
            var result = await store.AllAsync();

            // Assert
            result.Should().BeEquivalentTo(entities, options => options.WithStrictOrdering());
        }

        [Fact]
        public void Constructor_ShouldThrow_WhenGivenDuplicateEntities()
        {
            // Arrange
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("1"); // Duplicate ID

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object };

            // Act & Assert
            Action act = () => new ImmutableInMemoryStore<IId>(entities);
            act.Should().Throw<ArgumentException>().WithMessage("An item with the same key has already been added. Key: 1");
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnCorrectEntity_WhenEntityExists()
        {
            // Arrange
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            // Act
            var result = await store.TryFindAsync(entity2Mock.Object.Id);

            // Assert
            result.Found.Should().BeTrue();
            result.Entity.Should().Be(entity2Mock.Object);
        }

        [Fact]
        public async Task AllAsync_ShouldReturnEmpty_WhenInitializedWithNoEntities()
        {
            // Arrange
            var store = new ImmutableInMemoryStore<IId>(new List<IId>());

            // Act
            var result = await store.AllAsync();

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnConsistentResults_AcrossMultipleCalls()
        {
            // Arrange
            var entityMock = new Mock<IId>();
            entityMock.Setup(e => e.Id).Returns("1");
            var store = new ImmutableInMemoryStore<IId>(new List<IId> { entityMock.Object });

            // Act
            var result1 = await store.TryFindAsync(entityMock.Object.Id);
            var result2 = await store.TryFindAsync(entityMock.Object.Id);

            // Assert
            result1.Found.Should().BeTrue();
            result1.Entity.Should().Be(entityMock.Object);
            result2.Found.Should().BeTrue();
            result2.Entity.Should().Be(entityMock.Object);
        }

        [Fact]
        public async Task TryFindAsync_ShouldReturnCorrectEntity_WhenEntityDoesNotExists()
        {
            // Arrange
            var entity1Mock = new Mock<IId>();
            entity1Mock.Setup(e => e.Id).Returns("1");

            var entity2Mock = new Mock<IId>();
            entity2Mock.Setup(e => e.Id).Returns("2");

            var entity3Mock = new Mock<IId>();
            entity3Mock.Setup(e => e.Id).Returns("3");

            var entities = new List<IId> { entity1Mock.Object, entity2Mock.Object, entity3Mock.Object };
            var store = new ImmutableInMemoryStore<IId>(entities);

            // Act
            var result = await store.TryFindAsync("unknown-id");

            // Assert
            result.Found.Should().BeFalse();
            result.Entity.Should().BeNull();
        }
    }
}