//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Iam.Rbac
{
    /// <summary>
    /// Represents a policy in a role-based access control (RBAC) system.
    /// </summary>
    /// <remarks>
    /// A policy defines a set of rules or conditions that govern access control decisions.
    /// It combines identification, naming, and descriptive capabilities through its base interfaces.
    /// </remarks>
    public interface IPolicy : IId, IName, IDescription
    {
    }
}