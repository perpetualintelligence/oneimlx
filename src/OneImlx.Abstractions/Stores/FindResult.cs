/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Abstractions.Stores
{
    /// <summary>
    /// Represents the result of a find operation.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <remarks>Initializes a new instance of the <see cref="FindResult{TEntity}"/> class.</remarks>
    /// <param name="found">Whether the entity was found or not.</param>
    /// <param name="entity">The found entity, or <c>null</c> if not found.</param>
    public sealed class FindResult<TEntity>(bool found, TEntity? entity = default) where TEntity : IId
    {
        /// <summary>
        /// The entity that was found. <c>null</c> if not found.
        /// </summary>
        public TEntity? Entity { get; } = entity;

        /// <summary>
        /// Indicates whether the entity was found.
        /// </summary>
        public bool Found { get; } = found;
    }
}
