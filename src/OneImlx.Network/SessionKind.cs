//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

namespace OneImlx.Network
{
    /// <summary>
    /// Identifies the protocol family of a network session for tracking and observability.
    /// </summary>
    public static class SessionKind
    {
        /// <summary>
        /// Unknown or unspecified network session protocol.
        /// </summary>
        public const string Unknown = "unknown";

        /// <summary>
        /// Transmission Control Protocol (TCP) session.
        /// </summary>
        public const string Tcp = "tcp";

        /// <summary>
        /// User Datagram Protocol (UDP) session.
        /// </summary>
        public const string Udp = "udp";

        /// <summary>
        /// Hypertext Transfer Protocol (HTTP) session.
        /// </summary>
        public const string Http = "http";

        /// <summary>
        /// gRPC (gRPC Remote Procedure Call) session.
        /// </summary>
        public const string Grpc = "grpc";

        /// <summary>
        /// Publish-Subscribe messaging pattern session.
        /// </summary>
        public const string PubSub = "pubsub";
    }
}