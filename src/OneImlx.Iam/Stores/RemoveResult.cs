﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Iam.Stores
{
    /// <summary>
    /// Represents the result of a remove operation.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public sealed class RemoveResult<TEntity> where TEntity : IId
    {
        /// <summary>
        /// Indicates whether the entity was removed.
        /// </summary>
        public bool Removed { get; }

        /// <summary>
        /// The entity that was found. <c>null</c> if not found.
        /// </summary>
        public TEntity? Entity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindResult{TEntity}"/> class.
        /// </summary>
        /// <param name="removed">Whether the entity was removed or not.</param>
        /// <param name="entity">The found entity, or <c>null</c> if not found.</param>
        public RemoveResult(bool removed, TEntity? entity = default)
        {
            Removed = removed;
            Entity = entity;
        }
    }
}