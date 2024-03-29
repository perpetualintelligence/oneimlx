﻿/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx
{
    /// <summary>
    /// Defines a target for the permissions.
    /// </summary>
    /// <remarks>
    /// The <see cref="IResource"/> remains indifferent to access mechanisms.
    /// </remarks>
    public interface IResource : IId, IName, IDescription
    {
    }
}