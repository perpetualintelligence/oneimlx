/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneImlx.Rbe
{
    /// <summary>
    /// Defines the interface for managing and processing rules.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IRuleManager<TContext, TResult>
    {
        /// <summary>
        /// Processes all applicable rules based on the provided context.
        /// </summary>
        /// <param name="context">The context for rule evaluation and execution.</param>
        /// <returns>A list of results from the executed rules.</returns>
        Task<List<TResult>> ProcessRulesAsync(TContext context);
    }
}
