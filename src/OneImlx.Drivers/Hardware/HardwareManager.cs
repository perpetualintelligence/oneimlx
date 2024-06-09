/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Manages <see cref="IHardware"/> components concurrently.
    /// </summary>
    /// <typeparam name="THardware">The type of hardware components to manage.</typeparam>
    public class HardwareManager<THardware> where THardware : IHardware
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HardwareManager{THardware}"/> class.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="ConcurrentDictionary{TKey, TValue}"/> to ensure thread-safe operations for adding,
        /// retrieving, and removing hardware components.
        /// </remarks>
        public HardwareManager()
        {
            hardwareComponents = new ConcurrentDictionary<string, THardware>();
        }

        /// <summary>
        /// Gets the collection of hardware components as an immutable dictionary.
        /// </summary>
        /// <returns>An immutable dictionary of hardware components.</returns>
        /// <remarks>
        /// This method uses <see cref="ImmutableDictionary{TKey, TValue}"/> to provide a thread-safe, read-only
        /// collection of the hardware components.
        /// </remarks>
        public IReadOnlyDictionary<string, THardware> All()
        {
            return hardwareComponents.ToImmutableDictionary();
        }

        /// <summary>
        /// Adds a hardware component to the manager.
        /// </summary>
        /// <param name="hardware">The hardware component to add.</param>
        /// <returns>True if the hardware component was added successfully, false otherwise.</returns>
        /// <remarks>
        /// This method uses <see cref="ConcurrentDictionary{TKey, TValue}.TryAdd"/> to ensure that the addition
        /// operation is atomic and thread-safe.
        /// </remarks>
        public bool TryAdd(THardware hardware)
        {
            return hardwareComponents.TryAdd(hardware.Id, hardware);
        }

        /// <summary>
        /// Gets a hardware component by its ID.
        /// </summary>
        /// <param name="hardwareId">The ID of the hardware component to get.</param>
        /// <param name="hardware">
        /// When this method returns, contains the hardware component if found, or null if not found. This parameter is
        /// passed uninitialized.
        /// </param>
        /// <returns>True if the hardware component was found, false otherwise.</returns>
        /// <remarks>
        /// This method uses <see cref="ConcurrentDictionary{TKey, TValue}.TryGetValue"/> to ensure thread-safe
        /// retrieval of a hardware component by its ID.
        /// </remarks>
        public bool TryGet(string hardwareId, out THardware? hardware)
        {
            return hardwareComponents.TryGetValue(hardwareId, out hardware);
        }

        /// <summary>
        /// Removes a hardware component from the manager.
        /// </summary>
        /// <param name="hardwareId">The ID of the hardware component to remove.</param>
        /// <param name="hardware">
        /// When this method returns, contains the removed hardware component if the removal was successful, or null if
        /// not found. This parameter is passed uninitialized.
        /// </param>
        /// <returns>True if the hardware component was removed successfully, false otherwise.</returns>
        /// <remarks>
        /// This method uses <see cref="ConcurrentDictionary{TKey, TValue}.TryRemove"/> to ensure thread-safe removal of
        /// a hardware component by its ID.
        /// </remarks>
        public bool TryRemove(string hardwareId, out THardware? hardware)
        {
            return hardwareComponents.TryRemove(hardwareId, out hardware);
        }

        private readonly ConcurrentDictionary<string, THardware> hardwareComponents;
    }
}
