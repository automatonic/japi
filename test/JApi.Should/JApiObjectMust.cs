using FluentAssertions;
using System;
using Xunit;

namespace JApi
{
    public class JApiObjectMust
    {
        /// <summary>
        /// MUST be an object 
        /// </summary>
        [Fact]
        public void BeAnObject() 
        {
            var instance = new JApiObject();
            var result = instance.ToString();
            result.Should().Be("{}");
        }
    }
}
