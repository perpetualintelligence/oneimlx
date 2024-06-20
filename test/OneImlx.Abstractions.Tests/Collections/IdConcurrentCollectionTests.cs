/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using OneImlx.Abstractions;
using OneImlx.Abstractions.Collections;
using System;
using System.Collections.Generic;
using Xunit;

namespace OneImlx.Tests.Collections
{
    public class IdConcurrentCollectionTests
    {
        [Fact]
        public void AddDuplicateId_Fails()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id1");

            collection.TryAdd(mockItem1.Object);
            bool result = collection.TryAdd(mockItem2.Object);

            result.Should().BeFalse();
            collection.TryGetValue("id1", out var value).Should().BeTrue();
            value.Should().Be(mockItem1.Object);
        }

        [Fact]
        public void AddItemExceedingMaxItems_DoesNotAddItem()
        {
            var collection = new IdConcurrentCollection<IId>(1);
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            collection.TryAdd(mockItem1.Object);

            bool result = false;
            Action act = () => result = collection.TryAdd(mockItem2.Object);

            act.Should().Throw<OneImlxException>()
               .WithMessage("The collection has reached its maximum capacity.");

            result.Should().BeFalse();
            collection.ContainsKey("id2").Should().BeFalse();
        }

        [Fact]
        public void AddItemExceedingMaxItems_ThrowsException()
        {
            var collection = new IdConcurrentCollection<IId>(1);
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            collection.TryAdd(mockItem1.Object);

            Action act = () => collection.TryAdd(mockItem2.Object);

            act.Should().Throw<OneImlxException>()
               .WithMessage("The collection has reached its maximum capacity.");
        }

        [Fact]
        public void AddItemWithMaxItems_Succeeds()
        {
            var collection = new IdConcurrentCollection<IId>(2);
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            bool result1 = collection.TryAdd(mockItem1.Object);
            bool result2 = collection.TryAdd(mockItem2.Object);

            result1.Should().BeTrue();
            result2.Should().BeTrue();
            collection.TryGetValue("id1", out var value1).Should().BeTrue();
            collection.TryGetValue("id2", out var value2).Should().BeTrue();
            value1.Should().Be(mockItem1.Object);
            value2.Should().Be(mockItem2.Object);
        }

        [Fact]
        public void AddItemWithoutMaxItems_Succeeds()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem = new Mock<IId>();
            mockItem.Setup(item => item.Id).Returns("id1");

            bool result = collection.TryAdd(mockItem.Object);

            result.Should().BeTrue();
            collection.TryGetValue("id1", out var value).Should().BeTrue();
            value.Should().Be(mockItem.Object);
        }

        [Fact]
        public void Clear_RemovesAllItems()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            collection.TryAdd(mockItem1.Object);
            collection.TryAdd(mockItem2.Object);

            collection.Clear();

            collection.Count.Should().Be(0);
            collection.ContainsKey("id1").Should().BeFalse();
            collection.ContainsKey("id2").Should().BeFalse();
        }

        [Fact]
        public void ContainsKey_ReturnsFalseForMissingKey()
        {
            var collection = new IdConcurrentCollection<IId>();

            collection.ContainsKey("id1").Should().BeFalse();
        }

        [Fact]
        public void ContainsKey_ReturnsTrueForExistingKey()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem = new Mock<IId>();
            mockItem.Setup(item => item.Id).Returns("id1");

            collection.TryAdd(mockItem.Object);

            collection.ContainsKey("id1").Should().BeTrue();
        }

        [Fact]
        public void Count_ReturnsCorrectNumberOfItems()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            collection.TryAdd(mockItem1.Object);
            collection.TryAdd(mockItem2.Object);

            collection.Count.Should().Be(2);
        }

        [Fact]
        public void GetEnumerator_IteratesAllItems()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem1 = new Mock<IId>();
            mockItem1.Setup(item => item.Id).Returns("id1");
            var mockItem2 = new Mock<IId>();
            mockItem2.Setup(item => item.Id).Returns("id2");

            collection.TryAdd(mockItem1.Object);
            collection.TryAdd(mockItem2.Object);

            var enumerator = collection.GetEnumerator();
            var items = new List<KeyValuePair<string, IId>>();

            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            items.Should().Contain(new KeyValuePair<string, IId>("id1", mockItem1.Object));
            items.Should().Contain(new KeyValuePair<string, IId>("id2", mockItem2.Object));
        }

        [Fact]
        public void GetItem_ReturnsFalseForMissingItem()
        {
            var collection = new IdConcurrentCollection<IId>();

            collection.TryGetValue("id1", out var value).Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void GetItem_Succeeds()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem = new Mock<IId>();
            mockItem.Setup(item => item.Id).Returns("id1");

            collection.TryAdd(mockItem.Object);

            collection.TryGetValue("id1", out var value).Should().BeTrue();
            value.Should().Be(mockItem.Object);
        }

        [Fact]
        public void RemoveItem_ReturnsFalseForMissingKey()
        {
            var collection = new IdConcurrentCollection<IId>();

            bool result = collection.TryRemove("id1", out var value);

            result.Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void RemoveItem_Succeeds()
        {
            var collection = new IdConcurrentCollection<IId>();
            var mockItem = new Mock<IId>();
            mockItem.Setup(item => item.Id).Returns("id1");

            collection.TryAdd(mockItem.Object);

            bool result = collection.TryRemove("id1", out var value);

            result.Should().BeTrue();
            value.Should().Be(mockItem.Object);
            collection.ContainsKey("id1").Should().BeFalse();
        }
    }
}
