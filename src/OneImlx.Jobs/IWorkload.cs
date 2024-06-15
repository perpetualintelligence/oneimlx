/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Collections.Concurrent;
using System.Collections.Generic;
using OneImlx.Abstractions;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a workload consisting of multiple jobs.
    /// </summary>
    public interface IWorkload<TJob> : IId, IName, IDescription
        where TJob : IJob
    {
        /// <summary>
        /// Gets the collection of jobs within the workload.
        /// </summary>
        IEnumerable<IJob> Jobs { get; }
    }
}
