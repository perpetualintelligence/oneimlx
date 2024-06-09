/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Licensing
{
    /// <summary>
    /// The claim based <see cref="ILicenseManager"/>.
    /// </summary>
    public class LicenseClaimsManager : ILicenseManager
    {
        /// <inheritdoc/>
        public bool HasLicenseFor(ILicenseIdentity identity, ILicenseResource resource, out License? license)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public bool HasLicenseFor(ILicensePrincipal principal, ILicenseResource resource, out License? license)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public bool HasLicenseFor(string identityId, string resourceId, out License? license)
        {
            throw new System.NotImplementedException();
        }

        private readonly HashSet<License> _licenses = new();
    }
}
