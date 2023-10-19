/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpetualIntelligence.OneImlx.Iam.Stores
{
    /// <summary>
    /// Provides an in-memory <see cref="IImmutableStore{TEntity}"/> for <c>IAM</c> entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to store.</typeparam>
    /// <remarks>
    /// To improve performance, especially for lookup operations, it's recommended for <typeparamref name="TEntity"/>
    /// to implement equality based solely on the <see cref="IId.Id"/> property. In many scenarios, two entities with the same <see cref="IId.Id"/>
    /// are considered equal, even if other properties differ. By defining equality in this manner, dictionary
    /// lookups, which are based on the entity's hash code, can be optimized.
    /// </remarks>
    public class ImmutableInMemoryStore<TEntity> : IImmutableStore<TEntity> where TEntity : IId
    {
        private readonly IReadOnlyDictionary<string, TEntity> _entities;

        /// <summary>
        /// Initializes a new instance with the specified entities.
        /// </summary>
        /// <param name="entities">The in-memory entities.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ImmutableInMemoryStore(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _entities = entities.ToDictionary(entity => entity.Id);
        }

        /// <summary>
        /// Asynchronously retrieves all entities from the store.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        /// <remarks>
        /// Due to the underlying dictionary data structure used for optimal look-up performance,
        /// the order of entities returned by this method is not guaranteed to match the order
        /// in which entities were added or any specific order. Consumers should not rely on
        /// the order of entities returned.
        /// </remarks>
        public Task<IEnumerable<TEntity>> AllAsync()
        {
            return Task.FromResult(_entities.Values);
        }

        /// <summary>
        /// Asynchronously attempts to find an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to find.</param>
        /// <returns>A result containing information about the search outcome and the entity itself if found.</returns>
        public Task<FindResult<TEntity>> TryFindAsync(string id)
        {
            if (_entities.TryGetValue(id, out TEntity entity))
            {
                return Task.FromResult(new FindResult<TEntity>(true, entity));
            }

            return Task.FromResult(new FindResult<TEntity>(false, default));
        }
    }
}