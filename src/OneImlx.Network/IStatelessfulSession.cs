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
        /// Connects to the remote host asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        Task ConnectAsync();

        /// <summary>
        /// Disconnects from the remote host asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnect operation.</returns>
        Task DisconnectAsync();

        /// <summary>
        /// Flushes the underlying stream immediately.
        /// </summary>
        /// <returns>A task representing the asynchronous flush operation.</returns>
        Task FlushAsync();

        /// <summary>
        /// Determines if the session is connected to the remote host.
        /// </summary>
        /// <returns>A task representing the asynchronous operation to check the connection status.</returns>
        Task<bool> IsConnectedAsync();

        /// <summary>
        /// Resets the connection with the remote host. If the connection is already established, this method will
        /// disconnect and reconnect to the remote host.
        /// </summary>
        /// <returns>A task representing the asynchronous reset operation.</returns>
        Task ResetAsync();

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
