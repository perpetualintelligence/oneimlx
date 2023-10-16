/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx
{
    /// <summary>
    /// Represents a claim based <c>OneImlx</c> principal.
    /// </summary>
    public class OneImlxClaimsPrincipal : ClaimsPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneImlxClaimsPrincipal"/> class using a collection of OneImlxClaimsIdentity.
        /// </summary>
        /// <param name="identities">A collection of OneImlxClaimsIdentity objects.</param>
        public OneImlxClaimsPrincipal(IEnumerable<OneImlxClaimsIdentity> identities) : base(identities)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneImlxClaimsPrincipal"/> class using a single OneImlxClaimsIdentity.
        /// </summary>
        /// <param name="identity">A OneImlxClaimsIdentity object.</param>
        public OneImlxClaimsPrincipal(OneImlxClaimsIdentity identity) : base(identity)
        {
        }
    }
}