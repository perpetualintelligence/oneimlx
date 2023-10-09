/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace PerpetualIntelligence.OneImlx.Licensing.Core
{
    /// <summary>
    /// An abstraction to extract the <see cref="ILicense"/>.
    /// </summary>
    public interface ILicenseExtractor
    {
        /// <summary>
        /// Extracts the <see cref="ILicense"/> asynchronously.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<LicenseExtractorResult> ExtractLicenseAsync(LicenseExtractorContext context);

        /// <summary>
        /// Gets the extracted license asynchronously.
        /// </summary>
        public Task<ILicense?> GetAsync();
    }
}