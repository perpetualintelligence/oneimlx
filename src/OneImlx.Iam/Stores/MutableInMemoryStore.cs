/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneImlx.Iam.Stores
{
    /// <summary>
    /// Represents an in-memory mutable store for entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities stored in the store.</typeparam>
    /// <remarks>
    /// <para>Performance Note:</para>
    /// <para>
    /// For optimal performance, it is recommended that entity <see cref="IId.Id"/> is kept as short as possible (e.g.,
    /// 2 or 3 characters) because the store relies on these IDs for quick and efficient lookups. In many cases,
    /// permissions and roles in IAM systems can have finite and predefined IDs, and optimizing them for efficient
    /// access control is a common practice.
    /// </para>
    /// <para>Concurrency Note:</para>
    /// <para>
    /// The store is designed to handle concurrent read and write operations efficiently using a
    /// <see cref="ConcurrentDictionary{TKey, TValue}"/>. However, it's essential to be aware of potential race
    /// conditions in specific compound operations. Care should be taken when combining multiple operations to ensure
    /// atomicity and consistency.
    /// </para>
    /// </remarks>
    public class MutableInMemoryStore<TEntity> : IMutableStore<TEntity> where TEntity : IId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MutableInMemoryStore{TEntity}"/> class with the provided entities.
        /// </summary>
        /// <param name="entities">The initial entities for the store.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="entities"/> is null.</exception>
        public MutableInMemoryStore(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _entities = new ConcurrentDictionary<string, TEntity>(entities.ToDictionary(entity => entity.Id));
        }

        /// <inheritdoc/>
        public Task<IEnumerable<TEntity>> AllAsync()
        {
            return Task.FromResult(_entities.Values.AsEnumerable());
        }

        /// <inheritdoc/>
        public Task ClearAsync()
        {
            _entities.Clear();
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public Task<bool> TryAddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Task.FromResult(_entities.TryAdd(entity.Id, entity));
        }

        /// <inheritdoc/>
        public Task<FindResult<TEntity>> TryFindAsync(string id)
        {
            if (_entities.TryGetValue(id, out TEntity entity))
            {
                return Task.FromResult(new FindResult<TEntity>(true, entity));
            }

            return Task.FromResult(new FindResult<TEntity>(false, default));
        }

        /// <inheritdoc/>
        public Task<RemoveResult<TEntity>> TryRemoveAsync(string id)
        {
            bool removed = _entities.TryRemove(id, out TEntity? entity);
            return Task.FromResult(new RemoveResult<TEntity>(removed, entity));
        }

        private readonly ConcurrentDictionary<string, TEntity> _entities;
    }
}
