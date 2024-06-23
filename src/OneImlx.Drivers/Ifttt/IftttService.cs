/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneImlx.Drivers.Ifttt
{
    /// <summary>
    /// Implementation of the <see cref="IIftttService"/> interface for interacting with the IFTTT Webhooks service.
    /// </summary>
    public class IftttService : IIftttService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IftttService"/> class with the specified key accessor.
        /// </summary>
        /// <param name="keyAccessor">The accessor for the IFTTT Webhooks key.</param>
        public IftttService(IIftttKeyAccessor keyAccessor)
        {
            _keyAccessor = keyAccessor ?? throw new ArgumentNullException(nameof(keyAccessor));
        }

        /// <inheritdoc/>
        public async Task TriggerEventAsync<T>(string eventName, T? payload = default)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            var key = await _keyAccessor.GetKeyAsync();
            var url = $"https://maker.ifttt.com/trigger/{eventName}/with/key/{key}";
            using (var httpClient = new HttpClient())
            {
                var jsonPayload = payload != null ? System.Text.Json.JsonSerializer.Serialize(payload) : "{}";
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
            }
        }

        private readonly IIftttKeyAccessor _keyAccessor;
    }
}
