/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;
using OneImlx.Abstractions;

namespace OneImlx.Rbe
{
    /// <summary>
    /// Defines the interface for a rule.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IRule<TContext, TResult> : IId, IName, IDescription
    {
        /// <summary>
        /// Determines whether the rule is applicable based on the provided context.
        /// </summary>
        /// <param name="context">The context in which the rule is being evaluated.</param>
        /// <returns>True if the rule is applicable; otherwise, false.</returns>
        Task<bool> EnabledAsync(TContext context);

        /// <summary>
        /// Executes the rule based on the provided context.
        /// </summary>
        /// <param name="context">The context in which the rule is being executed.</param>
        /// <returns>The result of executing the rule.</returns>
        Task<TResult> ExecuteAsync(TContext context);
    }
}
