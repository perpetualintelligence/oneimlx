﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Hosting
{
    /// <summary>
    /// An abstraction of <c>oneimlx</c> service builder.
    /// </summary>
    public interface IOneImlxBuilder
    {
        /// <summary>
        /// The licensing service builder.
        /// </summary>
        ILicensingBuilder Licensing { get; }

        /// <summary>
        /// The IAM service builder.
        /// </summary>
        IIamBuilder Iam { get; }
    }
}