/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx
{
    /// <summary>
    /// Represents a semantic version.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="SemanticVersion"/> class.</remarks>
    /// <param name="major">The major version number.</param>
    /// <param name="minor">The minor version number.</param>
    /// <param name="patch">The patch version number.</param>
    /// <param name="preRelease">The pre-release version label.</param>
    /// <param name="buildMetadata">The build metadata.</param>
    public sealed class SemanticVersion(int major, int minor, int patch, string? preRelease = null, string? buildMetadata = null) : IVersion
    {
        /// <summary>
        /// Gets the build metadata.
        /// </summary>
        public string? BuildMetadata { get; } = buildMetadata;

        /// <summary>
        /// Gets the major version number.
        /// </summary>
        public int Major { get; } = major;

        /// <summary>
        /// Gets the minor version number.
        /// </summary>
        public int Minor { get; } = minor;

        /// <summary>
        /// Gets the patch version number.
        /// </summary>
        public int Patch { get; } = patch;

        /// <summary>
        /// Gets the pre-release version label.
        /// </summary>
        public string? PreRelease { get; } = preRelease;

        /// <summary>
        /// Returns the string representation of the version.
        /// </summary>
        /// <returns>The version as a string.</returns>
        public override string ToString()
        {
            var version = $"{Major}.{Minor}.{Patch}";
            if (!string.IsNullOrEmpty(PreRelease))
            {
                version += $"-{PreRelease}";
            }
            if (!string.IsNullOrEmpty(BuildMetadata))
            {
                version += $"+{BuildMetadata}";
            }
            return version;
        }
    }
}
