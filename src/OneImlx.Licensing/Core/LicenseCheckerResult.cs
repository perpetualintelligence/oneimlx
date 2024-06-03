/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> result.
    /// </summary>
    public sealed class LicenseCheckerResult
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="license">The checked license.</param>
        public LicenseCheckerResult(License license)
        {
            License = license;
        }

        /// <summary>
        /// The checked license.
        /// </summary>
        public License License { get; }
    }
}