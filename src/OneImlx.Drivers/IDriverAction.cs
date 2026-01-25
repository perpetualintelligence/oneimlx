//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

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
    public interface IDriverAction<TContext> where TContext : class
    {
        /// <summary>
        /// Executes the action with  the specified context asynchronously.
        /// </summary>
        /// <param name="context">The context for the action.</param>
        Task ExecuteAsync(TContext context);
    }
}