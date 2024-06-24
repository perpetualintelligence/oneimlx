/*
    Copyright © 2019-2024 Perpetual Intelligence L.L.C. All rights reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using System.Threading.Tasks;

namespace OneImlx.Drivers.Rendering
{
    /// <summary>
    /// Defines the interface for rendering metadata for driver UX components.
    /// </summary>
    public interface IDriverRenderer : IRenderer
    {
        /// <summary>
        /// Renders metadata for a specific driver and returns it as a JSON string.
        /// </summary>
        /// <param name="driver">The driver for which to render metadata.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the JSON metadata.</returns>
        Task<string> RenderDriverMetadataAsync(IDriver driver);
    }
}
