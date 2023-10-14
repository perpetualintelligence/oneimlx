/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a specialized operation within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IOperationIdentity : IOneImlxIdentity
    {
        /// <summary>
        /// Gets the type or category of the operation (e.g., assembly, drilling, loading).
        /// </summary>
        string OperationType { get; }
    }
}