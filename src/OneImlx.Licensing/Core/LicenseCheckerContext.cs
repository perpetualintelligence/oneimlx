/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> context.
    /// </summary>
    public sealed class LicenseCheckerContext
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        public LicenseCheckerContext(ILicense license)
        {
            License = license ?? throw new System.ArgumentNullException(nameof(license));
        }

        /// <summary>
        /// The license to check.
        /// </summary>
        public ILicense License { get; }
    }
}