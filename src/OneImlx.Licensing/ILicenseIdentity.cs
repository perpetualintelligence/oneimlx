﻿/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Principal;
using OneImlx.Abstractions;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Defines a licensing identity. Establishes the <c>who</c>.
    /// </summary>
    /// <remarks><c>who</c> -&gt; <c>has-license-for</c> -&gt; <c>what</c></remarks>
    /// <seealso cref="ILicensePrincipal"/>
    /// <seealso cref="ILicenseResource"/>
    public interface ILicenseIdentity : IIdentity, IId, IName, IMetadata
    {
    }
}
