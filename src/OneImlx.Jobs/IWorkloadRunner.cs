/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction to run a <see cref="IWorkload{TJob}"/>.
    /// </summary>
    public interface IWorkloadRunner<TContext, TWorkload, TJob, TResult> : IScheduledRun
        where TContext : WorkloadRunContext<TWorkload, TJob, TResult>
        where TWorkload : IWorkload<TJob>
        where TJob : IJob
    {
        /// <summary>
        /// Runs the workload asynchronously.
        /// </summary>
        /// <param name="workload">The workload context to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RunWorkloadAsync(TContext workload);
    }
}
