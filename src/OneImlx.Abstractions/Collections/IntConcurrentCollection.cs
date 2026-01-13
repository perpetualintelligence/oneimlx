/*
    Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Abstractions.Collections
{
    /// <summary>
    /// An indexed concurrent collection that can optionally limit the maximum items in the collection.
    /// </summary>
    /// <typeparam name="TType">The type of the items in the collection.</typeparam>
    public sealed class IntConcurrentCollection<TType> : ConcurrentCollectionBase<int, TType>
    {
        /// <summary>
        /// Initializes a new instance with a specified maximum number of items.
        /// </summary>
        /// <param name="maxItems">The maximum number of items allowed; null means unlimited.</param>
        public IntConcurrentCollection(int? maxItems = null) : base(maxItems)
        {
        }

        /// <summary>
        /// Adds an item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The index at which to add the item.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        public bool TryAdd(int index, TType item) => TryAddProtected(index, item);
    }
}