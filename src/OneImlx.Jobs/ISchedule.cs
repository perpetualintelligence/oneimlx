/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Threading;
using OneImlx.Abstractions;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a schedule that runs a <see cref="IScheduledRun"/>.
    /// </summary>
    public interface ISchedule<TRun> : IId, IName, IDescription where TRun : IScheduledRun
    {
        /// <summary>
        /// The cancellation token.
        /// </summary>
        CancellationToken CancellationToken { get; }

        /// <summary>
        /// The workload.
        /// </summary>
        IScheduledRun Scheduled { get; }

        /// <summary>
        /// The start time of the schedule.
        /// </summary>
        DateTimeOffset StartTime { get; }
    }
}
