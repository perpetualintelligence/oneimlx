/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Licensing
{
    /// <summary>
    /// Provides methods for managing and verifying licenses associated with identities and resources.
    /// </summary>
    public interface ILicenseManager
    {
        /// <summary>
        /// Determines whether the given identity possesses a license to access the specified resource.
        /// </summary>
        /// <param name="identity">The identity under evaluation.</param>
        /// <param name="resource">The target resource to be accessed.</param>
        /// <param name="license">Output parameter that contains the applicable license, if available; otherwise, <c>null</c>.</param>
        /// <returns>
        /// <c>true</c> if a valid license exists for the identity to access the resource; <c>false</c> otherwise.
        /// </returns>
        bool HasLicenseFor(ILicenseIdentity identity, ILicenseResource resource, out License? license);

        /// <summary>
        /// Determines whether all identities within the specified principal hold a license to access the given resource.
        /// </summary>
        /// <param name="principal">The principal under consideration, potentially holding multiple identities.</param>
        /// <param name="resource">The target resource to be accessed.</param>
        /// <param name="license">
        /// Output parameter that contains the applicable license, if one exists among the identities; otherwise, <c>null</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if valid licenses exist for all the principal's identities to access the resource; <c>false</c> otherwise.
        /// </returns>
        bool HasLicenseFor(ILicensePrincipal principal, ILicenseResource resource, out License? license);

        /// <summary>
        /// Assesses whether the identity, identified by its ID, possesses a license to access the resource defined by
        /// its ID.
        /// </summary>
        /// <param name="identityId">The unique identifier of the identity.</param>
        /// <param name="resourceId">The unique identifier of the resource.</param>
        /// <param name="license">Output parameter returning the relevant license if found; otherwise, <c>null</c>.</param>
        /// <returns>
        /// <c>true</c> if a valid license is found for the given identity to access the specified resource;
        /// <c>false</c> otherwise.
        /// </returns>
        bool HasLicenseFor(string identityId, string resourceId, out License? license);
    }
}
