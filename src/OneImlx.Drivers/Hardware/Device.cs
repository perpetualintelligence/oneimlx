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
    /// Represents a hardware device driven by a driver.
    /// </summary>
    /// <param name="id">The unique identifier of the device.</param>
    /// <param name="name">The name of the device.</param>
    /// <param name="description">The description of the device.</param>
    /// <param name="manufacturerId">The device manufacturer.</param>
    /// <param name="metadata">The device metadata.</param>
    /// <remarks>
    /// A device is a typically adapted for a particular purpose, especially a piece of mechanical or electronic component.
    /// </remarks>
    public abstract class Device(string id, string name, string description, string manufacturerId, Dictionary<String, object>? metadata = null) : IHardware, IDisposable
    {
        /// <summary>
        /// Gets the description of the device.
        /// </summary>
        public string Description { get; } = description;

        /// <summary>
        /// Gets the unique identifier of the device.
        /// </summary>
        public string Id { get; } = id;

        /// <summary>
        /// Gets the manufacturer of the hardware component.
        /// </summary>
        public string ManufacturerId { get; } = manufacturerId;

        /// <summary>
        /// The device metadata.
        /// </summary>
        public Dictionary<string, object>? Metadata { get; } = metadata;

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Disposes of the resources used by the device.
        /// </summary>
        public abstract void Dispose();
    }
}
