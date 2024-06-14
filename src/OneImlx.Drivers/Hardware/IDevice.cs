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
    /// An abstraction of a hardware device driven by a driver.
    /// </summary>
    public interface IDevice : IHardware, IDisposable
    {
        /// <summary>
        /// The device metadata.
        /// </summary>
        Dictionary<string, object>? Metadata { get; }
    }
}
