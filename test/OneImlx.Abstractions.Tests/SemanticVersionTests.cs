//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using FluentAssertions;
using OneImlx.Test.FluentAssertions;
using System;
using Xunit;

namespace OneImlx.Abstractions
{
    public class SemanticVersionTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var major = 1;
            var minor = 2;
            var patch = 3;
            var preRelease = "beta";
            var buildMetadata = "build.1";

            var version = new SemanticVersion(major, minor, patch, preRelease, buildMetadata);

            version.Major.Should().Be(major);
            version.Minor.Should().Be(minor);
            version.Patch.Should().Be(patch);
            version.PreRelease.Should().Be(preRelease);
            version.BuildMetadata.Should().Be(buildMetadata);
        }

        [Fact]
        public void Parse_ParsesVersionWithoutSuffixCorrectly()
        {
            var versionString = "1.2.3";

            var version = SemanticVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().BeNull();
            version.BuildMetadata.Should().BeNull();
        }

        [Fact]
        public void Parse_ParsesVersionWithSuffixCorrectly()
        {
            var versionString = "1.2.3-beta.123";

            var version = SemanticVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().Be("beta.123");
            version.BuildMetadata.Should().BeNull();
        }

        [Fact]
        public void Parse_ThrowsArgumentExceptionForInvalidVersionString()
        {
            var invalidVersionString = "invalid.version.string";

            Action act = () => SemanticVersion.Parse(invalidVersionString);

            act.Should().Throw<OneImlxException>()
                .WithErrorCode("invalid_request")
                .WithMessage("The version string format is invalid. version=invalid.version.string");
        }

        [Fact]
        public void Parse_ThrowsArgumentExceptionForNullOrEmptyVersionString()
        {
            Action act1 = () => SemanticVersion.Parse(null!);
            Action act2 = () => SemanticVersion.Parse(string.Empty);

            act1.Should().Throw<ArgumentException>().WithMessage("Version string cannot be null or empty.*");
            act2.Should().Throw<ArgumentException>().WithMessage("Version string cannot be null or empty.*");
        }

        [Theory]
        [InlineData(1, 2, 3, null, null, "1.2.3")]
        [InlineData(1, 2, 3, "alpha", null, "1.2.3-alpha")]
        [InlineData(1, 2, 3, "alpha.1", null, "1.2.3-alpha.1")]
        [InlineData(1, 2, 3, null, "001", "1.2.3+001")]
        [InlineData(1, 2, 3, null, "exp.sha.5114f85", "1.2.3+exp.sha.5114f85")]
        [InlineData(1, 2, 3, "beta.123", "001", "1.2.3-beta.123+001")]
        [InlineData(1, 2, 3, "beta.123", "exp.sha.5114f85", "1.2.3-beta.123+exp.sha.5114f85")]
        public void VersionString_ReturnsCorrectFormat(int major, int minor, int patch, string? prerelease, string? buildMetadata, string expected)
        {
            var version = new SemanticVersion(major, minor, patch, prerelease, buildMetadata);
            version.VersionString().Should().Be(expected);
        }

        [Fact]
        public void ToString_IsSameAsVersionString()
        {
            var version = new SemanticVersion(1, 2, 3, "beta.123", "build.7");
            version.ToString().Should().Be(version.VersionString());
        }

        [Fact]
        public void Parse_IsCaseInsensitive()
        {
            var versionStringLower = "1.2.3-beta.123";
            var versionStringUpper = "1.2.3-BETA.123";
            var versionStringMixed = "1.2.3-BeTa.123";

            var versionLower = SemanticVersion.Parse(versionStringLower);
            var versionUpper = SemanticVersion.Parse(versionStringUpper);
            var versionMixed = SemanticVersion.Parse(versionStringMixed);

            versionLower.Major.Should().Be(versionUpper.Major);
            versionLower.Minor.Should().Be(versionUpper.Minor);
            versionLower.Patch.Should().Be(versionUpper.Patch);
            versionLower.PreRelease!.ToLower().Should().Be(versionUpper.PreRelease!.ToLower());

            versionLower.Major.Should().Be(versionMixed.Major);
            versionLower.Minor.Should().Be(versionMixed.Minor);
            versionLower.Patch.Should().Be(versionMixed.Patch);
            versionLower.PreRelease!.ToLower().Should().Be(versionMixed.PreRelease!.ToLower());
        }

        [Theory]
        [InlineData("  1.2.3-beta.123")]
        [InlineData("1.2.3-beta.123  ")]
        [InlineData("  1.2.3-beta.123  ")]
        [InlineData("\t1.2.3-beta.123")]
        [InlineData("1.2.3-beta.123\t")]
        [InlineData("\t1.2.3-beta.123\t")]
        [InlineData("1. 2.  3-beta.123")]
        [InlineData(" 1.2.3 -beta.123 ")]
        public void Parse_IgnoresWhitespace(string versionString)
        {
            var version = SemanticVersion.Parse(versionString.Trim());

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().Be("beta.123");
            version.BuildMetadata.Should().BeNull();
        }

        [Fact]
        public void Parse_AcceptsSpaceInSuffix()
        {
            var versionString = "1.2.3-beta .1  23";
            var version = SemanticVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().Be("beta .1  23");
            version.BuildMetadata.Should().BeNull();
        }

        [Fact]
        public void Parse_AcceptsLeadingZerosInVersionNumbers()
        {
            var versionString = "01.002.0003-beta.123";
            var version = SemanticVersion.Parse(versionString);
            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().Be("beta.123");
            version.BuildMetadata.Should().BeNull();
        }

        [Fact]
        public void Parse_ThrowsArgumentExceptionForIncompleteVersionString()
        {
            var incompleteVersionString1 = "1.2";
            var incompleteVersionString2 = "1";
            Action act1 = () => SemanticVersion.Parse(incompleteVersionString1);
            Action act2 = () => SemanticVersion.Parse(incompleteVersionString2);
            act1.Should().Throw<OneImlxException>().WithErrorCode("invalid_request").WithMessage("The version string format is invalid. version=1.2");
            act2.Should().Throw<OneImlxException>().WithErrorCode("invalid_request").WithMessage("The version string format is invalid. version=1");
        }

        [Theory]
        [InlineData("1.2.3", "1.2.3")]
        [InlineData("1.2.3-beta.123", "1.2.3-beta.123")]
        [InlineData("1.2.3-BETA.123", "1.2.3-beta.123")]
        [InlineData("1.2.3-beta.123", "1.2.3-BETA.123")]
        public void Parse_EqualsCaseInsensitive(string v1, string v2)
        {
            var version1 = SemanticVersion.Parse(v1);
            var version2 = SemanticVersion.Parse(v2);

            version1.Should().Be(version2);
            version1.Should().NotBeSameAs(version2);
        }

        [Fact]
        public void Parse_ParsesVersionWithBuildMetadataCorrectly()
        {
            var versionString = "1.2.3+build.7";

            var version = SemanticVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().BeNull();
            version.BuildMetadata.Should().Be("build.7");
        }

        [Fact]
        public void Parse_ParsesVersionWithPreReleaseAndBuildMetadataCorrectly()
        {
            var versionString = "1.2.3-beta.123+build.7";

            var version = SemanticVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.PreRelease.Should().Be("beta.123");
            version.BuildMetadata.Should().Be("build.7");
        }

        [Fact]
        public void ToString_ReturnsCorrectFormatWithBuildMetadataOnly()
        {
            var version = new SemanticVersion(1, 0, 0, null, "build.7");
            var result = version.ToString();
            result.Should().Be("1.0.0+build.7");
        }

        [Fact]
        public void ToString_ReturnsCorrectFormatWithPreReleaseAndBuildMetadata()
        {
            var version = new SemanticVersion(1, 0, 0, "beta.123", "build.7");
            var result = version.ToString();
            result.Should().Be("1.0.0-beta.123+build.7");
        }

        [Theory]
        [InlineData("1.2.3+BUILD.7", "1.2.3+build.7")]
        [InlineData("1.2.3-beta.123+BUILD.7", "1.2.3-beta.123+build.7")]
        public void Parse_EqualsCaseInsensitive_BuildMetadata(string v1, string v2)
        {
            var version1 = SemanticVersion.Parse(v1);
            var version2 = SemanticVersion.Parse(v2);

            version1.Should().Be(version2);
            version1.Should().NotBeSameAs(version2);
        }

        [Fact]
        public void NegativeVersionNumbersThrows()
        {
#pragma warning disable CA1806 // Do not ignore method results
            Action act1 = () => new SemanticVersion(-1, 0, 0);
            Action act2 = () => new SemanticVersion(0, -1, 0);
            Action act3 = () => new SemanticVersion(0, 0, -1);
            act1.Should().Throw<ArgumentException>().WithMessage("Version numbers must be non-negative.");
            act2.Should().Throw<ArgumentException>().WithMessage("Version numbers must be non-negative.");
            act3.Should().Throw<ArgumentException>().WithMessage("Version numbers must be non-negative.");
#pragma warning restore CA1806 // Do not ignore method results
        }

        [Fact]
        public void PrereleaseAndBuildMetadataCannotContainReservedCharacters()
        {
#pragma warning disable CA1806 // Do not ignore method results
            Action act1 = () => new SemanticVersion(1, 0, 0, "alpha+beta", null);
            Action act2 = () => new SemanticVersion(1, 0, 0, null, "build-beta");
            Action act3 = () => new SemanticVersion(1, 0, 0, "alpha-beta", null);
            Action act4 = () => new SemanticVersion(1, 0, 0, null, "build+beta");

            act1.Should().Throw<ArgumentException>().WithMessage("Pre-release version must not contain '-' or '+'.*").And.ParamName.Should().Be("preRelease");
            act2.Should().Throw<ArgumentException>().WithMessage("Build metadata must not contain '-' or '+'.*").And.ParamName.Should().Be("buildMetadata");
            act3.Should().Throw<ArgumentException>().WithMessage("Pre-release version must not contain '-' or '+'.*").And.ParamName.Should().Be("preRelease");
            act4.Should().Throw<ArgumentException>().WithMessage("Build metadata must not contain '-' or '+'.*").And.ParamName.Should().Be("buildMetadata");
#pragma warning restore CA1806 // Do not ignore method results
        }
    }
}