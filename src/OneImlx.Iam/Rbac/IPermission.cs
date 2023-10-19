/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace PerpetualIntelligence.OneImlx.Iam.Rbac
{
    /// <summary>
    /// An abstraction of an <c>IAM</c> role permission.
    /// </summary>
    /// <remarks>
    /// It's recommended to keep the ID of the permission as concise as possible, ideally 2 or 3 characters. The reasons for this include:
    /// <list type="bullet">
    ///     <item>
    ///         <description>Efficiency in Access Checks: Frequent RBAC access checks are based on permission IDs.</description>
    ///     </item>
    ///     <item>
    ///         <description>Storage & Network Efficiency: Short IDs reduce transmission and storage overhead.</description>
    ///     </item>
    ///     <item>
    ///         <description>Finite Permission Set: The system has a limited number of permissions, which means a short ID is practical.</description>
    ///     </item>
    ///     <item>
    ///         <description>Easier Debugging: Short IDs are more recognizable in logs and debugging sessions.</description>
    ///     </item>
    /// </list>
    /// </remarks>
    public interface IPermission : IId, IName, IDescription
    {
    }
}