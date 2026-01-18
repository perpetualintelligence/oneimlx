//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Iam
{
    /// <summary>
    /// Defines a <see cref="IResource"/> group.
    /// </summary>
    /// <remarks>The <see cref="IResourceGroup"/> defines a logical collection <see cref="IResource"/> objects.</remarks>
    public interface IResourceGroup : IId, IName, IDescription
    {
    }
}