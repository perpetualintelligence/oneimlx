/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Abstractions;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensed resource. Establishes the <c>what</c>.
    /// </summary>
    /// <remarks><c>who</c> -&gt; <c>has-license-for</c> -&gt; <c>what</c></remarks>
    /// <seealso cref="ILicenseIdentity"/>
    /// <seealso cref="ILicensePrincipal"/>
    public interface ILicenseResource : IResource, IMetadata
    {
    }
}
