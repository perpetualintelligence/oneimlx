/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace PerpetualIntelligence.OneImlx.Iam.Stores
{
    /// <summary>
    /// Represents an immutable store for <c>IAM</c> that can have entities added, removed, or cleared.
    /// </summary>
    public interface IMutableStore<TEntity> : IImmutableStore<TEntity> where TEntity : IId
    {
        /// <summary>
        /// Tries to add a new entity to the store.
        /// </summary>
        Task<bool> TryAddAsync(TEntity entity);

        /// <summary>
        /// Tries to remove an entity from the store using its ID.
        /// </summary>
        Task<RemoveResult<TEntity>> TryRemoveAsync(string id);

        /// <summary>
        /// Clears all entities from the store.
        /// </summary>
        Task ClearAsync();
    }
}