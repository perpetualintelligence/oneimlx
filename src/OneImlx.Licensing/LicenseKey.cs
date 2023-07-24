/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Defines a license key.
    /// </summary>
    /// <typeparam name="TKey">The type of the license key.</typeparam>
    public sealed class LicenseKey<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LicenseKey{TKey}"/>.
        /// </summary>
        /// <param name="key">The license key.</param>
        public LicenseKey(TKey key)
        {
            Key = key;
        }

        /// <summary>
        /// The license key.
        /// </summary>
        public TKey Key { get; }
    }
}