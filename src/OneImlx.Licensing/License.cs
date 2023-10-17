/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// An abstraction of a disposable license.
    /// </summary>
    /// <remarks>
    /// A license is assigned to the <see cref="LicenseClaimsPrincipal"/> to enable the use of the <see cref="LicenseResource"/>.
    /// </remarks>
    /// <seealso cref="LicenseClaimsPrincipal"/>
    public sealed class License
    {
        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        /// <param name="principals">The license principals that have the valid license license.</param>
        /// <param name="licenseKey"></param>
        public License(Dictionary<ILicensePrincipal, ILicenseResource> principals, LicenseKey licenseKey)
        {
            Principals = new ReadOnlyDictionary<ILicensePrincipal, ILicenseResource>(principals);
            LicenseKey = licenseKey;
        }

        /// <summary>
        /// Identifies all the <see cref="LicenseClaimsPrincipal"/> that are licensed to access the <see cref="LicenseResource"/>.
        /// </summary>
        public IReadOnlyDictionary<ILicensePrincipal, ILicenseResource> Principals { get; }

        /// <summary>
        /// The license key.
        /// </summary>
        public LicenseKey LicenseKey { get; }
    }
}