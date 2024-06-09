/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Network
{
    public class TcpSessionTests
    {
        [Fact]
        public async Task ConnectAsync_ShouldConnectToHostname()
        {
            var session = new TcpSession<string, string>(
                "1", "Test Session", "Test Description", "localhost", 12345,
                _dataConverterMock.Object, _resultConverterMock.Object);

            Func<Task> act = async () => await session.ConnectAsync();

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ConnectAsync_ShouldConnectToIpAddress()
        {
            var ipAddress = IPAddress.Loopback;
            var session = new TcpSession<string, string>(
                "1", "Test Session", "Test Description", ipAddress, 12345,
                _dataConverterMock.Object, _resultConverterMock.Object);

            Func<Task> act = async () => await session.ConnectAsync();

            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ReceiveAsync_ShouldReceiveData()
        {
            var responseData = "response data";
            var responseBytes = Encoding.UTF8.GetBytes(responseData);
            _resultConverterMock.Setup(rc => rc.FromBytes(It.IsAny<byte[]>())).Returns(responseData);
            var session = new TcpSession<string, string>(
                "1", "Test Session", "Test Description", "localhost", 12345,
                _dataConverterMock.Object, _resultConverterMock.Object);

            var result = await session.ReceiveAsync();

            result.Should().Be(responseData);
            _resultConverterMock.Verify(rc => rc.FromBytes(It.IsAny<byte[]>()), Times.Once);
        }

        [Fact]
        public async Task SendAsync_ShouldSendData()
        {
            var data = "test data";
            var bytes = Encoding.UTF8.GetBytes(data);
            _dataConverterMock.Setup(dc => dc.ToBytes(data)).Returns(bytes);
            var session = new TcpSession<string, string>(
                "1", "Test Session", "Test Description", "localhost", 12345,
                _dataConverterMock.Object, _resultConverterMock.Object);

            Func<Task> act = async () => await session.SendAsync(data);

            await act.Should().NotThrowAsync();
            _dataConverterMock.Verify(dc => dc.ToBytes(data), Times.Once);
        }

        [Fact]
        public async Task SendReceiveAsync_ShouldSendAndReceiveData()
        {
            var data = "test data";
            var responseData = "response data";
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var responseBytes = Encoding.UTF8.GetBytes(responseData);
            _dataConverterMock.Setup(dc => dc.ToBytes(data)).Returns(dataBytes);
            _resultConverterMock.Setup(rc => rc.FromBytes(It.IsAny<byte[]>())).Returns(responseData);
            var session = new TcpSession<string, string>(
                "1", "Test Session", "Test Description", "localhost", 12345,
                _dataConverterMock.Object, _resultConverterMock.Object);

            var result = await session.SendReceiveAsync(data);

            result.Should().Be(responseData);
            _dataConverterMock.Verify(dc => dc.ToBytes(data), Times.Once);
            _resultConverterMock.Verify(rc => rc.FromBytes(It.IsAny<byte[]>()), Times.Once);
        }

        private readonly Mock<ISessionBytesConverter<string>> _dataConverterMock = new Mock<ISessionBytesConverter<string>>();
        private readonly Mock<ISessionBytesConverter<string>> _resultConverterMock = new Mock<ISessionBytesConverter<string>>();
    }
}
