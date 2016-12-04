using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JApi
{
    public class JLinkPropertyMay
    {
        [Fact]
        public void ContainASingleHref()
        {
            var instance = new JLinkProperty(
                name:"about", 
                href:"http://github.com");
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("\"about\":\"http://github.com\"");
        }

        [Fact]
        public void ContainAnHrefAndMeta()
        {
            var instance = new JLinkProperty(
                name:"about", 
                href:"http://github.com", 
                meta: new JObject(
                    new JProperty("a", "1"), 
                    new JProperty("b", "2")));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("\"about\":{\"href\":\"http://github.com\",\"meta\":{\"a\":\"1\",\"b\":\"2\"}}");
        }
     
    }
}