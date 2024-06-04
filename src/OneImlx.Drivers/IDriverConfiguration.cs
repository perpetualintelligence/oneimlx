/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers
{
    /// <summary>
    /// An abstraction to configure a driver.
    /// </summary>
    public interface IDriverConfiguration<TOptions> where TOptions : class
    {
        /// <summary>
        /// Configures the driver with the provided options.
        /// </summary>
        /// <param name="options">The settings to apply.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task ConfigureAsync(TOptions options);
    }
}
