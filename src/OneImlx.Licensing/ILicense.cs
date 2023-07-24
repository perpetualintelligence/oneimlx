/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// An abstraction of a license.
    /// </summary>
    public interface ILicense
    {
        /// <summary>
        /// The principal associated with this license.
        /// </summary>
        LicensePrincipal Principal { get; }
    }
}