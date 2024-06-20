/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
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
            _dataConverterMock = new Mock<ISessionBytesConverter<string>>();
            _resultConverterMock = new Mock<ISessionBytesConverter<string>>();
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
        public async Task DisconnectAsync_ShouldCloseTcpClient()
        {
            var session = CreateSession();
            await session.ConnectAsync();

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
            await session.ConnectAsync();

            _testClient = await _listener.AcceptTcpClientAsync();
            var result = await session.IsConnectedAsync();

            result.Should().BeTrue();

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task ReceiveAsync_ShouldReceiveData()
        {
            var session = CreateSession();
            var responseData = "response data";
            var responseBytes = Encoding.UTF8.GetBytes(responseData + "$m$");
            _resultConverterMock.Setup(rc => rc.FromBytes(It.IsAny<byte[]>())).Returns(responseData);

            await session.ConnectAsync();
            _testClient = await _listener.AcceptTcpClientAsync();

            var networkStream = _testClient.GetStream();
            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);

            var result = await session.ReceiveAsync();

            result.Should().Be(responseData);

            _testClient.Close(); // Close the client after the test
        }

        [Fact]
        public async Task ResetAsync_ShouldDisconnectAndReconnect()
        {
            var session = CreateSession();
            await session.ConnectAsync();
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
            _dataConverterMock.Setup(dc => dc.ToBytes(data)).Returns(bytes);

            await session.ConnectAsync();
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

            _dataConverterMock.Setup(dc => dc.ToBytes(data)).Returns(dataBytes);
            _resultConverterMock.Setup(rc => rc.FromBytes(It.IsAny<byte[]>())).Returns(responseData);

            await session.ConnectAsync();
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

        private TcpSession<string, string> CreateSession() => new(
                "testId",
                "testName",
                "testDescription",
                "localhost",
                _port,
                _dataConverterMock.Object,
                _resultConverterMock.Object
                                                 );

        private readonly Mock<ISessionBytesConverter<string>> _dataConverterMock;
        private readonly TcpListener _listener;
        private readonly int _port;
        private readonly Mock<ISessionBytesConverter<string>> _resultConverterMock;
        private TcpClient _testClient;
    }
}
