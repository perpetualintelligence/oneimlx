/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Licensing
{
    /// <summary>
    /// An abstraction of a disposable license provider.
    /// </summary>
    /// <remarks><see cref="ILicenseProvider"/> is an entity such as a license file that provides a <see cref="Licensing.License"/>.</remarks>
    public interface ILicenseProvider : IDisposable
    {
        /// <summary>
        /// The license.
        /// </summary>
        public License License { get; }
    }
}
