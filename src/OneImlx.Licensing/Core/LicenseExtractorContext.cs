/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> context.
    /// </summary>
    public sealed class LicenseExtractorContext
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        public LicenseExtractorContext(ILicenseProvider licenseProvider)
        {
            LicenseProvider = licenseProvider;
        }

        /// <summary>
        /// The license provider.
        /// </summary>
        public ILicenseProvider LicenseProvider { get; }
    }
}
