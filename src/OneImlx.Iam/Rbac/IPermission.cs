﻿/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Abstractions;

namespace OneImlx.Iam.Rbac
{
    /// <summary>
    /// An abstraction of an <c>IAM</c> role permission.
    /// </summary>
    public interface IPermission : IId, IName, IDescription
    {
    }
}
