/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OneImlx.Abstractions.Collections
{
    /// <summary>
    /// An indexed concurrent collection that can optionally limit the maximum items in the collection.
    /// </summary>
    /// <typeparam name="TType">The type of the items in the collection.</typeparam>
    public class IntConcurrentCollection<TType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntConcurrentCollection{TType}"/> class.
        /// </summary>
        public IntConcurrentCollection()
        {
            _internalDictionary = new ConcurrentDictionary<int, TType>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntConcurrentCollection{TType}"/> class with a specified
        /// maximum number of items.
        /// </summary>
        /// <param name="maxItems">
        /// The maximum number of items that can be stored in the collection. If null, there is no limit.
        /// </param>
        public IntConcurrentCollection(int? maxItems)
        {
            MaxItems = maxItems;
            _internalDictionary = new ConcurrentDictionary<int, TType>();
        }

        /// <summary>
        /// Gets the number of items contained in the collection.
        /// </summary>
        public int Count => _internalDictionary.Count;

        /// <summary>
        /// Gets the maximum number of items that can be stored in the collection.
        /// </summary>
        public int? MaxItems { get; }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear() => _internalDictionary.Clear();

        /// <summary>
        /// Determines whether the collection contains the specified index.
        /// </summary>
        /// <param name="index">The index to locate in the collection.</param>
        /// <returns>True if the collection contains an element with the specified index; otherwise, false.</returns>
        public bool ContainsKey(int index) => _internalDictionary.ContainsKey(index);

        /// <summary>
        /// Gets an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<KeyValuePair<int, TType>> GetEnumerator() => _internalDictionary.GetEnumerator();

        /// <summary>
        /// Adds an item to the collection with the specified index. If the collection has a maximum item limit, it
        /// ensures the limit is not exceeded.
        /// </summary>
        /// <param name="index">The index at which to add the item.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if adding the item would exceed the maximum item limit.
        /// </exception>
        public bool TryAdd(int index, TType item)
        {
            lock (_lock)
            {
                if (MaxItems.HasValue && _internalDictionary.Count >= MaxItems.Value)
                {
                    throw new OneImlxException("invalid_request", "The collection has reached its maximum capacity.");
                }

                return _internalDictionary.TryAdd(index, item);
            }
        }

        /// <summary>
        /// Gets the item associated with the specified index.
        /// </summary>
        /// <param name="index">The index of the item to get.</param>
        /// <param name="item">
        /// When this method returns, contains the object from the collection with the specified key, if the key is found.
        /// </param>
        /// <returns>True if the item was found; otherwise, false.</returns>
        public bool TryGetValue(int index, out TType item) => _internalDictionary.TryGetValue(index, out item);

        /// <summary>
        /// Removes the item with the specified index from the collection.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        /// <param name="item">When this method returns, contains the removed item, if the removal was successful.</param>
        /// <returns>True if the item was successfully removed; otherwise, false.</returns>
        public bool TryRemove(int index, out TType item) => _internalDictionary.TryRemove(index, out item);

        private readonly ConcurrentDictionary<int, TType> _internalDictionary;
        private readonly object _lock = new();
    }
}
