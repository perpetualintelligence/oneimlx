/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// An abstraction for hardware components.
    /// </summary>
    public interface IHardware : IDriven
    {
        /// <summary>
        /// Gets the manufacturer of the hardware component.
        /// </summary>
        string ManufacturerId { get; }
    }
}
