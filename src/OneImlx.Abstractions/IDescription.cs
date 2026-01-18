//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Abstractions
{
    /// <summary>
    /// An abstraction of an object with description.
    /// </summary>
    public interface IDescription
    {
        /// <summary>
        /// Gets the detailed description of the object.
        /// </summary>
        string Description { get; }
    }
}