/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Abstractions
{
    /// <summary>
    /// Defines an interface for objects that have a unique identifier.
    /// </summary>
    public interface IId
    {
        /// <summary>
        /// Gets the unique identifier for the object.
        /// </summary>
        string Id { get; }
    }
}
