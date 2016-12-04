using FluentAssertions;
using System;
using Xunit;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-top-level
    /// MAY and MUST rules for all JDocumentObjects instances
    /// </summary>
    public class JDocumentObjectMay
    {
        [Fact]
        public void RepresentAnArrayOfResourceIdentifierObjects()
        {
            var instance = new JDocumentObject(new[] {
                new JResourceObject("dwarf", "gimly"),
                new JResourceObject("dwarf", "thorin")
            });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[{\"type\":\"dwarf\",\"id\":\"gimly\"},{\"type\":\"dwarf\",\"id\":\"thorin\"}]}");
        }

        [Fact]
        public void RepresentAnArrayOfResourceObjects()
        {
            var instance = new JDocumentObject(new[] {
                new JResourceObject("dwarf", "gimly"),
                new JResourceObject("dwarf", "thorin")
            });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[{\"type\":\"dwarf\",\"id\":\"gimly\"},{\"type\":\"dwarf\",\"id\":\"thorin\"}]}");
        }

        [Fact]
        public void RepresentAnEmptyArrayOfResourceObjects()
        {
            var instance = new JDocumentObject(new JResourceObject[] { });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[]}");
        }

        [Fact]
        public void RepresentASingleNullResourceObject()
        {
            var instance = new JDocumentObject(data: default(JResourceObject));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":null}");
        }

        [Fact]
        public void RepresentASingleResourceIdentifierObject()
        {
            var instance = new JDocumentObject(new JResourceObject("dwarf", "gimly"));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":{\"type\":\"dwarf\",\"id\":\"gimly\"}}");
        }

        [Fact]
        public void RepresentASingleResourceObject()
        {
            var instance = new JDocumentObject(new JResourceObject("dwarf", "gimly"));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":{\"type\":\"dwarf\",\"id\":\"gimly\"}}");
        }
    }
}