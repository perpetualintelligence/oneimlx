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
        /// Determines if the session connected to the remote host.
        /// </summary>
        Task<bool> IsConnectedAsync();

        /// <summary>
        /// Resets a connection with the remote host. If the connection is already established then this method will
        /// disconnect and connect to remote host again.
        /// </summary>
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
