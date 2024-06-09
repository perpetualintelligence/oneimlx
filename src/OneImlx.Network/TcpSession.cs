/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OneImlx.Network
{
    /// <summary>
    /// Represents a TCP network session.
    /// </summary>
    public class TcpSession<TData, TResult> : IStatefulSession<TData, TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcpSession{TData, TResult}"/> class with hostname.
        /// </summary>
        /// <param name="id">The session identifier.</param>
        /// <param name="name">The session name.</param>
        /// <param name="description">The session description.</param>
        /// <param name="host">The hostname to connect to.</param>
        /// <param name="port">The port to connect to.</param>
        /// <param name="dataConverter">The converter used for data serialization and deserialization.</param>
        /// <param name="resultConverter">The converter used for result serialization and deserialization.</param>
        /// <param name="endOfMessage">The end-of-message marker (optional, default is "$m$").</param>
        public TcpSession(string id, string name, string description, string host, int port, ISessionBytesConverter<TData> dataConverter, ISessionBytesConverter<TResult> resultConverter, string endOfMessage = "$m$")
        {
            Id = id;
            Name = name;
            Description = description;
            Hostname = host;
            Port = port;
            _client = new TcpClient();
            _dataConverter = dataConverter;
            _resultConverter = resultConverter;
            EndOfMessage = endOfMessage; // Default end-of-message marker
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpSession{TData, TResult}"/> class with IP address.
        /// </summary>
        /// <param name="id">The session identifier.</param>
        /// <param name="name">The session name.</param>
        /// <param name="description">The session description.</param>
        /// <param name="ipAddress">The IP address to connect to.</param>
        /// <param name="port">The port to connect to.</param>
        /// <param name="dataConverter">The converter used for data serialization and deserialization.</param>
        /// <param name="resultConverter">The converter used for result serialization and deserialization.</param>
        /// <param name="endOfMessage">The end-of-message marker (optional, default is "$m$").</param>
        public TcpSession(string id, string name, string description, IPAddress ipAddress, int port, ISessionBytesConverter<TData> dataConverter, ISessionBytesConverter<TResult> resultConverter, string endOfMessage = "$m$")
        {
            Id = id;
            Name = name;
            Description = description;
            IpAddress = ipAddress;
            Port = port;
            _client = new TcpClient();
            _dataConverter = dataConverter;
            _resultConverter = resultConverter;
            EndOfMessage = endOfMessage; // Default end-of-message marker
        }

        /// <summary>
        /// Gets the session description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the end-of-message marker to determine the end of the response.
        /// </summary>
        public string EndOfMessage { get; private set; }

        /// <summary>
        /// Gets the hostname used to connect to the session.
        /// </summary>
        public string? Hostname { get; private set; }

        /// <summary>
        /// Gets the session identifier.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the IP address used to connect to the session.
        /// </summary>
        public IPAddress? IpAddress { get; private set; }

        /// <summary>
        /// Gets the session name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the port used to connect to the session.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Connects to the session asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous connect operation.</returns>
        public async Task ConnectAsync()
        {
            if (Hostname != null)
            {
                await _client.ConnectAsync(Hostname, Port);
            }
            else if (IpAddress != null)
            {
                await _client.ConnectAsync(IpAddress, Port);
            }
            else
            {
                throw new InvalidOperationException("Host or IP address must be set.");
            }
        }

        /// <summary>
        /// Disconnects from the session asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnect operation.</returns>
        public async Task DisconnectAsync()
        {
            _client.Close();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Reads data from the stream asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous read operation, with the received data as a stream.</returns>
        public Stream GetStream()
        {
            return _client.GetStream();
        }

        /// <summary>
        /// Receives data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous receive operation, with the received data as TResult.</returns>
        public async Task<TResult> ReceiveAsync()
        {
            var stream = _client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;
            StringBuilder responseBuilder = new(_leftoverData.ToString());
            bool eomFound = false;

            // Read the entire response
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                responseBuilder.Append(chunk);

                // Check if the end-of-message marker is found
                int eomIndex = responseBuilder.ToString().IndexOf(EndOfMessage, StringComparison.Ordinal);
                if (eomIndex >= 0)
                {
                    eomFound = true;
                    _leftoverData.Clear();
                    _leftoverData.Append(responseBuilder.ToString().Substring(eomIndex + EndOfMessage.Length));
                    responseBuilder.Length = eomIndex + EndOfMessage.Length; // Trim the response to EOM
                    break;
                }
            }

            if (!eomFound)
            {
                _leftoverData.Clear(); // Clear leftover if EOM is not found
            }

            string response = responseBuilder.ToString();
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            return _resultConverter.FromBytes(responseBytes);
        }

        /// <summary>
        /// Sends data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send operation.</returns>
        public async Task SendAsync(TData data)
        {
            var stream = _client.GetStream();
            byte[] byteData = _dataConverter.ToBytes(data);

            await stream.WriteAsync(byteData, 0, byteData.Length);
        }

        /// <summary>
        /// Sends and receives data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send and receive operation, with the received data as TResult.</returns>
        public async Task<TResult> SendReceiveAsync(TData data)
        {
            await SendAsync(data);
            return await ReceiveAsync();
        }

        private readonly TcpClient _client;
        private readonly ISessionBytesConverter<TData> _dataConverter;
        private readonly StringBuilder _leftoverData = new();
        private readonly ISessionBytesConverter<TResult> _resultConverter;
    }
}
