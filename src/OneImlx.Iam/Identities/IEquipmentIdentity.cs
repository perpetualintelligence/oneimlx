/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of large equipment or machinery within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IEquipmentIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the type or category of the equipment (e.g., machine, factory equipment, slt etc.).
        /// </summary>
        string EquipmentType { get; }
    }
}