/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Parametric
{
    /// <summary>
    /// Defines an interface for execution a functional work-flow or a functional test within a given context.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TResult">The type of the value to be measured.</typeparam>
    public interface IFunction<TContext, TResult>
    {
        /// <summary>
        /// Executes a function asynchronously within the given context.
        /// </summary>
        /// <param name="context">The context within which the measurement is taken.</param>
        /// <returns>A task that represents the asynchronous operation and contains the executed result.</returns>
        Task<TResult> ExecuteAsync(TContext context);
    }
}
