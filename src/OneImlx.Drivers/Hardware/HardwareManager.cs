//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions.Collections;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Manages an unordered collection <see cref="IHardware"/>.
    /// </summary>
    /// <typeparam name="THardware">The type of hardware components to manage.</typeparam>
    public class HardwareManager<THardware> : IdConcurrentCollection<THardware> where THardware : IHardware
    {
    }
}