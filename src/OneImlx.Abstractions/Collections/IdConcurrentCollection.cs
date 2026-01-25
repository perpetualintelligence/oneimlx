//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System.Collections.Generic;

namespace OneImlx.Abstractions.Collections
{
    /// <summary>
    /// A concurrent collection where the key is derived from the <see cref="IId.Id"/> property of the items.
    /// </summary>
    /// <typeparam name="TType">The type of the items in the collection.</typeparam>
    public class IdConcurrentCollection<TType> : ConcurrentCollectionBase<string, TType>
        where TType : IId
    {
        /// <summary>
        /// Initializes a new instance with an optional maximum number of items.
        /// </summary>
        /// <param name="maxItems">The maximum number of items allowed; null means unlimited.</param>
        /// <param name="comparer">The key comparer.</param>
        public IdConcurrentCollection(int? maxItems = null, IEqualityComparer<string>? comparer = null)
            : base(maxItems, comparer)
        {
        }

        /// <summary>
        /// Adds an item to the collection using its <see cref="IId.Id"/> value as the key.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added successfully; otherwise, false.</returns>
        public bool TryAdd(TType item) => TryAddProtected(item.Id, item);
    }
}