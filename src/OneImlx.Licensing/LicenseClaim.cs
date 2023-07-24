/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Defines a license claim associated with a licensed component.
    /// </summary>
    public sealed class LicenseClaim : Claim
    {
        /// <summary>
        /// Initialize a new instance of <see cref="LicenseClaim"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public LicenseClaim(string type, string value) : base(type, value)
        {
        }
    }
}