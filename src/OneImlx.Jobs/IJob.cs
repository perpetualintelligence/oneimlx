/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using OneImlx.Abstractions;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a job.
    /// </summary>
    public interface IJob : IId, IName, IDescription
    {
    }
}
