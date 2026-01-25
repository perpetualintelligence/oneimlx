/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers.IoT
{
    /// <summary>
    /// Defines a system for managing multiple <see cref="IIoTArrangement"/> and their operations.
    /// </summary>
    public interface IIoTSystem
    {
        /// <summary>
        /// The cell this system is part of.
        /// </summary>
        IIoTCell Cell { get; }
    }
}
