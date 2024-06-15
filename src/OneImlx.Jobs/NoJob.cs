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
    /// A logical representation of a non-existent job.
    /// </summary>
    /// <remarks><see cref="NoJob"/> enables applications to run a <see cref="IWorkload{TJob}"/>.</remarks>
    public sealed class NoJob : IJob
    {
        /// <summary>
        /// The job description. Throws <see cref="NotSupportedException"/>.
        /// </summary>
        public string Description => throw new NotSupportedException();

        /// <summary>
        /// The job id. Throws <see cref="NotSupportedException"/>.
        /// </summary>
        public string Id => throw new NotSupportedException();

        /// <summary>
        /// The job name. Throws <see cref="NotSupportedException"/>.
        /// </summary>
        public string Name => throw new NotSupportedException();
    }
}
