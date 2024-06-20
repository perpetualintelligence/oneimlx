/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;
using OneImlx.Abstractions;

namespace OneImlx.Iam
{
    /// <summary>
    /// Defines a generic <c>OneImlx</c> IAM identity.
    /// </summary>
    public interface IIamIdentity : IIdentity, IId, IName, IMetadata
    {
    }
}
