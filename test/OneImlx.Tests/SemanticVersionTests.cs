/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Xunit;

namespace OneImlx
{
    public class SemanticVersionTests
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 3;
            var preRelease = "beta";
            var buildMetadata = "build123";

            // Act
            var version = new SemanticVersion(major, minor, patch, preRelease, buildMetadata);

            // Assert
            version.Major.Should().Be(major);
            version.Minor.Should().Be(minor);
            version.Patch.Should().Be(patch);
            version.PreRelease.Should().Be(preRelease);
            version.BuildMetadata.Should().Be(buildMetadata);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormatWithBuildMetadata()
        {
            // Arrange
            var major = 1;
            var minor = 0;
            var patch = 0;
            var buildMetadata = "build123";
            var version = new SemanticVersion(major, minor, patch, buildMetadata: buildMetadata);

            // Act
            var result = version.ToString();

            // Assert
            result.Should().Be("1.0.0+build123");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormatWithoutPreReleaseAndBuildMetadata()
        {
            // Arrange
            var major = 1;
            var minor = 0;
            var patch = 0;
            var version = new SemanticVersion(major, minor, patch);

            // Act
            var result = version.ToString();

            // Assert
            result.Should().Be("1.0.0");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormatWithPreRelease()
        {
            // Arrange
            var major = 1;
            var minor = 0;
            var patch = 0;
            var preRelease = "beta";
            var version = new SemanticVersion(major, minor, patch, preRelease);

            // Act
            var result = version.ToString();

            // Assert
            result.Should().Be("1.0.0-beta");
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormatWithPreReleaseAndBuildMetadata()
        {
            // Arrange
            var major = 1;
            var minor = 0;
            var patch = 0;
            var preRelease = "beta";
            var buildMetadata = "build123";
            var version = new SemanticVersion(major, minor, patch, preRelease, buildMetadata);

            // Act
            var result = version.ToString();

            // Assert
            result.Should().Be("1.0.0-beta+build123");
        }
    }
}
