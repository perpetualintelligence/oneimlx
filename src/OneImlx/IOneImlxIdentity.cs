/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx
{
    /// <summary>
    /// Represents the foundational identity interface for the <c>OneImlx</c> system. This interface serves as the primary blueprint
    /// for defining and interacting with identity entities, accommodating extensibility and integration with diverse applications.
    /// </summary>
    public interface IOneImlxIdentity : IIdentity, IId, IName, IAuditable, IMetadata
    {
    }
}