/*
    Copyright 2024 (c) Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Shared.Infrastructure;

namespace OneImlx
{
    /// <summary>
    /// The base <c>oneimlx</c> exception.
    /// </summary>
    public sealed class OneImlxException : ErrorException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="OneImlxException"/>.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorDescription">The error description.</param>
        /// <param name="args"></param>
        public OneImlxException(string errorCode, string errorDescription, params object?[] args) : base(errorCode, errorDescription, args)
        {
        }
    }
}
