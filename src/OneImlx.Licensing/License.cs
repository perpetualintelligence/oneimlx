/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OneImlx.Licensing
{
    /// <summary>
    /// Represents a <c>OneImlx</c> license.
    /// </summary>
    /// <remarks>
    /// A license is granted to a set of <see cref="ILicensePrincipal"/> objects allowing them to utilize a set of <see cref="ILicenseResource"/> objects.
    /// The license class can be understood as an association between multiple principals and multiple resources, without implying that every principal has access to every resource.
    /// It allows for the flexibility of complex licensing relationships where some principals may have licenses for specific resources while others don't.
    /// </remarks>
    /// <seealso cref="ILicensePrincipal"/>
    /// <seealso cref="ILicenseResource"/>
    public sealed class License
    {
        /// <summary>
        /// Initializes a new instance of the License class.
        /// </summary>
        /// <param name="principals">The set of licensed principals.</param>
        /// <param name="resources">The set of licensed resources.</param>
        /// <param name="licenseKey">The unique identifier for the license.</param>
        /// <param name="targetSystem">Specifies the target system if the license is shared across the entire system or a specific sub-system.</param>
        public License(IEnumerable<ILicensePrincipal> principals, IEnumerable<ILicenseResource> resources, ILicenseKey licenseKey, ILicenseResource? targetSystem = null)
        {
            _principals = new HashSet<ILicensePrincipal>(principals);
            _resources = new HashSet<ILicenseResource>(resources);
            LicenseKey = licenseKey;
            TargetSystem = targetSystem;
        }

        /// <summary>
        /// The license key.
        /// </summary>
        public ILicenseKey LicenseKey { get; }

        /// <summary>
        /// Provides read-only access to the set of licensed principals.
        /// </summary>
        public IReadOnlyCollection<ILicensePrincipal> Principals => new ReadOnlyCollection<ILicensePrincipal>(_principals.ToList());

        /// <summary>
        /// Provides read-only access to the set of licensed resources.
        /// </summary>
        public IReadOnlyCollection<ILicenseResource> Resources => new ReadOnlyCollection<ILicenseResource>(_resources.ToList());

        /// <summary>
        /// Specifies the target system if the license is applicable as a shared license across either the entire system or a particular sub-system.
        /// </summary>
        public ILicenseResource? TargetSystem { get; }

        /// <summary>
        /// Determines whether the specified principal is licensed for the given resource.
        /// </summary>
        /// <param name="principal">The principal to be checked.</param>
        /// <param name="resource">The resource to check the license against.</param>
        /// <returns>True if the principal is licensed for the resource, otherwise false.</returns>
        public bool IsLicensed(ILicensePrincipal principal, ILicenseResource resource)
        {
            return _principals.Contains(principal) && _resources.Contains(resource);
        }

        /// <summary>
        /// Determines whether the specified principal identifier and resource identifier match any licensed pairs.
        /// </summary>
        /// <param name="identityId">The identifier of an identity.</param>
        /// <param name="resourceId">The identifier of the resource.</param>
        /// <returns>True if there exists a licensed pair with the given identifiers, otherwise false.</returns>
        public bool IsLicensed(string identityId, string resourceId)
        {
            return _principals.Any(p => p.Identities.Any(e => e.Id.Equals(identityId))) && _resources.Any(r => r.Id == resourceId);
        }

        private readonly HashSet<ILicensePrincipal> _principals;
        private readonly HashSet<ILicenseResource> _resources;
    }
}