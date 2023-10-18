/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensing identity. Establishes the <c>who</c>.
    /// </summary>
    /// <remarks>
    /// <c>who</c> -> <c>has-license-for</c> -> <c>what</c>
    /// </remarks>
    /// <seealso cref="ILicensePrincipal"/>
    /// <seealso cref="ILicenseResource"/>
    public interface ILicenseIdentity : IIdentity, IId, IName, IMetadata
    {
    }
}