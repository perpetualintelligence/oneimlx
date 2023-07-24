/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Text;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Represents a license key.
    /// </summary>
    public sealed class LicenseKey
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LicenseKey"/>.
        /// </summary>
        /// <param name="key">The license key.</param>
        /// <param name="encoding">The license key encoding.</param>
        public LicenseKey(byte[] key, Encoding encoding)
        {
            Key = key;
            Encoding = encoding;
        }

        /// <summary>
        /// The license key.
        /// </summary>
        public byte[] Key { get; }

        /// <summary>
        /// The license key encoding.
        /// </summary>
        public Encoding Encoding { get; }
    }
}