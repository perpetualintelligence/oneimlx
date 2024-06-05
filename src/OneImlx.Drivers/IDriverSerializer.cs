/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.IO;
using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// Provides methods for serializing and deserializing drivers.
    /// </summary>
    /// <typeparam name="TDriver">The type of driver to serialize and deserialize.</typeparam>
    public interface IDriverSerializer<TDriver> where TDriver : IDriver
    {
        /// <summary>
        /// Deserializes the driver from the specified stream asynchronously.
        /// </summary>
        /// <param name="stream">The stream to deserialize from.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the deserialized driver.
        /// </returns>
        Task<TDriver> DeserializeAsync(Stream stream);

        /// <summary>
        /// Serializes the driver to the specified stream asynchronously.
        /// </summary>
        /// <param name="driver">The driver to serialize.</param>
        /// <param name="stream">The stream to serialize to.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task SerializeAsync(TDriver driver, Stream stream);
    }
}
