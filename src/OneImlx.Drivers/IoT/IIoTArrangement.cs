/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers.IoT
{
    /// <summary>
    /// Defines a spacial arrangement of multiple <seealso cref="IIoTUnit"/> and their operations.
    /// </summary>
    public interface IIoTArrangement
    {
        /// <summary>
        /// The system this arrangement is part of.
        /// </summary>
        IIoTSystem System { get; }
    }
}
