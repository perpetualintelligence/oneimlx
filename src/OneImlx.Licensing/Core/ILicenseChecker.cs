/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using PerpetualIntelligence.OneImlx.Licensing.Services;
using System.Threading.Tasks;

namespace PerpetualIntelligence.OneImlx.Licensing.Core
{
    /// <summary>
    /// An abstraction to check <see cref="ILicense"/> instance.
    /// </summary>
    public interface ILicenseChecker
    {
        /// <summary>
        /// Checks <see cref="ILicense"/> asynchronously.
        /// </summary>
        /// <param name="context">The license check context.</param>
        /// <returns>The <see cref="LicenseCheckerResult"/> instance.</returns>
        public Task<LicenseCheckerResult> CheckAsync(LicenseCheckerContext context);
    }
}