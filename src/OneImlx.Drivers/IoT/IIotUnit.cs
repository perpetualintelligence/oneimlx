/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers.IoT
{
    /// <summary>
    /// Defines a logical unit for managing individual IoT device and their operations.
    /// </summary>
    public interface IIoTUnit
    {
        /// <summary>
        /// The arrangement this unit is part of.
        /// </summary>
        IIoTArrangement Arrangement { get; }
    }
}
