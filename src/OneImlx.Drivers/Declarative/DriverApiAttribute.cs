/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Drivers.Declarative
{
    /// <summary>
    /// Defines a Zero-Trust API for a driver and ensures compliance with OpenID Connect for secure authentication and authorization.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="DriverApiAttribute"/> class with specified parameters.</remarks>
    /// <param name="scope">The required scope for accessing the API.</param>
    /// <param name="role">The role required to access the API.</param>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true)]
    public class DriverApiAttribute(string scope, string? role = null) : Attribute
    {
        /// <summary>
        /// Gets or sets the role required to access the API.
        /// </summary>
        public string? Role { get; set; } = role;

        /// <summary>
        /// Gets or sets the required scope for accessing the API.
        /// </summary>
        public string Scope { get; set; } = scope;
    }
}
