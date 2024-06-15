/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System;
using System.Collections.Generic;
using System.Text;
using OneImlx.Abstractions.Stores;

namespace OneImlx.Jobs
{
    /// <summary>
    /// An abstraction of a <see cref="IStep"/> store.
    /// </summary>
    public interface IStepStore : IMutableStore<IStep>, IImmutableStore<IStep>
    {
    }
}
