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
    /// An abstraction of a job that runs individual <see cref="IStep"/>.
    /// </summary>
    public interface IJobSteps
    {
        /// <summary>
        /// The individual steps within this job.
        /// </summary>
        IEnumerable<IStep> Steps { get; }
    }
}
