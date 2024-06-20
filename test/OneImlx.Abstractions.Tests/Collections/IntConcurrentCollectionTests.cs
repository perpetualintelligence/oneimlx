/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using OneImlx.Abstractions;
using OneImlx.Abstractions.Collections;
using OneImlx.Test.FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace OneImlx.Tests.Collections
{
    public class IndexedConcurrentCollectionTests
    {
        [Fact]
        public void AddDuplicateIndex_Fails()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");
            bool result = collection.TryAdd(1, "Test2");

            result.Should().BeFalse();
            collection.TryGetValue(1, out var value).Should().BeTrue();
            value.Should().Be("Test1");
        }

        [Fact]
        public void AddItemExceedingMaxItems_DoesNotAddItem()
        {
            var collection = new IntConcurrentCollection<string>(1);
            collection.TryAdd(1, "Test1");

            bool result = false;
            Action act = () => result = collection.TryAdd(2, "Test2");

            act.Should().Throw<OneImlxException>()
               .WithErrorCode("invalid_request")
               .WithErrorDescription("The collection has reached its maximum capacity.");

            result.Should().BeFalse();
            collection.ContainsKey(2).Should().BeFalse();
        }

        [Fact]
        public void AddItemExceedingMaxItems_ThrowsException()
        {
            var collection = new IntConcurrentCollection<string>(1);
            collection.TryAdd(1, "Test1");

            Action act = () => collection.TryAdd(2, "Test2");

            act.Should().Throw<OneImlxException>()
               .WithErrorCode("invalid_request")
               .WithErrorDescription("The collection has reached its maximum capacity.");
        }

        [Fact]
        public void AddItemWithMaxItems_Succeeds()
        {
            var collection = new IntConcurrentCollection<string>(2);
            bool result1 = collection.TryAdd(1, "Test1");
            bool result2 = collection.TryAdd(2, "Test2");

            result1.Should().BeTrue();
            result2.Should().BeTrue();
            collection.TryGetValue(1, out var value1).Should().BeTrue();
            collection.TryGetValue(2, out var value2).Should().BeTrue();
            value1.Should().Be("Test1");
            value2.Should().Be("Test2");
        }

        [Fact]
        public void AddItemWithoutMaxItems_Succeeds()
        {
            var collection = new IntConcurrentCollection<string>();
            bool result = collection.TryAdd(1, "Test");

            result.Should().BeTrue();
            collection.TryGetValue(1, out var value).Should().BeTrue();
            value.Should().Be("Test");
        }

        [Fact]
        public void Clear_RemovesAllItems()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");
            collection.TryAdd(2, "Test2");

            collection.Clear();

            collection.Count.Should().Be(0);
            collection.ContainsKey(1).Should().BeFalse();
            collection.ContainsKey(2).Should().BeFalse();
        }

        [Fact]
        public void ContainsKey_ReturnsFalseForMissingKey()
        {
            var collection = new IntConcurrentCollection<string>();

            collection.ContainsKey(1).Should().BeFalse();
        }

        [Fact]
        public void ContainsKey_ReturnsTrueForExistingKey()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");

            collection.ContainsKey(1).Should().BeTrue();
        }

        [Fact]
        public void Count_ReturnsCorrectNumberOfItems()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");
            collection.TryAdd(2, "Test2");

            collection.Count.Should().Be(2);
        }

        [Fact]
        public void GetEnumerator_IteratesAllItems()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");
            collection.TryAdd(2, "Test2");

            var enumerator = collection.GetEnumerator();
            var items = new List<KeyValuePair<int, string>>();

            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            items.Should().Contain(new KeyValuePair<int, string>(1, "Test1"));
            items.Should().Contain(new KeyValuePair<int, string>(2, "Test2"));
        }

        [Fact]
        public void GetItem_ReturnsFalseForMissingItem()
        {
            var collection = new IntConcurrentCollection<string>();

            collection.TryGetValue(1, out var value).Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void GetItem_Succeeds()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");

            collection.TryGetValue(1, out var value).Should().BeTrue();
            value.Should().Be("Test1");
        }

        [Fact]
        public void RemoveItem_ReturnsFalseForMissingKey()
        {
            var collection = new IntConcurrentCollection<string>();

            bool result = collection.TryRemove(1, out var value);

            result.Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void RemoveItem_Succeeds()
        {
            var collection = new IntConcurrentCollection<string>();
            collection.TryAdd(1, "Test1");

            bool result = collection.TryRemove(1, out var value);

            result.Should().BeTrue();
            value.Should().Be("Test1");
            collection.ContainsKey(1).Should().BeFalse();
        }
    }
}
