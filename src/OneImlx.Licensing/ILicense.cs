﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// An abstraction of a disposable license.
    /// </summary>
    /// <seealso cref="LicensePrincipal"/>
    public interface ILicense : IDisposable
    {
        /// <summary>
        /// The principal associated with this license.
        /// </summary>
        LicensePrincipal Principal { get; }
    }
}