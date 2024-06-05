/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Drivers.Declarative
{
    /// <summary>
    /// Defines attributes for a driver and ensures compliance with OpenID Connect for secure authentication and authorization.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="DriverAttribute"/> class with specified parameters.</remarks>
    /// <param name="issuer">The issuer URL for the OpenID Connect provider.</param>
    /// <param name="audiences">The audiences for the API, typically the API's identifiers.</param>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class DriverAttribute(string issuer, params string[] audiences) : Attribute
    {
        /// <summary>
        /// Gets the audiences for the API, typically the API's identifiers.
        /// </summary>
        public string[] Audiences { get; } = audiences;

        /// <summary>
        /// Gets the issuer URL for the OpenID Connect provider.
        /// </summary>
        public string Issuer { get; } = issuer;
    }
}
