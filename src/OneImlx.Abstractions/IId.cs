//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Abstractions
{
    /// <summary>
    /// An abstraction of an object with unique identifier.
    /// </summary>
    public interface IId
    {
        /// <summary>
        /// Gets the unique identifier for the object.
        /// </summary>
        string Id { get; }
    }
}