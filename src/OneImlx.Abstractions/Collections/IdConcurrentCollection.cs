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
    /// A concurrent collection where the key is derived from the <see cref="IId.Id"/> property of the items.
    /// </summary>
    /// <typeparam name="TType">
    /// The type of the items in the collection, which must implement the <see cref="IId"/> interface.
    /// </typeparam>
    public class IdConcurrentCollection<TType> where TType : IId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdConcurrentCollection{TType}"/> class with a specified maximum
        /// number of items.
        /// </summary>
        /// <param name="maxItems">
        /// The maximum number of items that can be stored in the collection. If null, there is no limit.
        /// </param>
        /// <param name="comparer">The key comparer.</param>
        public IdConcurrentCollection(int? maxItems = null, IEqualityComparer<string>? comparer = null)
        {
            MaxItems = maxItems;
            _internalDictionary = new ConcurrentDictionary<string, TType>(comparer ?? EqualityComparer<string>.Default);
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
        /// <param name="id">The key to locate in the collection.</param>
        /// <returns>True if the collection contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(string id) => _internalDictionary.ContainsKey(id);

        /// <summary>
        /// Gets an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<KeyValuePair<string, TType>> GetEnumerator() => _internalDictionary.GetEnumerator();

        /// <summary>
        /// Adds an item to the collection. If the collection has a maximum item limit, it ensures the limit is not exceeded.
        /// </summary>
        /// <param name="item">The item to add to the collection.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        /// <exception cref="OneImlxException">Thrown if adding the item would exceed the maximum item limit.</exception>
        public bool TryAdd(TType item)
        {
            lock (_lock)
            {
                if (MaxItems.HasValue && _internalDictionary.Count >= MaxItems.Value)
                {
                    throw new OneImlxException("invalid_request", "The collection has reached its maximum capacity.");
                }

                return _internalDictionary.TryAdd(item.Id, item);
            }
        }

        /// <summary>
        /// Gets the item associated with the specified key.
        /// </summary>
        /// <param name="id">The key of the item to get.</param>
        /// <param name="item">
        /// When this method returns, contains the object from the collection with the specified key, if the key is found.
        /// </param>
        /// <returns>True if the item was found; otherwise, false.</returns>
        public bool TryGetValue(string id, out TType item) => _internalDictionary.TryGetValue(id, out item);

        /// <summary>
        /// Removes the item with the specified key from the collection.
        /// </summary>
        /// <param name="id">The key of the item to remove.</param>
        /// <param name="item">When this method returns, contains the removed item, if the removal was successful.</param>
        /// <returns>True if the item was successfully removed; otherwise, false.</returns>
        public bool TryRemove(string id, out TType item) => _internalDictionary.TryRemove(id, out item);

        private readonly ConcurrentDictionary<string, TType> _internalDictionary;
        private readonly object _lock = new();
    }
}
