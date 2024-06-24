/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Rbe.Navigators
{
    /// <summary>
    /// Defines the interface for an expression that evaluates to an object.
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// Evaluates the expression and returns the resulting object.
        /// </summary>
        /// <param name="context">The context in which to evaluate the expression.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the evaluated object.</returns>
        Task<object> EvaluateAsync(object context);
    }
}
