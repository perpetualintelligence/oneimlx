/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Rbe.Rules
{
    /// <summary>
    /// Defines the interface for managing and processing rules.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IRuleManager<TContext, TResult>
        where TContext : class, IRuleContext<TResult>
        where TResult : class
    {
    }
}
