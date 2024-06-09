/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// Defines methods for handling driver life-cycle events.
    /// </summary>
    public interface IDriverEvents
    {
        /// <summary>
        /// Called when the driver connects to the driven entity.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task OnConnectedAsync();

        /// <summary>
        /// Called when the driver disconnects from the driven entity.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task OnDisconnectedAsync();

        /// <summary>
        /// Called when the driver is initialized.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task OnInitializedAsync();

        /// <summary>
        /// Called when the driver starts rendering.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task OnRenderedAsync();
    }
}
