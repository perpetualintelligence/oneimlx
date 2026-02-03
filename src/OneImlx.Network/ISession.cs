//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions;

namespace OneImlx.Network
{
    /// <summary>
    /// An abstraction of a network session.
    /// </summary>
    /// <remarks>
    /// This interface provides the fundamental contract for network session implementations,
    /// combining identification, naming, and descriptive capabilities with session state and kind tracking.
    /// </remarks>
    public interface ISession : IName, IId, IDescription
    {
        /// <summary>
        /// Gets the current state of the network session.
        /// </summary>
        /// <value>
        /// A <see cref="SessionState"/> value indicating the current state of the session.
        /// </value>
        public string State { get; }

        /// <summary>
        /// Gets the kind or type of the network session.
        /// </summary>
        /// <value>
        /// A string representing the session kind, such as TCP, UDP, HTTP, or other protocol types.
        /// </value>
        public string Kind { get; }
    }
}