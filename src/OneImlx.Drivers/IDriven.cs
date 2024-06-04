/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction for a driven entity.
    /// </summary>
    /// <seealso cref="IDriver"/>
    public interface IDriven : IDisposable, IId, IName, IDescription
    {
    }
}
