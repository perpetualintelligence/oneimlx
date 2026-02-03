//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using OneImlx.Abstractions.Collections;

namespace OneImlx.Network
{
    /// <summary>
    /// Manages a concurrent collection of network sessions.
    /// </summary>
    public sealed class SessionManager : IdConcurrentCollection<ISession>
    {
    }
}