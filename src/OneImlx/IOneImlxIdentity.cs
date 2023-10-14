/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Security.Principal;

namespace PerpetualIntelligence.OneImlx
{
    /// <summary>
    /// Represents the foundational identity interface for the <c>OneImlx</c> system. This interface serves as the primary blueprint
    /// for defining and interacting with identity entities, accommodating extensibility and integration with diverse applications.
    /// </summary>
    public interface IOneImlxIdentity : IIdentity, IId, IName, IAuditable
    {
        /// <summary>
        /// Provides a flexible repository for user-defined or application-specific properties. This dictionary serves
        /// as a dynamic storage mechanism, allowing additional data or metadata to be associated with an identity without needing
        /// alterations to the fundamental schema.
        /// </summary>
        IDictionary<string, object>? Properties { get; }

        /// <summary>
        /// Represents a collection of distinct attributes associated with the identity. Attributes can depict an identity's binary states,
        /// inherent characteristics, or the various statuses it might assume. Using a HashSet ensures uniqueness of each attribute and offers
        /// efficient look-up operations.
        /// Examples include "IsVerified", "Active", "PremiumSubscriber", "Inactive", and "IsDeleted".
        /// </summary>
        HashSet<string>? Attributes { get; }

        /// <summary>
        /// Captures a set of tags that can be optionally associated with the identity for categorization, filtering, or searching purposes.
        /// Each tag in this HashSet is guaranteed to be unique, ensuring clear and unambiguous tagging.
        /// </summary>
        HashSet<string>? Tags { get; }
    }
}