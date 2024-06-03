/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> context.
    /// </summary>
    public sealed class LicenseProducerContext
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        public LicenseProducerContext(License license)
        {
            License = license;
        }

        /// <summary>
        /// The license.
        /// </summary>
        public License License { get; }
    }
}