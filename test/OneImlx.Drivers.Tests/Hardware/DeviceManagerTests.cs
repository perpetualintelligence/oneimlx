/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using Xunit;

namespace OneImlx.Drivers.Hardware
{
    public class DeviceManagerTests
    {
        [Fact]
        public void DeviceManager_Manages_Device()
        {
            var manager = new DeviceManager();
            var mockDevice = new Mock<IDevice>();
            mockDevice.Setup(d => d.Id).Returns("test_id");

            // Add a device
            var addResult = manager.TryAdd(mockDevice.Object);
            addResult.Should().BeTrue();

            // Verify the device is managed by DeviceManager
            bool getResult = manager.TryGet(mockDevice.Object.Id, out IDevice? retrievedDevice);
            getResult.Should().BeTrue();
            retrievedDevice.Should().BeSameAs(mockDevice.Object);
        }
    }
}
