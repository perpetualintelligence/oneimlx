/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using OneImlx.Test.FluentAssertions;
using System;
using Xunit;

namespace OneImlx.Tests
{
    public class PackageVersionTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var major = 1;
            var minor = 2;
            var patch = 3;
            var suffix = "beta";

            var version = new PackageVersion(major, minor, patch, suffix);

            version.Major.Should().Be(major);
            version.Minor.Should().Be(minor);
            version.Patch.Should().Be(patch);
            version.Suffix.Should().Be(suffix);
        }

        [Fact]
        public void ToString_ReturnsCorrectFormatWithoutSuffix()
        {
            var version = new PackageVersion(1, 0, 0);

            var result = version.ToString();

            result.Should().Be("1.0.0");
        }

        [Fact]
        public void ToString_ReturnsCorrectFormatWithSuffix()
        {
            var version = new PackageVersion(1, 0, 0, "beta.123");

            var result = version.ToString();

            result.Should().Be("1.0.0-beta.123");
        }

        [Fact]
        public void Parse_ParsesVersionWithoutSuffixCorrectly()
        {
            var versionString = "1.2.3";

            var version = PackageVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.Suffix.Should().BeNull();
        }

        [Fact]
        public void Parse_ParsesVersionWithSuffixCorrectly()
        {
            var versionString = "1.2.3-beta.123";

            var version = PackageVersion.Parse(versionString);

            version.Major.Should().Be(1);
            version.Minor.Should().Be(2);
            version.Patch.Should().Be(3);
            version.Suffix.Should().Be("beta.123");
        }

        [Fact]
        public void Parse_ThrowsArgumentExceptionForInvalidVersionString()
        {
            var invalidVersionString = "invalid.version.string";

            Action act = () => PackageVersion.Parse(invalidVersionString);

            act.Should().Throw<OneImlxException>().WithErrorCode("invalid_request").WithMessage("The version string format is invalid. version=invalid.version.string");
        }

        [Fact]
        public void Parse_ThrowsArgumentExceptionForNullOrEmptyVersionString()
        {
            Action act1 = () => PackageVersion.Parse(null);
            Action act2 = () => PackageVersion.Parse(string.Empty);

            act1.Should().Throw<ArgumentException>().WithMessage("Version string cannot be null or empty.*");
            act2.Should().Throw<ArgumentException>().WithMessage("Version string cannot be null or empty.*");
        }
    }
}
