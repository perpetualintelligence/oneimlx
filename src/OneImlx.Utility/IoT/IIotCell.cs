/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers.IoT
{
    /// <summary>
    /// Defines a cell for managing multiple <see cref="IIoTSystem"/> and their operations.
    /// </summary>
    public interface IIoTCell
    {
        /// <summary>
        /// The facility this cell is part of.
        /// </summary>
        IIoTFacility Facility { get; }
    }
}
