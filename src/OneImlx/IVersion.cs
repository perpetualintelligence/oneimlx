/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx
{
    /// <summary>
    /// An abstraction of a version.
    /// </summary>
    public interface IVersion
    {
        /// <summary>
        /// Gets the major version number.
        /// </summary>
        int Major { get; }

        /// <summary>
        /// Gets the minor version number.
        /// </summary>
        int Minor { get; }

        /// <summary>
        /// Gets the patch version number.
        /// </summary>
        int Patch { get; }
    }
}
