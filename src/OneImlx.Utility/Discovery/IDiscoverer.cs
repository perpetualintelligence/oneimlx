/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneImlx.Drivers.Discovery
{
    /// <summary>
    /// An abstraction to discover entities.
    /// </summary>
    public interface IDiscoverer<TContext, TEntity> where TEntity : IDiscoverable
    {
        /// <summary>
        /// Discovers entities asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the discovered entities.</returns>
        Task<IEnumerable<TEntity>> DiscoverAsync(TContext context);
    }
}
