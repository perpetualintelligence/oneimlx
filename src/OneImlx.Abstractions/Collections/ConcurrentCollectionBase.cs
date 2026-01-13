/*
    Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OneImlx.Abstractions.Collections
{
    /// <summary>
    /// Provides a thread-safe, dictionary-backed collection with optional strict capacity enforcement.
    /// </summary>
    /// <typeparam name="TKey">The key type used to index items.</typeparam>
    /// <typeparam name="TValue">The type of items stored in the collection.</typeparam>
    public abstract class ConcurrentCollectionBase<TKey, TValue>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrentCollectionBase{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="maxItems">
        /// The maximum number of items that can be stored in the collection. If null, there is no limit.
        /// </param>
        /// <param name="comparer">The key comparer.</param>
        protected ConcurrentCollectionBase(int? maxItems = null, IEqualityComparer<TKey>? comparer = null)
        {
            MaxItems = maxItems;
            _internalDictionary = new ConcurrentDictionary<TKey, TValue>(comparer ?? EqualityComparer<TKey>.Default);
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
        public bool ContainsKey(TKey key) => _internalDictionary.ContainsKey(key);

        /// <summary>
        /// Gets an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _internalDictionary.GetEnumerator();

        /// <summary>
        /// Attempts to add an item using the specified key. If a maximum capacity is configured,
        /// the method enforces it atomically.
        /// </summary>
        /// <param name="key">The key at which to add the item.</param>
        /// <param name="value">The item to add.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        /// <exception cref="OneImlxException">
        /// Thrown if adding the item would exceed the maximum item limit.
        /// </exception>
        protected bool TryAddProtected(TKey key, TValue value)
        {
            if (MaxItems.HasValue)
            {
                // CRITICAL: The lock is REQUIRED for strict capacity enforcement.
                // Without it, race conditions occur where multiple threads can pass the count check simultaneously,
                // causing the collection to exceed MaxItems. The lock ensures the capacity check and TryAdd operation
                // are atomic. DO NOT remove or refactor this lock without ensuring atomicity is maintained.
                lock (_lock)
                {
                    if (_internalDictionary.Count >= MaxItems.Value)
                    {
                        throw new OneImlxException("invalid_request", "The collection has reached its maximum capacity.");
                    }

                    return _internalDictionary.TryAdd(key, value);
                }
            }

            // No capacity limit - use lock-free approach for maximum performance
            return _internalDictionary.TryAdd(key, value);
        }

        /// <summary>
        /// Gets the item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <param name="value">
        /// When this method returns, contains the object from the collection with the specified key, if found.
        /// </param>
        /// <returns>True if the item was found; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out TValue value) => _internalDictionary.TryGetValue(key, out value);

        /// <summary>
        /// Removes the item with the specified key from the collection.
        /// </summary>
        /// <param name="key">The key of the item to remove.</param>
        /// <param name="value">When this method returns, contains the removed item, if the removal was successful.</param>
        /// <returns>True if the item was successfully removed; otherwise, false.</returns>
        public bool TryRemove(TKey key, out TValue value) => _internalDictionary.TryRemove(key, out value);

        /// <summary>
        /// Internal storage for the collection.
        /// </summary>
        protected readonly ConcurrentDictionary<TKey, TValue> _internalDictionary;

        /// <summary>
        /// Synchronization object for enforcing strict capacity limits.
        /// </summary>
        private readonly object _lock = new();
    }
}