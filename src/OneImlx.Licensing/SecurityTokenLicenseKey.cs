/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using Microsoft.IdentityModel.Tokens;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Represents a <see cref="SecurityToken"/> based license key.
    /// </summary>
    public sealed class SecurityTokenLicenseKey : ILicenseKey
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SecurityTokenLicenseKey"/>.
        /// </summary>
        /// <param name="securityToken">The security token associated with this license key.</param>
        public SecurityTokenLicenseKey(SecurityToken securityToken)
        {
            SecurityToken = securityToken;
        }

        /// <summary>
        /// The security token associated with this license key.
        /// </summary>
        public SecurityToken SecurityToken { get; set; }
    }
}
