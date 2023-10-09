/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using Microsoft.Extensions.DependencyInjection;

namespace PerpetualIntelligence.OneImlx.Hosting
{
    /// <summary>
    /// An abstraction of <c>oneimlx</c> licensing service builder.
    /// </summary>
    public interface ILicensingBuilder
    {
        /// <summary>
        /// The host service collection.
        /// </summary>
        IServiceCollection Services { get; }
    }
}