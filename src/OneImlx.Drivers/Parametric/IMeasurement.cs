/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Parametric
{
    /// <summary>
    /// Defines an interface for measuring a value within a given context.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <typeparam name="TValue">The type of the value to be measured.</typeparam>
    public interface IMeasurement<TContext, TValue>
    {
        /// <summary>
        /// Measures a value asynchronously within the given context.
        /// </summary>
        /// <param name="context">The context within which the measurement is taken.</param>
        /// <returns>A task that represents the asynchronous operation and contains the measured value.</returns>
        Task<TValue> MeasureAsync(TContext context);
    }
}
