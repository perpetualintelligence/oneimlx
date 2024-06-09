/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Hosting
{
    /// <summary>
    /// An abstraction of <c>oneimlx</c> service builder.
    /// </summary>
    public interface IOneImlxBuilder
    {
        /// <summary>
        /// The IAM service builder.
        /// </summary>
        IIamBuilder Iam { get; }

        /// <summary>
        /// The licensing service builder.
        /// </summary>
        ILicensingBuilder Licensing { get; }
    }
}
