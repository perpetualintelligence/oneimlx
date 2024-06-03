/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// An abstraction to check <see cref="License"/> instance.
    /// </summary>
    public interface ILicenseChecker
    {
        /// <summary>
        /// Checks <see cref="License"/> asynchronously.
        /// </summary>
        /// <param name="context">The license check context.</param>
        /// <returns>The <see cref="LicenseCheckerResult"/> instance.</returns>
        public Task<LicenseCheckerResult> CheckLicenseAsync(LicenseCheckerContext context);
    }
}