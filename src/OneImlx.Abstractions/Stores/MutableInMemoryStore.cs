//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneImlx.Abstractions.Stores
{
    /// <summary>
    /// In-memory dictionary-based <see cref="IMutableStore{TEntity}"/> of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to store.</typeparam>
    /// <remarks>
    /// For optimal performance, <typeparamref name="TEntity"/> should implement equality based on the <see cref="IId.Id"/> property to optimize dictionary lookups.
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

            _entities = new ConcurrentDictionary<string, TEntity>(entities.Select(e => new KeyValuePair<string, TEntity>(e.Id, e)));
        }

        /// <inheritdoc/>
        public Task<IEnumerable<TEntity>> AllAsync() => Task.FromResult(_entities.Values.AsEnumerable());

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