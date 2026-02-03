//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Network
{
    /// <summary>
    /// Represents the life-cycle state of a network session as string constants.
    /// </summary>
    public static class SessionState
    {
        /// <summary>
        /// The session has been created but not yet opened.
        /// </summary>
        public const string Created = "created";

        /// <summary>
        /// The session is open and active.
        /// </summary>
        public const string Open = "open";

        /// <summary>
        /// The session has been closed.
        /// </summary>
        public const string Closed = "closed";

        /// <summary>
        /// The session has encountered a fault and is in an error state.
        /// </summary>
        public const string Faulted = "faulted";
    }
}