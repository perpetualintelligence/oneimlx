//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System.Threading.Tasks;

namespace OneImlx.Abstractions.Stores
{
    /// <summary>
    /// An abstraction of a mutable store of entities.
    /// </summary>
    public interface IMutableStore<TEntity> : IImmutableStore<TEntity> where TEntity : IId
    {
        /// <summary>
        /// Clears all entities from the store.
        /// </summary>
        Task ClearAsync();

        /// <summary>
        /// Tries to add a new entity to the store.
        /// </summary>
        Task<bool> TryAddAsync(TEntity entity);

        /// <summary>
        /// Tries to remove an entity from the store using its ID.
        /// </summary>
        Task<RemoveResult<TEntity>> TryRemoveAsync(string id);
    }
}