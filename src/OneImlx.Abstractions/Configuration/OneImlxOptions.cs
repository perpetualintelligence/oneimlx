/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Abstractions.Configuration.Iam;
using OneImlx.Abstractions.Configuration.Licensing;

namespace OneImlx.Abstractions.Configuration
{
    /// <summary>
    /// The <c>oneimlx</c> configuration options.
    /// </summary>
    public sealed class OneImlxOptions
    {
        /// <summary>
        /// The <c>IAM</c> configuration options.
        /// </summary>
        public IamOptions Iam { get; } = new IamOptions();

        /// <summary>
        /// The licensing configuration options.
        /// </summary>
        public LicensingOptions Licensing { get; } = new LicensingOptions();
    }
}
