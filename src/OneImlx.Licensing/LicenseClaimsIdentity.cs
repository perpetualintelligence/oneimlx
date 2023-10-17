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
    /// Represents a claims-based <see cref="ILicenseIdentity"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="LicenseClaimsIdentity"/> class is a concrete implementation of a claims-based identity; that is, an identity described by a collection of license claims.
    /// A <see cref="Claim"/> is a statement about an entity made by an issuer that describes a property, right, or some other quality of that entity.
    /// Such an entity is said to be the subject of the <see cref="Claim"/>. The license claims contained in a <see cref="LicenseClaimsIdentity"/> describe the entity
    /// that the corresponding identity represents, and can be used to make authorization and authentication decisions. A claims-based access model has many advantages
    /// over more traditional access models that rely exclusively on roles. For example, claims can provide much richer information about the <see cref="LicenseClaimsIdentity"/> they represent
    /// and can be evaluated for authorization or authentication in a far more specific manner.
    /// </remarks>
    public sealed class LicenseClaimsIdentity : ClaimsIdentity, ILicenseIdentity
    {
        /// <summary>
        /// Initialize a new instance of <see cref="LicenseClaimsIdentity"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="authenticationType">The authentication type.</param>
        /// <param name="claims">The licensing claims.</param>
        public LicenseClaimsIdentity(
            string id,
            string authenticationType,
            IEnumerable<Claim> claims
            ) : base(claims, authenticationType)
        {
            Id = id;
        }

        /// <summary>
        /// The identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The identity custom properties.
        /// </summary>
        public IDictionary<string, object>? Properties { get; set; }

        /// <summary>
        /// The identity custom attributes.
        /// </summary>
        public HashSet<string>? Attributes { get; set; }

        /// <summary>
        /// The identity tags.
        /// </summary>
        public HashSet<string>? Tags { get; set; }
    }
}