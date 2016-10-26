using FluentAssertions;
using System;
using Xunit;

namespace JApi
{
    public class JApiObjectMay
    {
        /// <summary>
        /// MAY contain a version
        /// </summary>
        [Fact]
        public void ConstructVersion()
        {
            var instance = new JApiObject();
            var result = instance.ToString();
            result.Should().Be("{}");
        }
    }
}
