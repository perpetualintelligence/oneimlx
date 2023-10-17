/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> result.
    /// </summary>
    public sealed class LicenseExtractorResult
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="license">The extracted license.</param>
        public LicenseExtractorResult(License license)
        {
            License = license;
        }

        /// <summary>
        /// The extracted licenses.
        /// </summary>
        public License License { get; }
    }
}