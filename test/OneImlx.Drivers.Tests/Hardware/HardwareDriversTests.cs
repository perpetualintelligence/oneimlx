/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using OneImlx.Drivers;
using OneImlx.Drivers.Hardware;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OneImlx.Tests
{
    public class HardwareDriversTests
    {
        public HardwareDriversTests()
        {
            _mockDriverRepository = new Mock<IDriverRepository<IHardware, IDriver>>();
            _hardwareDrivers = new HardwareDrivers<IHardware, IDriver>(_mockDriverRepository.Object);
        }

        [Fact]
        public async Task PullUpdatesAsync_ShouldPullUpdatesSuccessfully()
        {
            var mockHardware = new Mock<IHardware>();
            mockHardware.Setup(h => h.Id).Returns("hardware1");
            var mockDriver = new Mock<IDriver>();
            _hardwareDrivers.TryAdd(mockHardware.Object, mockDriver.Object);

            var updates = new List<IDriver> { new Mock<IDriver>().Object, new Mock<IDriver>().Object };
            _mockDriverRepository.Setup(repo => repo.PullAsync(mockHardware.Object)).ReturnsAsync(updates);

            await _hardwareDrivers.PullUpdatesAsync("hardware1");

            _hardwareDrivers.TryGet("hardware1", out var hardwareDriver).Should().BeTrue();
            hardwareDriver.Updates.Should().BeEquivalentTo(updates);
        }

        [Fact]
        public void TryAdd_ShouldAddHardwareDriver()
        {
            var mockHardware = new Mock<IHardware>();
            mockHardware.Setup(h => h.Id).Returns("hardware1");
            var mockDriver = new Mock<IDriver>();

            var result = _hardwareDrivers.TryAdd(mockHardware.Object, mockDriver.Object);

            result.Should().BeTrue();
            _hardwareDrivers.TryGet("hardware1", out var hardwareDriver).Should().BeTrue();
            hardwareDriver.Driver.Should().Be(mockDriver.Object);
            hardwareDriver.Hardware.Should().Be(mockHardware.Object);
        }

        [Fact]
        public void TryGet_ShouldReturnFalseIfHardwareDriverDoesNotExist()
        {
            var result = _hardwareDrivers.TryGet("non_existing_hardware", out var hardwareDriver);

            result.Should().BeFalse();
            hardwareDriver.Should().BeNull();
        }

        [Fact]
        public void TryRemove_ShouldRemoveHardwareDriver()
        {
            var mockHardware = new Mock<IHardware>();
            mockHardware.Setup(h => h.Id).Returns("hardware1");
            var mockDriver = new Mock<IDriver>();
            _hardwareDrivers.TryAdd(mockHardware.Object, mockDriver.Object);

            var result = _hardwareDrivers.TryRemove("hardware1", out var hardwareDriver);

            result.Should().BeTrue();
            hardwareDriver.Should().NotBeNull();
            _hardwareDrivers.TryGet("hardware1", out var _).Should().BeFalse();
        }

        private readonly HardwareDrivers<IHardware, IDriver> _hardwareDrivers;
        private readonly Mock<IDriverRepository<IHardware, IDriver>> _mockDriverRepository;
    }
}
