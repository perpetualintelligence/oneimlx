/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Represents information about a hardware's drivers.
    /// </summary>
    /// <typeparam name="THardware">The type of hardware.</typeparam>
    /// <typeparam name="TDriver">The type of drivers.</typeparam>
    /// <remarks>Initializes a new instance of the <see cref="HardwareDriver{THardware, TDriver}"/> class.</remarks>
    /// <param name="hardware">The hardware instance.</param>
    /// <param name="current">The current driver of the hardware.</param>
    /// <param name="updates">The list of available updates for the hardware's drivers.</param>
    /// <param name="history">
    /// The list of historical drivers for the hardware. If null, it will default to an empty list.
    /// </param>
    public sealed class HardwareDriver<THardware, TDriver>(THardware hardware, TDriver current, List<TDriver>? updates = null, List<TDriver>? history = null) where THardware : IHardware where TDriver : IDriver
    {
        /// <summary>
        /// Gets the current driver of the hardware.
        /// </summary>
        public TDriver Driver { get; private set; } = current;

        /// <summary>
        /// Gets the hardware instance.
        /// </summary>
        public THardware Hardware { get; } = hardware;

        /// <summary>
        /// Gets the list of historical drivers for the hardware.
        /// </summary>
        public IReadOnlyList<TDriver> History => _history.AsReadOnly();

        /// <summary>
        /// Gets the list of available updates for the hardware's drivers.
        /// </summary>
        public IReadOnlyList<TDriver> Updates => _updates.AsReadOnly();

        /// <summary>
        /// Adds an update to the available updates list.
        /// </summary>
        /// <param name="driver">The update to add to the available updates list.</param>
        public void AddUpdate(TDriver driver)
        {
            _updates.Add(driver);
        }

        /// <summary>
        /// Updates the current driver if the specified update exists in the updates list. Moves the current driver to
        /// the historical drivers list.
        /// </summary>
        /// <param name="newDriver">The new driver to set as the current driver.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified update driver does not exist in the updates list.
        /// </exception>
        public void Update(TDriver newDriver)
        {
            if (!_updates.Contains(newDriver))
            {
                throw new OneImlxException("not_found", "The new driver does not exist in the updates list. hardware={0} driver={1}", Hardware, newDriver);
            }

            _history.Add(Driver);
            Driver = newDriver;
            _updates.Remove(newDriver);
        }

        private readonly List<TDriver> _history = history ?? [];
        private readonly List<TDriver> _updates = updates ?? [];
    }
}
