﻿/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// An abstraction to produce the <see cref="ILicenseProvider"/>.
    /// </summary>
    public interface ILicenseProducer
    {
        /// <summary>
        /// Produces the <see cref="ILicenseProvider"/> asynchronously.
        /// </summary>
        /// <param name="context">The license producer context.</param>
        /// <returns>The <see cref="LicenseProducerResult"/> instance.</returns>
        public Task<LicenseExtractorResult> ProduceLicenseAsync(LicenseProducerContext context);
    }
}
