/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx
{
    /// <summary>
    /// Defines a <see cref="IResource"/> group.
    /// </summary>
    /// <remarks>
    /// The <see cref="IResourceGroup"/> defines a logical collection <see cref="IResource"/> objects.
    /// </remarks>
    public interface IResourceGroup : IId, IName, IDescription
    {
    }
}