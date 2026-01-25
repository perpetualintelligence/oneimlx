//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction of a driven entity controlled by <see cref="IDriver"/>.
    /// </summary>
    /// <seealso cref="IDriver"/>
    public interface IDriven : IId, IName, IDescription
    {
    }
}