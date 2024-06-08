/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// Defines a sole action for a driver.
    /// </summary>
    /// <remarks>
    /// If your driver provides multiple APIs, consider implementing <see cref="IDriver"/>, applying
    /// <see cref="Declarative.DriverAttribute"/> to the driver class and <see cref="Declarative.DriverApiAttribute"/>
    /// on the individual APIs.
    /// </remarks>
    public interface IDriverAction<TContext, TResult> where TContext : class where TResult : class
    {
        /// <summary>
        /// Executes the action with the specified context asynchronously.
        /// </summary>
        /// <param name="context">The context for the action.</param>
        /// <returns>A task that represents the asynchronous operation, with a result of type <typeparamref name="TResult"/>.</returns>
        Task<TResult> ExecuteAsync(TContext context);
    }
}
