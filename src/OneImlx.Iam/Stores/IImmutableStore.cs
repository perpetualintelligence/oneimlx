/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneImlx.Iam.Stores
{
    /// <summary>
    /// Represents an immutable store for <c>IAM</c> entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity this store manages.</typeparam>
    public interface IImmutableStore<TEntity> where TEntity : IId
    {
        /// <summary>
        /// Asynchronously retrieves all entities from the store.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        Task<IEnumerable<TEntity>> AllAsync();

        /// <summary>
        /// Asynchronously attempts to find an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to find.</param>
        /// <returns>A result containing information about the search outcome and the entity itself if found.</returns>
        Task<FindResult<TEntity>> TryFindAsync(string id);
    }
}
