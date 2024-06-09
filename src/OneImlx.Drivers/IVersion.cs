/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction of a driver semantic version.
    /// </summary>
    /// <remarks>The standard convention for semantic version is defined at https://semver.org. We recommend <c>{Major}.{Minor}.{Patch}-{PreRelease}+{BuildMetadata}</c></remarks>
    public interface IDriverVersion
    {
        /// <summary>
        /// Gets the build metadata.
        /// </summary>
        string BuildMetadata { get; }

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

        /// <summary>
        /// Gets the pre-release version label.
        /// </summary>
        string PreRelease { get; }
    }
}
