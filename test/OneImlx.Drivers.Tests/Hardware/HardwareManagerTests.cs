/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using OneImlx.Drivers.Hardware;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Drivers.Tests
{
    public class HardwareManagerTests
    {
        [Fact]
        public void Add_AddsHardwareComponent_Correctly()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(h => h.Id).Returns("hw1");
            var manager = new HardwareManager<IHardware>();

            var result = manager.TryAdd(hardwareMock.Object);

            result.Should().BeTrue();
            manager.All().Should().ContainKey("hw1").WhoseValue.Should().Be(hardwareMock.Object);
        }

        [Fact]
        public void All_ReturnsImmutableDictionary_WithAllComponents()
        {
            var hardwareMock1 = new Mock<IHardware>();
            hardwareMock1.SetupGet(h => h.Id).Returns("hw1");
            var hardwareMock2 = new Mock<IHardware>();
            hardwareMock2.SetupGet(h => h.Id).Returns("hw2");

            var manager = new HardwareManager<IHardware>();
            manager.TryAdd(hardwareMock1.Object);
            manager.TryAdd(hardwareMock2.Object);

            var allHardware = manager.All();

            allHardware.Should().HaveCount(2);
            allHardware.Should().ContainKey("hw1").WhoseValue.Should().Be(hardwareMock1.Object);
            allHardware.Should().ContainKey("hw2").WhoseValue.Should().Be(hardwareMock2.Object);
        }

        [Fact]
        public void ConcurrentOperations_WorkCorrectly()
        {
            var hardwareMocks = new ConcurrentDictionary<string, Mock<IHardware>>();
            var manager = new HardwareManager<IHardware>();

            Parallel.For(0, 1000, i =>
            {
                var hardwareMock = new Mock<IHardware>();
                hardwareMock.SetupGet(h => h.Id).Returns($"hw{i}");
                hardwareMocks.TryAdd($"hw{i}", hardwareMock);
                manager.TryAdd(hardwareMock.Object);
            });

            Parallel.For(0, 1000, i =>
            {
                manager.TryGet($"hw{i}", out var hardware).Should().BeTrue();
                hardware.Should().Be(hardwareMocks[$"hw{i}"].Object);
            });

            Parallel.For(0, 1000, i =>
            {
                manager.TryRemove($"hw{i}", out var hardware).Should().BeTrue();
                hardware.Should().Be(hardwareMocks[$"hw{i}"].Object);
            });

            manager.All().Should().BeEmpty();
        }

        [Fact]
        public void TryGet_ReturnsFalse_WhenComponentDoesNotExist()
        {
            var manager = new HardwareManager<IHardware>();

            var result = manager.TryGet("hw1", out var retrievedHardware);

            result.Should().BeFalse();
            retrievedHardware.Should().BeNull();
        }

        [Fact]
        public void TryGet_ReturnsTrueAndHardware_WhenComponentExists()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(h => h.Id).Returns("hw1");
            var manager = new HardwareManager<IHardware>();
            manager.TryAdd(hardwareMock.Object);

            var result = manager.TryGet("hw1", out var retrievedHardware);

            result.Should().BeTrue();
            retrievedHardware.Should().Be(hardwareMock.Object);
        }

        [Fact]
        public void TryRemove_ReturnsFalse_WhenComponentDoesNotExist()
        {
            var manager = new HardwareManager<IHardware>();

            var result = manager.TryRemove("hw1", out var removedHardware);

            result.Should().BeFalse();
            removedHardware.Should().BeNull();
        }

        [Fact]
        public void TryRemove_ReturnsTrueAndHardware_WhenComponentExists()
        {
            var hardwareMock = new Mock<IHardware>();
            hardwareMock.SetupGet(h => h.Id).Returns("hw1");
            var manager = new HardwareManager<IHardware>();
            manager.TryAdd(hardwareMock.Object);

            var result = manager.TryRemove("hw1", out var removedHardware);

            result.Should().BeTrue();
            removedHardware.Should().Be(hardwareMock.Object);
            manager.All().Should().NotContainKey("hw1");
        }
    }
}
