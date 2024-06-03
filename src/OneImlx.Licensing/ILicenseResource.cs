/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensed resource. Establishes the <c>what</c>.
    /// </summary>
    /// <remarks>
    /// <c>who</c> -> <c>has-license-for</c> -> <c>what</c>
    /// </remarks>
    /// <seealso cref="ILicenseIdentity"/>
    /// <seealso cref="ILicensePrincipal"/>
    public interface ILicenseResource : IResource, IMetadata
    {
    }
}