/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Security.Claims;

namespace PerpetualIntelligence.OneImlx.Licensing
{
    /// <summary>
    /// Represents a license claim.
    /// </summary>
    /// <remarks>
    /// A <see cref="LicenseClaim"/> is a statement about a licensed subject by an issuer. Claims represent attributes of the licensed subject that are useful
    /// in the context of authentication and authorization operations. Subjects and issuers are both entities that are part of a license validation
    /// scenario. Some typical examples of a licensed subject are: a user, an application or service, a device, or a computer. Some typical
    /// examples of an issuer are: the operating system, an application, a service, a role provider, an identity provider, or a federation provider.
    /// An issuer delivers claims by issuing security tokens, typically through a Security Token Service (STS).
    /// </remarks>
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