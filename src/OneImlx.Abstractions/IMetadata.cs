﻿/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Abstractions
{
    /// <summary>
    /// Represents metadata associated with an identity, including properties, attributes, and tags.
    /// </summary>
    public interface IMetadata
    {
        /// <summary>
        /// Represents a collection of distinct attributes associated with the identity. Attributes can depict an
        /// identity's binary states, inherent characteristics, or the various statuses it might assume. Using a HashSet
        /// ensures uniqueness of each attribute and offers efficient look-up operations. Examples include "IsVerified",
        /// "Active", "PremiumSubscriber", "Inactive", and "IsDeleted".
        /// </summary>
        HashSet<string>? Attributes { get; set; }

        /// <summary>
        /// Provides a flexible repository for user-defined or application-specific properties. This dictionary serves
        /// as a dynamic storage mechanism, allowing additional data or metadata to be associated with an identity
        /// without needing alterations to the fundamental schema.
        /// </summary>
        IDictionary<string, object>? Properties { get; set; }

        /// <summary>
        /// Captures a set of tags that can be optionally associated with the identity for categorization, filtering, or
        /// searching purposes. Each tag in this HashSet is guaranteed to be unique, ensuring clear and unambiguous tagging.
        /// </summary>
        HashSet<string>? Tags { get; set; }
    }
}
