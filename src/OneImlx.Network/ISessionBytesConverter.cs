/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Network
{
    /// <summary>
    /// An abstraction for converting data to and from a byte sequence.
    /// </summary>
    public interface ISessionBytesConverter<TData>
    {
        /// <summary>
        /// Converts the specified byte array to data.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>The converted data.</returns>
        TData FromBytes(byte[] bytes);

        /// <summary>
        /// Converts the specified data to a byte array.
        /// </summary>
        /// <param name="data">The data to convert.</param>
        /// <returns>The converted byte array.</returns>
        byte[] ToBytes(TData data);
    }
}
