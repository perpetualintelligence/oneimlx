//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Iam.Rbac
{
    /// <summary>
    /// Defines the contract for a group in the Role-Based Access Control (RBAC) system.
    /// </summary>
    /// <remarks>
    /// A group represents a collection of identities that can be assigned roles and permissions collectively.
    /// Groups are used to simplify access control management by allowing multiple identities to share the same set of permissions.
    /// </remarks>
    public interface IGroup : IId, IName, IDescription
    {
    }
}