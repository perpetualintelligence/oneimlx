/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing.Core
{
    /// <summary>
    /// The default <see cref="ILicenseChecker"/> result.
    /// </summary>
    public sealed class LicenseProducerResult
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="licenseProducer">The license producer.</param>
        public LicenseProducerResult(ILicenseProducer licenseProducer)
        {
            LicenseProducer = licenseProducer;
        }

        /// <summary>
        /// The license producer.
        /// </summary>
        public ILicenseProducer LicenseProducer { get; }
    }
}
