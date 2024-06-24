/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using OneImlx.Abstractions;
using OneImlx.Rbe.Rules;

namespace OneImlx.Rbe
{
    /// <summary>
    /// Manages and processes rules.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <remarks>Initializes a new instance of the <see cref="RuleManager{TContext, TResult}"/> class.</remarks>
    /// <param name="ruleStore">The rule store.</param>
    public class RuleManager<TContext, TResult>(IRuleStore<TContext, TResult> ruleStore) : IRuleManager<TContext, TResult>
        where TContext : class, IRuleContext<TResult>
        where TResult : class
    {
        private readonly IRuleStore<TContext, TResult> _ruleStore = ruleStore;
    }
}
