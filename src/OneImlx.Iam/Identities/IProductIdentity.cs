/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

namespace OneImlx.Iam.Identities
{
    /// <summary>
    /// Defines an abstraction of a product within the <c>OneImlx</c> framework.
    /// </summary>
    public interface IProductIdentity : IIamIdentity
    {
        /// <summary>
        /// Gets the type or category of the product.
        /// </summary>
        string ProductType { get; }
    }
}