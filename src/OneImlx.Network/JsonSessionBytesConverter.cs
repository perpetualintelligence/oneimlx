/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Text.Json;
using OneImlx.Abstractions;

namespace OneImlx.Network
{
    /// <summary>
    /// JSON implementation of <see cref="ISessionBytesConverter{TData}"/>.
    /// </summary>
    public sealed class JsonSessionBytesConverter<TData> : ISessionBytesConverter<TData>
    {
        /// <summary>
        /// Converts the specified byte array to data.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>The converted data.</returns>
        /// <exception cref="JsonException">Thrown when deserialization fails.</exception>
        public TData FromBytes(byte[] bytes)
        {
            TData? data = JsonSerializer.Deserialize<TData>(bytes) ?? throw new OneImlxException("invalid_request", "The JSON deserialization failed.");
            return data;
        }

        /// <summary>
        /// Converts the specified data to a byte array.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <returns>The converted byte array.</returns>
        public byte[] ToBytes(TData data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data);
        }
    }
}
