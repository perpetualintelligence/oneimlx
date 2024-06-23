/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using OneImlx.Abstractions;
using OneImlx.Test.FluentAssertions;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Network.Tests
{
    public class TcpSessionTests : IDisposable
    {
        public TcpSessionTests()
        {
            _port = new Random().Next(10000, 60000);
            _listener = new TcpListener(IPAddress.Loopback, _port);
            _listener.Start();
            _dataConverter = new JsonSessionBytesConverter<string>();
            _resultConverter = new JsonSessionBytesConverter<string>();
            _eom = Encoding.UTF8.GetBytes("$m$");
        }

        [Fact]
        public async Task ConnectAsync_ShouldConnectToHostname()
        {
            var session = CreateSession();
            var connectTask = session.ConnectAsync();

            _testClient = await _listener.AcceptTcpClientAsync();
            await connectTask;

            (await session.IsConnectedAsync()).Should().BeTrue();

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public void Constructor_ShouldInitializeWithIpAddress()
        {
            var ipAddress = IPAddress.Loopback;
            var session = new TcpSession<string, string>("testId", "testName", "testDescription", ipAddress, _port, _dataConverter, _resultConverter, _eom);

            session.IpAddress.Should().Be(ipAddress);
            session.Port.Should().Be(_port);
        }

        [Fact]
        public async Task DisconnectAsync_ShouldCloseTcpClient()
        {
            var session = CreateSession();
            var _ = session.ConnectAsync();

            _testClient = await _listener.AcceptTcpClientAsync();
            await session.DisconnectAsync();

            (await session.IsConnectedAsync()).Should().BeFalse();

            _testClient.Close(); // Close the client after the test
        }

        public void Dispose()
        {
            _listener.Stop();
            _testClient?.Close();
        }

        [Fact]
        public async Task ExceptionHandling_ConnectAsync_ShouldThrowException_WhenHostOrIpAddressNotSet()
        {
            var session = new TcpSession<string, string>("testId", "testName", "testDescription", ipAddress: null!, _port, _dataConverter, _resultConverter, _eom);
            Func<Task> act = async () => await session.ConnectAsync();
            await act.Should().ThrowAsync<OneImlxException>()
                .WithErrorCode("invalid_request")
                .WithErrorDescription("The hostname or IP address must be set.");

            var session2 = new TcpSession<string, string>("testId", "testName", "testDescription", ipAddress: null!, _port, _dataConverter, _resultConverter, _eom);
            Func<Task> act2 = async () => await session2.ConnectAsync();
            await act2.Should().ThrowAsync<OneImlxException>()
                .WithErrorCode("invalid_request")
                .WithErrorDescription("The hostname or IP address must be set.");
        }

        [Fact]
        public async Task FlushAsync_ShouldFlushStream()
        {
            var session = CreateSession();
            var connectTask = session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();
            await connectTask;

            var networkStream = _testClient.GetStream();
            var buffer = new byte[1024];

            var data = "test data";

            // Send data back to server
            await session.SendAsync(data);
            await session.FlushAsync();

            // Verify
            var bytesRead = await networkStream.ReadAsync(buffer);
            var actualBytes = new byte[bytesRead];
            Array.Copy(buffer, actualBytes, bytesRead);

            var receivedData = _resultConverter.FromBytes(actualBytes);
            receivedData.Should().Be(data);

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task IsConnectedAsync_ShouldReturnFalse_WhenNotConnected()
        {
            var session = CreateSession();
            var result = await session.IsConnectedAsync();

            result.Should().BeFalse();
        }

        [Fact]
        public async Task IsConnectedAsync_ShouldReturnTrue_WhenConnected()
        {
            var session = CreateSession();
            var _ = session.ConnectAsync();

            _testClient = await _listener.AcceptTcpClientAsync();
            var result = await session.IsConnectedAsync();

            result.Should().BeTrue();

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task ReceiveAsync_ShouldReceiveData()
        {
            var session = CreateSession();
            var _ = session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();

            // Send the data from server to session
            var responseData = "test response data";
            var responseBytes = _dataConverter.ToBytes(responseData + "$m$");
            var networkStream = _testClient.GetStream();
            await networkStream.WriteAsync(responseBytes);

            // Receive the data from session
            var result = await session.ReceiveAsync();

            result.Should().Be(responseData);

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task ResetAsync_ShouldDisconnectAndReconnect()
        {
            var session = CreateSession();
            var _ = session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();

            await session.ResetAsync();

            // Accept the new connection
            _testClient.Close(); // Close the old client
            _testClient = await _listener.AcceptTcpClientAsync(); // Accept the new connection

            (await session.IsConnectedAsync()).Should().BeTrue();

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task SendAsync_ShouldWriteDataToStream()
        {
            var session = CreateSession();
            var data = "test data";
            var bytes = Encoding.UTF8.GetBytes(data);

            var _ = session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();

            var networkStream = _testClient.GetStream();
            var buffer = new byte[bytes.Length];
            var readTask = networkStream.ReadAsync(buffer, 0, buffer.Length);

            await session.SendAsync(data);
            await readTask;

            buffer.Should().BeEquivalentTo(bytes);

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task SendReceiveAsync_ShouldSendAndReceiveData()
        {
            var session = CreateSession();
            var data = "test data";
            var responseData = "response data";
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var responseBytes = Encoding.UTF8.GetBytes(responseData + "$m$");

            var _ = session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();

            var networkStream = _testClient.GetStream();
            var buffer = new byte[dataBytes.Length];
            var readTask = networkStream.ReadAsync(buffer, 0, buffer.Length);

            await session.SendAsync(data);
            await readTask;
            buffer.Should().BeEquivalentTo(dataBytes);

            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

            var result = await session.SendReceiveAsync(data);
            result.Should().Be(responseData);

            _testClient.Close(); // Close the client after the test
        }

        private TcpSession<string, string> CreateSession() => new
        (
            "testId",
            "testName",
            "testDescription",
            "localhost",
            _port,
            _dataConverter,
            _resultConverter,
            _eom
        );

        private readonly JsonSessionBytesConverter<string> _dataConverter;
        private readonly TcpListener _listener;
        private readonly int _port;
        private readonly JsonSessionBytesConverter<string> _resultConverter;
        private byte[] _eom;
        private TcpClient _testClient;
    }
}
