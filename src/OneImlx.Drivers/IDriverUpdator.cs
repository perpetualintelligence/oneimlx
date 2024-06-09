/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// Defines a repository for pulling driver updates from a remote source.
    /// </summary>
    /// <typeparam name="TDriven">The type of hardware.</typeparam>
    /// <typeparam name="TDriver">The type of drivers.</typeparam>
    public interface IDriverRepository<TDriven, TDriver>
        where TDriven : IDriven
        where TDriver : IDriver
    {
        /// <summary>
        /// Pulls the available updates from a remote source asynchronously.
        /// </summary>
        /// <param name="driven">The hardware for which updates are to be pulled.</param>
        /// <returns>A task that represents the asynchronous operation and returns a list of available driver updates.</returns>
        Task<List<TDriver>> PullAsync(TDriven driven);
    }
}
