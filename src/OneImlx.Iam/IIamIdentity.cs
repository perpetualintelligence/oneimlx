/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx.Iam
{
    /// <summary>
    /// Defines a genric <c>OneImlx</c> IAM identity.
    /// </summary>
    public interface IIamIdentity : IIdentity, IId, IName, IMetadata, IAuditable
    {
    }
}