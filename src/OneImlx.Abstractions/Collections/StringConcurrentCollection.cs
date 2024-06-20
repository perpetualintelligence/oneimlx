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
    public class StringConcurrentCollection<TType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntConcurrentCollection{TType}"/> class with a specified
        /// maximum number of items.
        /// </summary>
        /// <param name="maxItems">
        /// The maximum number of items that can be stored in the collection. If null, there is no limit.
        /// </param>
        public StringConcurrentCollection(int? maxItems)
        {
            MaxItems = maxItems;
            _internalDictionary = new ConcurrentDictionary<string, TType>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringConcurrentCollection{TType}"/> class.
        /// </summary>
        public StringConcurrentCollection()
        {
            _internalDictionary = new ConcurrentDictionary<string, TType>();
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
        /// Determines whether the collection contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the collection.</param>
        /// <returns>True if the collection contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(string key) => _internalDictionary.ContainsKey(key);

        /// <summary>
        /// Gets an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<KeyValuePair<string, TType>> GetEnumerator() => _internalDictionary.GetEnumerator();

        /// <summary>
        /// Adds an item to the collection with the specified key. If the collection has a maximum item limit, it
        /// ensures the limit is not exceeded.
        /// </summary>
        /// <param name="key">The key at which to add the item.</param>
        /// <param name="item">The item to add to the collection.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if adding the item would exceed the maximum item limit.
        /// </exception>
        public bool TryAdd(string key, TType item)
        {
            lock (_lock)
            {
                if (MaxItems.HasValue && _internalDictionary.Count >= MaxItems.Value)
                {
                    throw new OneImlxException("invalid_request", "The collection has reached its maximum capacity.");
                }

                return _internalDictionary.TryAdd(key, item);
            }
        }

        /// <summary>
        /// Gets the item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <param name="item">
        /// When this method returns, contains the object from the collection with the specified key, if the key is found.
        /// </param>
        /// <returns>True if the item was found; otherwise, false.</returns>
        public bool TryGetValue(string key, out TType item) => _internalDictionary.TryGetValue(key, out item);

        /// <summary>
        /// Removes the item with the specified key from the collection.
        /// </summary>
        /// <param name="key">The key of the item to remove.</param>
        /// <param name="item">When this method returns, contains the removed item, if the removal was successful.</param>
        /// <returns>True if the item was successfully removed; otherwise, false.</returns>
        public bool TryRemove(string key, out TType item) => _internalDictionary.TryRemove(key, out item);

        private readonly ConcurrentDictionary<string, TType> _internalDictionary;
        private readonly object _lock = new();
    }
}
