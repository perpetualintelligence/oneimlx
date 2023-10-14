/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx
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