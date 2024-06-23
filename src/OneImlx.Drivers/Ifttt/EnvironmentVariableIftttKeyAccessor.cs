/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Threading.Tasks;

namespace OneImlx.Drivers.Ifttt
{
    /// <summary>
    /// Implementation of the <see cref="IIftttKeyAccessor"/> interface for accessing the IFTTT Webhooks key.
    /// </summary>
    public class EnvironmentVariableIftttKeyAccessor : IIftttKeyAccessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentVariableIftttKeyAccessor"/> class.
        /// </summary>
        /// <param name="environmentVariableName">The environment variable name that contains the IFTTT Webhooks key.</param>
        public EnvironmentVariableIftttKeyAccessor(string environmentVariableName)
        {
            _key = Environment.GetEnvironmentVariable(environmentVariableName)
                ?? throw new ArgumentNullException(nameof(environmentVariableName), "Environment variable not found.");
        }

        /// <inheritdoc/>
        public Task<string> GetKeyAsync()
        {
            return Task.FromResult(_key);
        }

        private readonly string _key;
    }
}
