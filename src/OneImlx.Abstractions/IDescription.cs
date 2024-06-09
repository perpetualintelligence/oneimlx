/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Abstractions
{
    /// <summary>
    /// Defines an interface for objects that have a description.
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Gets the detailed description of the object.
        /// </summary>
        string Description { get; }
    }
}
