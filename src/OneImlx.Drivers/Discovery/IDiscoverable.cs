/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Discovery
{
    /// <summary>
    /// An abstraction of an entity that can be discovered.
    /// </summary>
    public interface IDiscoverable
    {
        /// <summary>
        /// Called when the entity is discovered.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DiscoveredAsync();
    }
}
