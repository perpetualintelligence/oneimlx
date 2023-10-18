/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Define a licensing <see cref="IPrincipal"/>. Establishes the <c>has-license-for</c>.
    /// </summary>
    /// <remarks>
    /// <c>who</c> -> <c>has-license-for</c> -> <c>what</c>
    /// </remarks>
    /// <seealso cref="ILicenseIdentity"/>
    /// <seealso cref="ILicenseResource"/>
    public interface ILicensePrincipal : IPrincipal
    {
        /// <summary>
        /// Gets a collection that contains all of the identities associated with this  principal.
        /// </summary>
        IEnumerable<ILicenseIdentity> Identities { get; }
    }
}