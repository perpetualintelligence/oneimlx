/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;
using OneImlx.Abstractions;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a unit step within a <see cref="IJob"/>.
    /// </summary>
    public interface IStep : IId, IName, IDescription
    {
        /// <summary>
        /// The owning job.
        /// </summary>
        public IJob Job { get; }

        /// <summary>
        /// Runs the steps asynchronously.
        /// </summary>
        /// <returns></returns>
        public Task<TResult> RunStepAsync<TContext, TResult>();
    }
}
