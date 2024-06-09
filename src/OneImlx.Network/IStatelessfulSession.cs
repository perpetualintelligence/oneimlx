/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Network
{
    /// <summary>
    /// An abstraction of a stateful network session.
    /// </summary>
    public interface IStatefulSession<TData, TResult> : ISession
    {
        /// <summary>
        /// Connects to the session asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        Task ConnectAsync();

        /// <summary>
        /// Disconnects from the session asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnect operation.</returns>
        Task DisconnectAsync();

        /// <summary>
        /// Sends data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send operation.</returns>
        Task SendAsync(TData data);

        /// <summary>
        /// Sends and receives data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send and receive operation, with the received data.</returns>
        Task<TResult> SendReceiveAsync(TData data);
    }
}
