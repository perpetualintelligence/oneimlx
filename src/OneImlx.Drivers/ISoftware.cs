/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction for software.
    /// </summary>
    public interface ISoftware : IId, IName, IDescription
    {
        /// <summary>
        /// Gets the publisher of the software component.
        /// </summary>
        string PublisherId { get; }

        /// <summary>
        /// Gets the version of the software component.
        /// </summary>
        IVersion Version { get; }
    }
}
