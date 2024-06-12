/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Concurrent;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Represents a collection of firmware commands.
    /// </summary>
    public class FirmwareCommands : ConcurrentDictionary<string, FirmwareCommand>
    {
    }
}
