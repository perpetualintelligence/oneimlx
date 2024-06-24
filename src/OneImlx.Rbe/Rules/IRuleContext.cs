/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OneImlx.Rbe.Rules
{
    /// <summary>
    /// An abstraction of a rule context.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IRuleContext<TResult> where TResult : class
    {
        /// <summary>
        /// The result of the rule.
        /// </summary>
        public TResult Result { get; }
    }
}
