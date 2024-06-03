/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a person or a user within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IPersonIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the email address associated with the user.
        /// </summary>
        string Email { get; }
    }
}