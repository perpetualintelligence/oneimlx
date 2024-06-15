/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction to run a <see cref="IJob"/>.
    /// </summary>
    public interface IJobRunner<TJob, TContext, TResult> : IScheduledRun where TContext : JobRunContext<TJob, TResult> where TJob : IJob
    {
        /// <summary>
        /// Runs the job asynchronously.
        /// </summary>
        /// <param name="context">The job context to execute.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task RunJobAsync(TContext context);
    }
}
