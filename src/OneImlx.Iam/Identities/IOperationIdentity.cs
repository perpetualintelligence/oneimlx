/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a specialized operation within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IOperationIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the type or category of the operation (e.g., assembly, drilling, loading).
        /// </summary>
        string OperationType { get; }
    }
}
