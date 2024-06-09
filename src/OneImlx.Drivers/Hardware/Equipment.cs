/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Represents a hardware equipment that specifies the necessary components for a particular purpose.
    /// </summary>
    /// <param name="id">The unique identifier of the equipment.</param>
    /// <param name="name">The name of the equipment.</param>
    /// <param name="description">The description of the equipment.</param>
    /// <param name="manufacturerId">The equipment manufacturer.</param>
    /// <param name="metadata">The equipment metadata.</param>
    public abstract class Equipment(string id, string name, string description, string manufacturerId, Dictionary<string, object>? metadata = null) : IHardware
    {
        /// <summary>
        /// Gets the description of the equipment.
        /// </summary>
        public string Description { get; } = description;

        /// <summary>
        /// Gets the unique identifier of the equipment.
        /// </summary>
        public string Id { get; } = id;

        /// <summary>
        /// Gets the manufacturer of the hardware component.
        /// </summary>
        public string ManufacturerId { get; } = manufacturerId;

        /// <summary>
        /// The equipment metadata.
        /// </summary>
        public Dictionary<string, object>? Metadata { get; } = metadata;

        /// <summary>
        /// Gets the name of the equipment.
        /// </summary>
        public string Name { get; } = name;
    }
}
