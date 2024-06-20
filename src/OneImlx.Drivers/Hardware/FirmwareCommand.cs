/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using OneImlx.Abstractions;

namespace OneImlx.Drivers.Hardware
{
    /// <summary>
    /// Represents a firmware command with a string command type.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="FirmwareCommand"/> class.</remarks>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="description">The description.</param>
    /// <param name="command">The command.</param>
    public class FirmwareCommand(string id, string name, string description, string command) : IId, IName, IDescription, IEquatable<FirmwareCommand>
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; } = command;

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; } = description;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public string Id { get; } = id;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Determines whether two specified <see cref="FirmwareCommand"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="FirmwareCommand"/> to compare.</param>
        /// <param name="right">The second <see cref="FirmwareCommand"/> to compare.</param>
        /// <returns>True if the left and right parameters are not equal; otherwise, false.</returns>
        public static bool operator !=(FirmwareCommand left, FirmwareCommand right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether two specified <see cref="FirmwareCommand"/> instances are equal.
        /// </summary>
        /// <param name="left">The first <see cref="FirmwareCommand"/> to compare.</param>
        /// <param name="right">The second <see cref="FirmwareCommand"/> to compare.</param>
        /// <returns>True if the left and right parameters are equal; otherwise, false.</returns>
        public static bool operator ==(FirmwareCommand left, FirmwareCommand right)
        {
            return EqualityComparer<FirmwareCommand>.Default.Equals(left, right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj) => Equals(obj as FirmwareCommand);

        /// <summary>
        /// Determines whether the specified <see cref="FirmwareCommand"/> is equal to the current <see cref="FirmwareCommand"/>.
        /// </summary>
        /// <param name="other">The <see cref="FirmwareCommand"/> to compare with the current <see cref="FirmwareCommand"/>.</param>
        /// <returns>
        /// True if the specified <see cref="FirmwareCommand"/> is equal to the current <see cref="FirmwareCommand"/>;
        /// otherwise, false.
        /// </returns>
        public bool Equals(FirmwareCommand other) => other != null && Id == other.Id;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => Id.GetHashCode();
    }
}
