/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Rbe.Navigators
{
    /// <summary>
    /// Defines the interface for a navigation node.
    /// </summary>
    public interface INavigation : IExpression
    {
        /// <summary>
        /// Gets the unique identifier of the node.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets the start object, expression, or navigation.
        /// </summary>
        IStart Start { get; set; }

        /// <summary>
        /// Navigates to the next node based on the current context.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>The next navigation node.</returns>
        Task<INavigation> NavigateAsync(object context);
    }
}
