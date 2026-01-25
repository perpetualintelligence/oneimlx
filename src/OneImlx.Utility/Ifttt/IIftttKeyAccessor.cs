/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Ifttt
{
    /// <summary>
    /// An abstraction to get the IFTTT webhooks key.
    /// </summary>
    public interface IIftttKeyAccessor
    {
        /// <summary>
        /// Asynchronously gets the IFTTT Webhooks key.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the IFTTT Webhooks key.</returns>
        Task<string> GetKeyAsync();
    }
}
