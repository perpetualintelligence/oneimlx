/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx
{
    /// <summary>
    /// Provides a set of properties that enable auditing of an identity's creation and last modification timestamps.
    /// Implementing entities or identities can leverage this interface to ensure consistent tracking of crucial audit information.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets the precise date and time when the identity was initially established in the system. The
        /// utilization of <see cref="DateTimeOffset"/> ensures that time zone differences are accurately captured,
        /// offering a universally relevant timestamp regardless of geographical considerations.
        /// </summary>
        DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Gets or sets the exact date and time marking the most recent modification to the identity. If this value
        /// remains <c>null</c>, it signals that the identity has not been altered since its inception. This property
        /// serves as a testament to the identity's integrity and provides transparency into its lifecycle.
        /// </summary>
        DateTimeOffset? LastModifiedOn { get; }
    }
}
