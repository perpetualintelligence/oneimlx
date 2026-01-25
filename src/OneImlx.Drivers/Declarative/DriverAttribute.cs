//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using System;

namespace OneImlx.Drivers.Declarative
{
    /// <summary>
    /// Defines a <see cref="IDriver"/>.
    /// </summary>
    /// <remarks>Initializes a new instance of the <see cref="DriverAttribute"/> class with specified parameters.</remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DriverAttribute() : Attribute
    {
    }
}