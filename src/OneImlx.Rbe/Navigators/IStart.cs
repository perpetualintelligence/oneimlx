/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Rbe.Navigators
{
    /// <summary>
    /// Defines the interface for the start of a navigation.
    /// </summary>
    public interface IStart : IExpression, INavigation
    {
        /// <summary>
        /// Gets the starting object, expression, or navigation.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the start object.</returns>
        Task<object> GetStartObjectAsync();
    }
}
