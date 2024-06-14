/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Represents a hardware equipment that specifies the necessary components for a particular purpose. An equipment
    /// is a type of hardware that is used to perform a specific task or function and may have a collection of drivers
    /// that are used to interact with multiple components within an equipment.
    /// </summary>
    public interface IEquipment : IHardware
    {
        /// <summary>
        /// The collection of devices within the equipment.
        /// </summary>
        IReadOnlyDictionary<string, IDevice>? Devices { get; }

        /// <summary>
        /// The equipment metadata.
        /// </summary>
        Dictionary<string, object>? Metadata { get; }
    }
}
