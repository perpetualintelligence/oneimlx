/*
    Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Abstractions.Collections
{
    /// <summary>
    /// A string-keyed concurrent collection that can optionally limit the maximum items in the collection.
    /// </summary>
    /// <typeparam name="TType">The type of the items in the collection.</typeparam>
    public sealed class StringConcurrentCollection<TType> : ConcurrentCollectionBase<string, TType>
    {
        /// <summary>
        /// Initializes a new instance with a specified maximum number of items.
        /// </summary>
        /// <param name="maxItems">The maximum number of items allowed; null means unlimited.</param>
        /// <param name="comparer">The comparer to use for key comparisons.</param>
        public StringConcurrentCollection(int? maxItems = null, IEqualityComparer<string>? comparer = null) : base(maxItems, comparer)
        {
        }

        /// <summary>
        /// Adds an item to the collection with the specified key.
        /// </summary>
        /// <param name="key">The key at which to add the item.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        public bool TryAdd(string key, TType item) => TryAddProtected(key, item);
    }
}