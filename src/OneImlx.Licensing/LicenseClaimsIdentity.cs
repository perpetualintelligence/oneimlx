/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Represents a claims-based <see cref="ILicenseIdentity"/>. Equality of instances of <see cref="LicenseClaimsIdentity"/> is determined solely based on the <see cref="Id"/> property.
    /// This design choice enhances performance, especially when numerous identities request access to a resource.
    /// </summary>
    /// <remarks>
    /// The <see cref="LicenseClaimsIdentity"/> class is a concrete implementation of a claims-based identity; that is, an identity described by a collection of license claims.
    /// A <see cref="Claim"/> is a statement about an entity made by an issuer that describes a property, right, or some other quality of that entity.
    /// Such an entity is said to be the subject of the <see cref="Claim"/>. The license claims contained in a <see cref="LicenseClaimsIdentity"/> describe the entity
    /// that the corresponding identity represents, and can be used to make authorization and authentication decisions. A claims-based access model has many advantages
    /// over more traditional access models that rely exclusively on roles. For example, claims can provide much richer information about the <see cref="LicenseClaimsIdentity"/> they represent
    /// and can be evaluated for authorization or authentication in a far more specific manner.
    /// </remarks>
    public sealed class LicenseClaimsIdentity : ClaimsIdentity, ILicenseIdentity, IEquatable<LicenseClaimsIdentity?>
    {
        /// <summary>
        /// Initialize a new instance of <see cref="LicenseClaimsIdentity"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the identity.</param>
        /// <param name="authenticationType">The type of authentication used.</param>
        /// <param name="claims">The licensing claims associated with the identity.</param>
        public LicenseClaimsIdentity(
            string id,
            string authenticationType,
            IEnumerable<Claim> claims
            ) : base(claims, authenticationType)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets custom attributes of the identity.
        /// </summary>
        public HashSet<string>? Attributes { get; set; }

        /// <summary>
        /// Gets the unique identifier for the identity.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets or sets custom properties associated with the identity.
        /// </summary>
        public IDictionary<string, object>? Properties { get; set; }
        /// <summary>
        /// Gets or sets tags associated with the identity.
        /// </summary>
        public HashSet<string>? Tags { get; set; }

        /// <summary>
        /// Determines whether two specified instances of <see cref="LicenseClaimsIdentity"/> are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="LicenseClaimsIdentity"/> to compare.</param>
        /// <param name="right">The second <see cref="LicenseClaimsIdentity"/> to compare.</param>
        /// <returns>True if the two instances are not equal; otherwise, false.</returns>
        public static bool operator !=(LicenseClaimsIdentity? left, LicenseClaimsIdentity? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="LicenseClaimsIdentity"/> are equal.
        /// </summary>
        /// <param name="left">The first <see cref="LicenseClaimsIdentity"/> to compare.</param>
        /// <param name="right">The second <see cref="LicenseClaimsIdentity"/> to compare.</param>
        /// <returns>True if the two instances are equal; otherwise, false.</returns>
        public static bool operator ==(LicenseClaimsIdentity? left, LicenseClaimsIdentity? right)
        {
            return EqualityComparer<LicenseClaimsIdentity?>.Default.Equals(left, right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as LicenseClaimsIdentity);
        }

        /// <summary>
        /// Determines whether the specified <see cref="LicenseClaimsIdentity"/> is equal to the current identity.
        /// </summary>
        /// <param name="other">The <see cref="LicenseClaimsIdentity"/> to compare with the current identity.</param>
        /// <returns>True if the specified identity is equal to the current identity; otherwise, false.</returns>
        public bool Equals(LicenseClaimsIdentity? other)
        {
            return other is not null &&
                   Id == other.Id;
        }

        /// <summary>
        /// Returns a hash code for the current identity.
        /// </summary>
        /// <returns>A hash code for the current identity.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}