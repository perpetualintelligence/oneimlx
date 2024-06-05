/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

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
