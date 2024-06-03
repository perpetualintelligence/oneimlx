/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Rbac
{
    /// <summary>
    /// An abstraction of an <c>IAM</c> role.
    /// </summary>
    public interface IRole : IId, IName, IDescription
    {
    }
}