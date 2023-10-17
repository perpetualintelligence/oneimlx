/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensing identity.
    /// </summary>
    public interface ILicenseIdentity : IIdentity, IId, IName, IMetadata
    {
    }
}