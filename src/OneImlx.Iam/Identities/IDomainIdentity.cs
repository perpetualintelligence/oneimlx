/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a domain or an engineering discipline within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IDomainIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the type or category of the domain (e.g., IoT device, server, sensor).
        /// </summary>
        string DomainType { get; }
    }
}