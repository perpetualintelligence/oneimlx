/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using OneImlx.Abstractions;

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
        /// <param name="endOfMessage">The end-of-message marker.</param>
        public TcpSession(string id, string name, string description, string host, int port, ISessionBytesConverter<TData> dataConverter, ISessionBytesConverter<TResult> resultConverter, byte[] endOfMessage)
        {
            Id = id;
            Name = name;
            Description = description;
            Hostname = host;
            Port = port;
            _client = new TcpClient();
            _dataConverter = dataConverter;
            _resultConverter = resultConverter;
            EndOfMessage = endOfMessage; // End-of-message marker
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
        /// <param name="endOfMessage">The end-of-message marker.</param>
        public TcpSession(string id, string name, string description, IPAddress ipAddress, int port, ISessionBytesConverter<TData> dataConverter, ISessionBytesConverter<TResult> resultConverter, byte[] endOfMessage)
        {
            Id = id;
            Name = name;
            Description = description;
            IpAddress = ipAddress;
            Port = port;
            _dataConverter = dataConverter;
            _resultConverter = resultConverter;
            EndOfMessage = endOfMessage; // End-of-message marker
        }

        /// <summary>
        /// Gets the session description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the end-of-message marker to determine the end of the response.
        /// </summary>
        public byte[] EndOfMessage { get; private set; }

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
            _client ??= new TcpClient();

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
                throw new OneImlxException("invalid_request", "The hostname or IP address must be set.");
            }
        }

        /// <summary>
        /// Disconnects from the session asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous disconnect operation.</returns>
        public async Task DisconnectAsync()
        {
            _client?.Close();
            _client = null;
            _leftoverData.Clear();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Flushes the underlying stream immediately.
        /// </summary>
        /// <returns>A task representing the asynchronous flush operation.</returns>
        public async Task FlushAsync()
        {
            ThrowIfTcpClientIsNull();
            var stream = _client!.GetStream();
            await stream.FlushAsync();
        }

        /// <summary>
        /// Reads data from the stream asynchronously.
        /// </summary>
        /// <returns>A stream representing the data read from the session.</returns>
        public Stream GetStream()
        {
            ThrowIfTcpClientIsNull();
            return _client!.GetStream();
        }

        /// <summary>
        /// Determines if this TCP session is connected to the remote host.
        /// </summary>
        /// <returns>A task representing the asynchronous operation to check the connection status.</returns>
        public Task<bool> IsConnectedAsync()
        {
            bool result = _client?.Connected ?? false;
            return Task.FromResult(result);
        }

        /// <summary>
        /// Receives data asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous receive operation, with the received data as <typeparamref name="TResult"/>.</returns>
        public async Task<TResult> ReceiveAsync()
        {
            ThrowIfTcpClientIsNull();
            var stream = _client!.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            // Read the entire response
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                // Put the read bytes in queue
                for (int idx = 0; idx < bytesRead; idx++)
                {
                    _leftoverData.Enqueue(buffer[idx]);
                }

                // Get the first full message
                byte[]? response = FirstFullMessage();
                if (response != null)
                {
                    // Found
                    return _resultConverter.FromBytes(response);
                }
            }

            // Timeout
            throw new TimeoutException($"The session receive timed out. session={Id}");
        }

        /// <summary>
        /// Resets the client connection by disconnecting and reconnecting the connection to the remote host.
        /// </summary>
        /// <returns>A task representing the asynchronous reset operation.</returns>
        public async Task ResetAsync()
        {
            if (await IsConnectedAsync())
            {
                _leftoverData.Clear();
                await DisconnectAsync();
            }

            await ConnectAsync();
        }

        /// <summary>
        /// Sends data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send operation.</returns>
        public async Task SendAsync(TData data)
        {
            ThrowIfTcpClientIsNull();
            var stream = _client!.GetStream();
            byte[] byteData = _dataConverter.ToBytes(data);
            await stream.WriteAsync(byteData, 0, byteData.Length);
        }

        /// <summary>
        /// Sends and receives data asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A task representing the asynchronous send and receive operation, with the received data as <typeparamref name="TResult"/>.</returns>
        public async Task<TResult> SendReceiveAsync(TData data)
        {
            await SendAsync(data);
            return await ReceiveAsync();
        }

        private byte[]? FirstFullMessage()
        {
            Queue<byte> result = new Queue<byte>();

            // If the Queue is same or less than delimiter then there is no message
            int eomLength = EndOfMessage.Length;
            if (_leftoverData.Count <= eomLength)
            {
                return null;
            }

            // Take first n elements from queue and compare them with delimiter bytes sequentially. If we found a
            // sequential match then we have our full message.
            bool eomMatched = false;
            while (_leftoverData.Count > 0)
            {
                // If all the bytes of eom match then have our full message
                for (int jdx = 0; jdx < eomLength; ++jdx)
                {
                    // If we run out of data while trying to match EOM, break and re-enqueue
                    if (_leftoverData.Count == 0)
                    {
                        eomMatched = false;
                        break;
                    }

                    byte current = _leftoverData.Dequeue();
                    result.Enqueue(current);
                    bool currentMatch = current == EndOfMessage[jdx];

                    if (!currentMatch)
                    {
                        break;
                    }
                    else
                    {
                        eomMatched = currentMatch && (jdx == eomLength - 1);
                    }
                }

                if (eomMatched)
                {
                    for (int jdx = 0; jdx < eomLength; ++jdx)
                    {
                        result.Dequeue();
                    }
                }
            }

            return null;
        }

        private void ThrowIfTcpClientIsNull()
        {
            if (_client == null)
            {
                throw new OneImlxException("invalid_request", "The TCP client is null or not initialized");
            }
        }

        private readonly ISessionBytesConverter<TData> _dataConverter;
        private readonly Queue<byte> _leftoverData = new();
        private readonly ISessionBytesConverter<TResult> _resultConverter;
        private TcpClient? _client;
    }
}
