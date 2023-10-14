/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of an organization, business, or government entity within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IOrganizationIdentity : IOneImlxIdentity
    {
        /// <summary>
        /// Gets the location or address of the organization.
        /// </summary>
        string Location { get; }
    }
}