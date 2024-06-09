/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Principal;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensing <see cref="IPrincipal"/>. Establishes the <c>has-license-for</c>.
    /// </summary>
    /// <remarks>
    /// <para><c>who</c> -&gt; <c>has-license-for</c> -&gt; <c>what</c></para>
    /// <para>
    /// A <see cref="ILicensePrincipal"/> represents the security context of the entity on whose behalf the code is
    /// running, including that entity's <see cref="ILicenseIdentity"/> and any roles to which they belong.
    /// </para>
    /// </remarks>
    /// <seealso cref="ILicenseIdentity"/>
    /// <seealso cref="ILicenseResource"/>
    public interface ILicensePrincipal : IPrincipal
    {
        /// <summary>
        /// Gets a collection that contains all of the identities associated with this principal.
        /// </summary>
        IEnumerable<ILicenseIdentity> Identities { get; }
    }
}
