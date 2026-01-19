//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Abstractions
{
    /// <summary>
    /// An abstraction of a version.
    /// </summary>
    public interface IVersion
    {
        /// <summary>
        /// Gets the version string.
        /// </summary>
        string VersionString();
    }
}