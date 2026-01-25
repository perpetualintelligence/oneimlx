//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction for software that drives a <see cref="IDriver"/>.
    /// </summary>
    public interface ISoftware : IId, IName, IDescription
    {
        /// <summary>
        /// Gets the version of the software component.
        /// </summary>
        IVersion Version { get; }
    }
}