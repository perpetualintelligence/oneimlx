/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Ifttt
{
    /// <summary>
    /// Provides methods to interact with the IFTTT Webhooks service.
    /// </summary>
    public interface IIftttService
    {
        /// <summary>
        /// Triggers an IFTTT event with the specified event name and optional payload.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="eventName">The name of the IFTTT event.</param>
        /// <param name="payload">The optional payload to send with the event.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task TriggerEventAsync<T>(string eventName, T? payload = default);
    }
}
