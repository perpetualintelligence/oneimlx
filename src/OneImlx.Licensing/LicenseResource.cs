/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Represents resources that can be licensed.
    /// </summary>
    /// <remarks></remarks>
    public class LicenseResource : ILicenseResource
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public LicenseResource(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// The resource attributes.
        /// </summary>
        public HashSet<string>? Attributes { get; set; }

        /// <summary>
        /// The resource description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The resource identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The resource name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The resource properties.
        /// </summary>
        public IDictionary<string, object>? Properties { get; set; }

        /// <summary>
        /// The resource tags.
        /// </summary>
        public HashSet<string>? Tags { get; set; }
    }
}
