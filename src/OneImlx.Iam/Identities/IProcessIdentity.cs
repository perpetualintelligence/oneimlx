/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a manufacturing or operations process within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IProcessIdentity : IOneImlxIdentity
    {
        /// <summary>
        /// Gets the type or category of the process (e.g., manufacturing, operations, logistics).
        /// </summary>
        string ProcessType { get; }
    }
}