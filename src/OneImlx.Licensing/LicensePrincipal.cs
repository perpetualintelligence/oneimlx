/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// A <see cref="ClaimsPrincipal"/> implementation that supports multiple claims-based <see cref="LicenseIdentity"/>.
    /// </summary>
    public class LicensePrincipal : ClaimsPrincipal
    {
    }
}