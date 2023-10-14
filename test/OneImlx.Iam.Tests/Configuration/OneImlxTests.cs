/*
    Copyright (c) 2023 Perpetual Intelligence L.L.C. All Rights Reserved.

    For license, terms, and data policies, go to:
    https://terms.perpetualintelligence.com/articles/intro.html
*/

using FluentAssertions;
using Xunit;

namespace PerpetualIntelligence.OneImlx.Configuration
{
    public class OneImlxOptionsTests
    {
        [Fact]
        public void Options_Initialized()
        {
            var options = new OneImlxOptions();
            options.Iam.Should().NotBeNull();
            options.Licensing.Should().NotBeNull();
        }
    }
}