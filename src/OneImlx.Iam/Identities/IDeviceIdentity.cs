/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a small device or hardware entity within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IDeviceIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the type or category of the device (e.g., IoT device, server, sensor).
        /// </summary>
        string DeviceType { get; }
    }
}
