/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneImlx.Abstractions;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Manages hardware and their drivers, including the current driver, historical deployments, and available updates.
    /// </summary>
    /// <typeparam name="THardware">The type of hardware to manage.</typeparam>
    /// <typeparam name="TDriver">The type of drivers to manage.</typeparam>
    /// <remarks>Initializes a new instance of the <see cref="HardwareDrivers{THardware, TDriver}"/> class.</remarks>
    /// <param name="driverRepository">The repository used to pull updates from a remote source.</param>
    public class HardwareDrivers<THardware, TDriver>(IDriverRepository<THardware, TDriver> driverRepository)
        where THardware : IHardware
        where TDriver : IDriver
    {
        /// <summary>
        /// Gets all hardware driver information as an enumerable collection.
        /// </summary>
        /// <returns>An enumerable collection of all hardware driver information.</returns>
        public IEnumerable<HardwareDriver<THardware, TDriver>> GetAll() => _hardwareDrivers.Values.AsEnumerable();

        /// <summary>
        /// Pulls the available updates from a remote source asynchronously.
        /// </summary>
        /// <param name="hardwareId">The ID of the hardware.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="OneImlxException">Thrown when the specified hardware ID does not exist.</exception>
        public async Task PullUpdatesAsync(string hardwareId)
        {
            if (!_hardwareDrivers.TryGetValue(hardwareId, out var hardwareDriver))
            {
                throw new OneImlxException("not_found", "The specified hardware does not exist. hardware={0}", hardwareId);
            }

            var updates = await _driverRepository.PullAsync(hardwareDriver.Hardware);
            foreach (var update in updates)
            {
                hardwareDriver.AddUpdate(update);
            }
        }

        /// <summary>
        /// Adds or updates the current driver for a hardware.
        /// </summary>
        /// <param name="hardware">The hardware instance.</param>
        /// <param name="driver">The driver to add or update.</param>
        /// <returns>True if the driver was added or updated successfully, false otherwise.</returns>
        public bool TryAdd(THardware hardware, TDriver driver)
        {
            var hardwareDriver = new HardwareDriver<THardware, TDriver>(hardware, driver);
            return _hardwareDrivers.TryAdd(hardware.Id, hardwareDriver);
        }

        /// <summary>
        /// Gets the hardware driver information for a specific hardware ID.
        /// </summary>
        /// <param name="hardwareId">The ID of the hardware.</param>
        /// <param name="hardwareDriver">The hardware driver information, if found.</param>
        /// <returns>True if the hardware driver information was found, false otherwise.</returns>
        public bool TryGet(string hardwareId, out HardwareDriver<THardware, TDriver> hardwareDriver) => _hardwareDrivers.TryGetValue(hardwareId, out hardwareDriver);

        /// <summary>
        /// Removes the driver information for a hardware.
        /// </summary>
        /// <param name="hardwareId">The ID of the hardware.</param>
        /// <param name="hardwareDriver">The removed hardware driver information, if found.</param>
        /// <returns>True if the driver information was removed successfully, false otherwise.</returns>
        public bool TryRemove(string hardwareId, out HardwareDriver<THardware, TDriver> hardwareDriver) => _hardwareDrivers.TryRemove(hardwareId, out hardwareDriver);

        private readonly IDriverRepository<THardware, TDriver> _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
        private readonly ConcurrentDictionary<string, HardwareDriver<THardware, TDriver>> _hardwareDrivers = new();
    }
}
