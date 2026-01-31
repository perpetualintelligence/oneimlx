//  Copyright © 2019-2026 Perpetual Intelligence L.L.C. All rights reserved.
//  For license, terms, and data policies, go to:
//  https://terms.perpetualintelligence.com/articles/intro.html

using FluentAssertions;
using Xunit;

namespace OneImlx.Drivers.Hardware
{
    public class HardwareManagerTests
    {
        [Fact]
        public void Inherits_From_Id_Collection()
        {
            var type = typeof(HardwareManager<>);

            type.BaseType!.GetGenericTypeDefinition()
                .Should()
                .Be(typeof(Abstractions.Collections.IdConcurrentCollection<>));
        }
    }
}