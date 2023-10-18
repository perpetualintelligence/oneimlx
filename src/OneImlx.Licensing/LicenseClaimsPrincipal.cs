/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx.Licensing
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

        /// <summary>
        /// The collection of identities associated with this principal.
        /// </summary>
        IEnumerable<ILicenseIdentity> ILicensePrincipal.Identities => base.Identities.Cast<ILicenseIdentity>();
    }
}