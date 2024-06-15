/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a <see cref="IWorkloadRunner{TContext, TWorkload, TJob, TResult}"/> context.
    /// </summary>
    /// <typeparam name="TWorkload">The workload type to run.</typeparam>
    /// <typeparam name="TJob">The job type to run.</typeparam>
    /// <typeparam name="TResult">The result type of the job run.</typeparam>
    public abstract class WorkloadRunContext<TWorkload, TJob, TResult>(
        TWorkload workload,
        TResult? result = default)
            where TWorkload : IWorkload<TJob>
            where TJob : IJob
    {
        /// <summary>
        /// The workload run result.
        /// </summary>
        public TResult? Result { get; set; } = result;

        /// <summary>
        /// The <see cref="IWorkload{TJob}"/>.
        /// </summary>
        public TWorkload Workload { get; } = workload;
    }
}
