/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx
{
    /// <summary>
    /// Represents an identity based on claims using the <c>OneImlx</c> framework.
    /// </summary>
    /// <remarks>
    /// <see cref="OneImlxClaimsIdentity"/> extends the default <see cref="ClaimsIdentity"/> for the <c>OneImlx</c> framework.
    /// </remarks>
    public class OneImlxClaimsIdentity : ClaimsIdentity, IOneImlxIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneImlxClaimsIdentity"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The unique identifier for the identity.</param>
        /// <param name="authenticationType">The authentication type.</param>
        /// <param name="claims">The identity claims.</param>
        /// <param name="createdOn">The date and time when the identity was created.</param>
        /// <param name="lastModifiedOn">The date and time when the identity was last modified. If null, it means the identity has not been modified after creation.</param>
        public OneImlxClaimsIdentity(
            string id,
            string authenticationType,
            IEnumerable<Claim> claims,
            DateTimeOffset createdOn,
            DateTimeOffset? lastModifiedOn = null) : base(claims, authenticationType)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            CreatedOn = createdOn;
            LastModifiedOn = lastModifiedOn;
        }

        /// <summary>
        /// Gets or sets a dictionary for user-defined or application-specific properties.
        /// This can be used by applications to store additional data associated with the identity without modifying the core schema.
        /// </summary>
        public IDictionary<string, object>? Properties { get; set; }

        /// <summary>
        /// Gets or sets a collection of distinct attributes associated with the identity.
        /// Attributes can depict an identity's binary states, inherent characteristics, or various statuses it might assume.
        /// </summary>
        public HashSet<string>? Attributes { get; set; }

        /// <summary>
        /// Gets or sets optional tags associated with the identity.
        /// </summary>
        public HashSet<string>? Tags { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the identity.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets or sets the date and time when the identity was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Gets or sets the date and time when the identity was last modified. If null, it means the identity has not been modified after creation.
        /// </summary>
        public DateTimeOffset? LastModifiedOn { get; }
    }
}