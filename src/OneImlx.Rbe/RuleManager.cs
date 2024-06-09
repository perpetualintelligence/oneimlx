/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using OneImlx.Abstractions;

namespace OneImlx.Rbe
{
    /// <summary>
    /// Manages and processes rules.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public class RuleManager<TContext, TResult> : IRuleManager<TContext, TResult> where TContext : class, IId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleManager{TContext, TResult}"/> class.
        /// </summary>
        /// <param name="ruleStore">The rule store.</param>
        public RuleManager(IRuleStore<TContext, TResult> ruleStore)
        {
            _ruleStore = ruleStore;
        }

        /// <summary>
        /// Processes all applicable rules based on the provided context.
        /// </summary>
        /// <param name="context">The context for rule evaluation and execution.</param>
        /// <returns>A list of results from the executed rules.</returns>
        public async Task<List<TResult>> ProcessRulesAsync(TContext context)
        {
            var results = new List<TResult>();

            foreach (var rule in await _ruleStore.AllAsync())
            {
                if (await rule.EnabledAsync(context))
                {
                    results.Add(await rule.ExecuteAsync(context));
                }
            }

            return results;
        }

        private readonly IRuleStore<TContext, TResult> _ruleStore;
    }
}
