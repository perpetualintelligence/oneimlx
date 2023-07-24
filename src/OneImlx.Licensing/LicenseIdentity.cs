/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Represents a claims-based licensed identity.
    /// </summary>
    /// <remarks>
    /// The <see cref="LicenseIdentity"/> class is a concrete implementation of a claims-based identity; that is, an identity described by a collection of license claims.
    /// A <see cref="LicenseClaim"/> is a statement about an entity made by an issuer that describes a property, right, or some other quality of that entity.
    /// Such an entity is said to be the subject of the <see cref="LicenseClaim"/>. The license claims contained in a <see cref="LicenseIdentity"/> describe the entity
    /// that the corresponding identity represents, and can be used to make authorization and authentication decisions. A claims-based access model has many advantages
    /// over more traditional access models that rely exclusively on roles. For example, claims can provide much richer information about the <see cref="LicenseIdentity"/> they represent
    /// and can be evaluated for authorization or authentication in a far more specific manner.
    /// </remarks>
    public sealed class LicenseIdentity : ClaimsIdentity
    {
        /// <summary>
        /// Initialize a new instance of <see cref="LicenseIdentity"/>.
        /// </summary>
        /// <param name="key">The license key.</param>
        /// <param name="claims">The license claims.</param>
        public LicenseIdentity(LicenseKey key, IEnumerable<LicenseClaim> claims) : base(claims)
        {
            Key = key;
        }

        /// <summary>
        /// The license key.
        /// </summary>
        public LicenseKey Key { get; }
    }
}