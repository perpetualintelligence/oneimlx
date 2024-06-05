/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Moq;
using OneImlx.Drivers.Hardware;
using Xunit;

namespace OneImlx.Tests
{
    public class DeviceManagerTests
    {
        [Fact]
        public void DeviceManager_Manages_Device()
        {
            var manager = new DeviceManager();
            var mockDevice = new Mock<Device>("1", "Device1", "Description1", "Manufacturer1", null);

            // Add a device
            var addResult = manager.Add(mockDevice.Object);
            addResult.Should().BeTrue();

            // Verify the device is managed by DeviceManager
            bool getResult = manager.TryGet(mockDevice.Object.Id, out Device? retrievedDevice);
            getResult.Should().BeTrue();
            retrievedDevice.Should().Be(mockDevice.Object);
        }
    }
}
