/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx
{
    /// <summary>
    /// Defines a target for the permissions.
    /// </summary>
    /// <remarks>The <see cref="IResource"/> remains indifferent to access mechanisms.</remarks>
    public interface IResource : IId, IName, IDescription
    {
    }
}
