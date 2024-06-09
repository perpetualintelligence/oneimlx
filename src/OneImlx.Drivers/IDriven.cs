/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Abstractions;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction for a driven entity.
    /// </summary>
    /// <seealso cref="IDriver"/>
    public interface IDriven : IId, IName, IDescription
    {
    }
}
