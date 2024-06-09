/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Xunit;

namespace OneImlx.Abstractions.Configuration
{
    public class OneImlxOptionsTests
    {
        [Fact]
        public void OneImlx_Initializes_Correctly()
        {
            var options = new OneImlxOptions();
            options.Licensing.Should().NotBeNull();
        }
    }
}