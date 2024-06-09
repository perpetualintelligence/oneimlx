/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using OneImlx.Abstractions;
using OneImlx.Abstractions.Stores;

namespace OneImlx.Rbe
{
    /// <summary>
    /// Defines the interface for a rule store.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IRuleStore<TContext, TResult> : IMutableStore<IRule<TContext, TResult>> where TContext : class, IId
    {
    }
}
