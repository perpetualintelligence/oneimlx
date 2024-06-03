/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Rbac
{
    /// <summary>
    /// Represents an <c>IAM</c> scope which defines a specific area or level of access.
    /// </summary>
    /// <remarks>
    /// A scope is typically a finer-grained control than a role. While roles might define broad access patterns (e.g., "administrator" or "user"),
    /// scopes define more granular access permissions, such as access to specific API endpoints, data segments, or actions within a role.
    /// It's common for a role to be associated with multiple scopes, allowing for flexible and precise access control.
    /// </remarks>
    public interface IScope : IId, IName, IDescription
    {
    }
}