//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System;
using System.Text;

namespace OneImlx.Abstractions
{
    /// <summary>
    /// Version class based on the semantic versioning specification (SemVer 2.0.0).
    /// </summary>
    /// <remarks>
    /// Versions are parsed and formatted using a canonical string representation. This implementation performs
    /// basic structural validation only and does not strictly enforce all SemVer 2.0.0 rules (e.g., identifier grammar,
    /// numeric leading-zero rules, or precedence ordering). Equality and hashing are value-based and case-insensitive
    /// for pre-release and build metadata. For strict SemVer 2.0.0 adherence, implement a custom <see cref="ISemanticVersion"/> with full validation rules.
    /// </remarks>
    public sealed class SemanticVersion : IVersion, IEquatable<SemanticVersion>
    {
        /// <summary>
        /// Gets the build metadata.
        /// </summary>
        public string? BuildMetadata { get; }

        /// <summary>
        /// Gets the major version number.
        /// </summary>
        public int Major { get; }

        /// <summary>
        /// Gets the minor version number.
        /// </summary>
        public int Minor { get; }

        /// <summary>
        /// Gets the patch version number.
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// Gets the pre-release version label.
        /// </summary>
        public string? PreRelease { get; }

        /// <summary>
        /// Gets the version string.
        /// </summary>
        public string VersionString()
        {
            var preRelease = PreRelease != null ? $"-{PreRelease}" : string.Empty;
            var buildMetadata = BuildMetadata != null ? $"+{BuildMetadata}" : string.Empty;
            return $"{Major}.{Minor}.{Patch}{preRelease}{buildMetadata}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticVersion"/> class.
        /// </summary>
        /// <param name="major">The major version number.</param>
        /// <param name="minor">The minor version number.</param>
        /// <param name="patch">The patch version number.</param>
        /// <param name="preRelease">The optional pre-release label.</param>
        /// <param name="buildMetadata">The optional build metadata.</param>
        /// <remarks>
        /// Non-negative integers are required for major, minor, and patch version numbers.
        /// Pre-release and build metadata must not contain '-' or '+' to preserve an unambiguous version format.
        /// </remarks>
        public SemanticVersion(int major, int minor, int patch, string? preRelease = null, string? buildMetadata = null)
        {
            // Enforce strict semantic constraints
            CheckVersions(major, minor, patch);
            CheckPreRelease(preRelease);
            CheckBuildMetadata(buildMetadata);

            BuildMetadata = buildMetadata;
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
        }

        private void CheckVersions(int major, int minor, int patch)
        {
            if (major < 0 || minor < 0 || patch < 0)
            {
                throw new ArgumentOutOfRangeException("Version numbers must be non-negative.");
            }
        }

        /// <summary>
        /// Parses a version string into a <see cref="SemanticVersion"/> instance.
        /// </summary>
        /// <param name="version">The version string to parse.</param>
        /// <returns>A new <see cref="SemanticVersion"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
        public static SemanticVersion Parse(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new ArgumentException("Version string cannot be null or empty.", nameof(version));
            }

            var main = new StringBuilder();
            var pre = new StringBuilder();
            var meta = new StringBuilder();

            // 0 = MAIN, 1 = PRERELEASE, 2 = METADATA
            int state = 0;
            for (int idx = 0; idx < version.Length; ++idx)
            {
                char c = version[idx];
                if (c == '-' && state == 0)
                {
                    state = 1;
                    continue;
                }

                if (c == '+' && state != 2)
                {
                    state = 2;
                    continue;
                }

                if (state == 0)
                {
                    main.Append(c);
                }
                else if (state == 1)
                {
                    pre.Append(c);
                }
                else
                {
                    meta.Append(c);
                }
            }

            var parts = main.ToString().Split('.');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out var major) ||
                !int.TryParse(parts[1], out var minor) ||
                !int.TryParse(parts[2], out var patch))
            {
                throw new OneImlxException(
                    "invalid_request",
                    "The version string format is invalid. version={0}",
                    version);
            }

            var preRelease = pre.Length > 0 ? pre.ToString() : null;
            var buildMetadata = meta.Length > 0 ? meta.ToString() : null;

            return new SemanticVersion(major, minor, patch, preRelease, buildMetadata);
        }

        /// <summary>
        /// Returns the string representation of the version.
        /// </summary>
        /// <returns>The version string as returned by <see cref="VersionString"/></returns>
        public override string ToString()
        {
            return VersionString();
        }

        /// <summary>
        /// Determines if the specified <see cref="SemanticVersion"/> is equal to the current instance.
        /// </summary>
        /// <param name="other">The <see cref="SemanticVersion"/> to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified <see cref="SemanticVersion"/> is equal to the current instance; otherwise, <c>false</c>.</returns>
        /// <inheritdoc />
        public bool Equals(SemanticVersion? other)
        {
            if (other is null)
            {
                return false;
            }

            return Major == other.Major &&
                   Minor == other.Minor &&
                   Patch == other.Patch &&
                   string.Equals(PreRelease, other.PreRelease, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(BuildMetadata, other.BuildMetadata, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines if the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => Equals(obj as SemanticVersion);

        /// <summary>
        /// Returns the hash code for the current instance.
        /// </summary>
        /// <returns>The hash code for the current instance.</returns>
        public override int GetHashCode()
        {
#if NETSTANDARD2_1_OR_GREATER
            return HashCode.Combine(
                Major,
                Minor,
                Patch,
                PreRelease != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(PreRelease) : 0,
                BuildMetadata != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(BuildMetadata) : 0);
#else
            unchecked
            {
                int hash = 17;
                hash = (hash * 31) + Major;
                hash = (hash * 31) + Minor;
                hash = (hash * 31) + Patch;
                hash = (hash * 31) + (PreRelease != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(PreRelease) : 0);
                hash = (hash * 31) + (BuildMetadata != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(BuildMetadata) : 0);
                return hash;
            }
#endif
        }

        /// <summary>
        /// Determines if two specified instances of <see cref="SemanticVersion"/> are equal.
        /// </summary>
        /// <param name="left">The first <see cref="SemanticVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="SemanticVersion"/> to compare.</param>
        /// <returns><c>true</c> if the two instances are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SemanticVersion? left, SemanticVersion? right) =>
            left?.Equals(right) ?? right is null;

        /// <summary>
        /// Determines if two specified instances of <see cref="SemanticVersion"/> are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="SemanticVersion"/> to compare.</param>
        /// <param name="right">The second <see cref="SemanticVersion"/> to compare.</param>
        /// <returns><c>true</c> if the two instances are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(SemanticVersion? left, SemanticVersion? right) =>
            !(left == right);

        private void CheckPreRelease(string? preRelease)
        {
            if (preRelease != null && (preRelease.Contains("-") || preRelease.Contains("+")))
            {
                throw new ArgumentException("Pre-release version must not contain '-' or '+'.", nameof(preRelease));
            }
        }

        private void CheckBuildMetadata(string? buildMetadata)
        {
            if (buildMetadata != null && (buildMetadata.Contains("-") || buildMetadata.Contains("+")))
            {
                throw new ArgumentException("Build metadata must not contain '-' or '+'.", nameof(buildMetadata));
            }
        }
    }
}