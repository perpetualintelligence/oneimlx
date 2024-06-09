/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using Microsoft.Extensions.DependencyInjection;

namespace OneImlx.Hosting
{
    /// <summary>
    /// An abstraction of <c>oneimlx</c> IAM service builder.
    /// </summary>
    public interface IIamBuilder
    {
        /// <summary>
        /// The host service collection.
        /// </summary>
        IServiceCollection Services { get; }
    }
}
