//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System.Collections.Generic;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// An abstraction of a functional hardware device.
    /// </summary>
    public interface IDevice : IHardware
    {
        /// <summary>
        /// The device metadata.
        /// </summary>
        Dictionary<string, object>? Metadata { get; }
    }
}