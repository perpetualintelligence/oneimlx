/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx
{
    /// <summary>
    /// Represents a package version following the semantic version specification.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="PackageVersion"/> class.</remarks>
    /// <param name="major">The major version number.</param>
    /// <param name="minor">The minor version number.</param>
    /// <param name="patch">The patch version number.</param>
    /// <param name="suffix">The optional suffix for the version.</param>
    public class PackageVersion(int major, int minor, int patch, string? suffix = null) : IVersion
    {
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
        /// Gets the optional suffix for the version.
        /// </summary>
        public string? Suffix { get; } = suffix;

        /// <summary>
        /// Parses a version string into a <see cref="PackageVersion"/> instance.
        /// </summary>
        /// <param name="version">The version string to parse.</param>
        /// <returns>A new <see cref="PackageVersion"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
        public static PackageVersion Parse(string version)
        {
            if (string.IsNullOrEmpty(version))
                throw new ArgumentException("Version string cannot be null or empty.", nameof(version));

            var dashIndex = version.IndexOf('-');
            var mainPart = dashIndex >= 0 ? version.Substring(0, dashIndex) : version;
            var suffix = dashIndex >= 0 ? version.Substring(dashIndex + 1) : null;

            var parts = mainPart.Split('.');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out var major) ||
                !int.TryParse(parts[1], out var minor) ||
                !int.TryParse(parts[2], out var patch))
            {
                throw new OneImlxException("invalid_request", "The version string format is invalid. version={0}", version);
            }

            return new PackageVersion(major, minor, patch, suffix);
        }

        /// <summary>
        /// Returns the string representation of the version.
        /// </summary>
        /// <returns>The version as a string.</returns>
        public override string ToString()
        {
            return Suffix != null ? $"{Major}.{Minor}.{Patch}-{Suffix}" : $"{Major}.{Minor}.{Patch}";
        }
    }
}
