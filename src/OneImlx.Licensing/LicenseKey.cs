/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using Microsoft.IdentityModel.Tokens;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Represents a license key.
    /// </summary>
    public sealed class LicenseKey
    {
        /// <summary>
        /// Initializes a new instance of <see cref="LicenseKey"/>.
        /// </summary>
        /// <param name="securityToken">The security token associated with this license key.</param>
        public LicenseKey(SecurityToken securityToken)
        {
            SecurityToken = securityToken;
        }

        /// <summary>
        /// The security token associated with this license key.
        /// </summary>
        public SecurityToken SecurityToken { get; set; }
    }
}