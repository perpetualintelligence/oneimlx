/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using OneImlx.Abstractions;
using OneImlx.Test.FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace OneImlx.Network
{
    public class JsonSessionBytesConverterTests
    {
        [Fact]
        public void FromBytes_ShouldConvertBytesToString()
        {
            var data = "test data";
            var bytes = JsonSerializer.SerializeToUtf8Bytes(data);

            var result = _converter.FromBytes(bytes);
            result.Should().Be(data);
        }

        [Fact]
        public void FromBytes_ShouldThrowExceptionWhenDeserializationFails()
        {
            var bytes = new byte[] { 1, 2, 3, 4 };

            Action act = () => _converter.FromBytes(bytes);

            act.Should().Throw<JsonException>();
        }

        [Fact]
        public void FromBytes_ShouldThrowExceptionWhenDeserializationReturnsNull()
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes("null"); // JSON null

            Action act = () => _converter.FromBytes(bytes);

            act.Should().Throw<OneImlxException>()
               .WithErrorCode("invalid_request")
               .WithErrorDescription("The JSON deserialization failed.");
        }

        [Fact]
        public void ToBytes_ShouldConvertStringToBytes()
        {
            var data = "test data";

            var result = _converter.ToBytes(data);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(JsonSerializer.SerializeToUtf8Bytes(data));
        }

        private readonly JsonSessionBytesConverter<string> _converter = new();
    }
}
