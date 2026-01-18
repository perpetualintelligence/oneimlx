//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Abstractions
{
    /// <summary>
    /// An abstraction of an object with name.
    /// </summary>
    public interface IName
    {
        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        string Name { get; }
    }
}