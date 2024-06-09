/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a facility entity within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IFacilityIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the location or address of the facility.
        /// </summary>
        string Location { get; }
    }
}
