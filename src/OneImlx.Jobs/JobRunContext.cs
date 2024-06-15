/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a <see cref="IJobRunner{TJob, TContext, TResult}"/> context.
    /// </summary>
    /// <typeparam name="TJob">The job to run.</typeparam>
    /// <typeparam name="TResult">The result of the job run.</typeparam>
    public abstract class JobRunContext<TJob, TResult>(TJob job, TResult? result = default) where TJob : IJob
    {
        /// <summary>
        /// The <see cref="IJob"/>.
        /// </summary>
        public TJob Job { get; } = job;

        /// <summary>
        /// The job run result.
        /// </summary>
        public TResult? Result { get; set; } = result;
    }
}
