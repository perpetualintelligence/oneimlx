/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction for a <see cref="IDriver"/> life-cycle.
    /// </summary>
    public interface IDriverLifecycle
    {
        /// <summary>
        /// Connects the driver to the driven entity.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ConnectAsync();

        /// <summary>
        /// Disconnects the driver from the driven entity.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DisconnectAsync();

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task InitializeAsync();

        /// <summary>
        /// Renders to the driver.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RenderAsync();
    }
}
