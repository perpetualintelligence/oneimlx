/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx
{
    /// <summary>
    /// Represents an interface that offers additional integration-related attributes to an identity, encompassing
    /// aspects such as localization preferences and references to external system records.
    /// </summary>
    public interface IIntegration
    {
        /// <summary>
        /// Retrieves or assigns a mapping of external identifiers.
        /// </summary>
        /// <remarks>
        /// This dictionary's key represents an identifier from an external system, while the associated value is the
        /// external ID corresponding to the current identity. This structure provides a mechanism for correlating this
        /// identity with its representations in diverse external platforms or systems.
        /// </remarks>
        IDictionary<string, string>? ExternalIds { get; }

        /// <summary>
        /// Gets or sets a collection of locales pertinent to the identity.
        /// </summary>
        /// <remarks>
        /// The locales serve as indicators of the linguistic and geographical preferences associated with the identity.
        /// The primary locale, situated at the beginning of the list, becomes the default choice for most interactions
        /// and operations. Subsequent locales signify additional languages or regions that the identity either endorses
        /// or can comfortably accommodate. Such a design facilitates seamless operation for identities that span
        /// multiple linguistic or geographic boundaries.
        /// </remarks>
        IList<string>? Locales { get; }
    }
}
