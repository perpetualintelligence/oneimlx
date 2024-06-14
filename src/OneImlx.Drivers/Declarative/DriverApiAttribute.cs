/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Drivers.Declarative
{
    /// <summary>
    /// Defines a Zero-Trust API for a driver and ensures compliance with built-in <c>OpenID Connect</c> for secure
    /// authentication and authorization.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="DriverApiAttribute"/> class with specified parameters.</remarks>
    /// <param name="scope">The required scope for accessing the API.</param>
    /// <param name="role">The role required to access the API.</param>
    /// <param name="context">The calling context used for additional authorization.</param>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class DriverApiAttribute(string scope, string? role = null, string? context = null) : Attribute
    {
        /// <summary>
        /// Gets or sets the calling context used for additional authorization.
        /// </summary>
        public string? Context { get; } = context;

        /// <summary>
        /// Gets or sets the role required to access the API.
        /// </summary>
        public string? Role { get; } = role;

        /// <summary>
        /// Gets or sets the required scope for accessing the API.
        /// </summary>
        public string Scope { get; } = scope;
    }
}
