﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using PerpetualIntelligence.OneImlx.Configuration.Iam;
using PerpetualIntelligence.OneImlx.Configuration.Licensing;

namespace PerpetualIntelligence.OneImlx.Configuration
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