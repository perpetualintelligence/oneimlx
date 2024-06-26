﻿/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of an organization, business, or government entity within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IOrganizationIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the location or address of the organization.
        /// </summary>
        string Location { get; }
    }
}
