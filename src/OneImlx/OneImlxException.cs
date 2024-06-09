/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Shared.Infrastructure;

namespace OneImlx
{
    /// <summary>
    /// The base <c>oneimlx</c> exception.
    /// </summary>
    /// <remarks>Initializes a new instance of <see cref="OneImlxException"/>.</remarks>
    /// <param name="errorCode">The error code.</param>
    /// <param name="errorDescription">The error description.</param>
    /// <param name="args"></param>
    public sealed class OneImlxException(string errorCode, string errorDescription, params object?[] args) : ErrorException(errorCode, errorDescription, args)
    {
    }
}
