/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Claims;

namespace OneImlx.Licensing
{
    /// <summary>
    /// A <see cref="ClaimsPrincipal"/> implementation that supports multiple claims-based <see cref="LicenseClaimsIdentity"/>.
    /// </summary>
    public class LicenseClaimsPrincipal : ClaimsPrincipal, ILicensePrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseClaimsPrincipal"/> class using a collection of <see cref="LicenseClaimsIdentity"/>.
        /// </summary>
        /// <param name="identities">A collection of <see cref="LicenseClaimsIdentity"/> objects.</param>
        public LicenseClaimsPrincipal(IEnumerable<LicenseClaimsIdentity> identities) : base(identities)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseClaimsPrincipal"/> class using a single <see cref="LicenseClaimsIdentity"/>.
        /// </summary>
        /// <param name="identity">A <see cref="LicenseClaimsIdentity"/> object.</param>
        public LicenseClaimsPrincipal(LicenseClaimsIdentity identity) : base(identity)
        {
        }

        IEnumerable<ILicenseIdentity> ILicensePrincipal.Identities => throw new System.NotImplementedException();

        public bool IsLicensed(string identityId, out ILicenseIdentity? licenseIdentity)
        {
            throw new System.NotImplementedException();
        }
    }
}
