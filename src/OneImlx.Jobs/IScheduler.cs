/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a scheduler that schedules the workload execution.
    /// </summary>
    public interface IScheduler<TRun> where TRun : IScheduledRun
    {
        /// <summary>
        /// Cancels a scheduled workload.
        /// </summary>
        /// <param name="scheduleId">The identifier of the schedule to cancel.</param>
        Task CancelAsync(string scheduleId);

        /// <summary>
        /// Schedules a workload for execution.
        /// </summary>
        /// <param name="schedule">The schedule to be executed.</param>
        Task ScheduleAsync(ISchedule<TRun> schedule);
    }
}
