using FluentAssertions;
using System;
using Xunit;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-top-level
    /// MAY and MUST rules for all JDocumentObjects instances
    /// </summary>
    public class JDocumentObjects
    {
        [Fact]
        public void MayRepresentAnArrayOfResourceIdentifierObjects()
        {
            var instance = new JDocumentObject(new[] {
                new JResourceObject("dwarf", "gimly"),
                new JResourceObject("dwarf", "thorin")
            });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[{\"type\":\"dwarf\",\"id\":\"gimly\"},{\"type\":\"dwarf\",\"id\":\"thorin\"}]}");
        }

        [Fact]
        public void MayRepresentAnArrayOfResourceObjects()
        {
            var instance = new JDocumentObject(new[] {
                new JResourceObject("dwarf", "gimly"),
                new JResourceObject("dwarf", "thorin")
            });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[{\"type\":\"dwarf\",\"id\":\"gimly\"},{\"type\":\"dwarf\",\"id\":\"thorin\"}]}");
        }

        [Fact]
        public void MayRepresentAnEmptyArrayOfResourceObjects()
        {
            var instance = new JDocumentObject(new JResourceObject[] { });
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":[]}");
        }

        [Fact]
        public void MayRepresentASingleNullResourceObject()
        {
            var instance = new JDocumentObject(data: default(JResourceObject));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":null}");
        }

        [Fact]
        public void MayRepresentASingleResourceIdentifierObject()
        {
            var instance = new JDocumentObject(new JResourceObject("dwarf", "gimly"));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":{\"type\":\"dwarf\",\"id\":\"gimly\"}}");
        }

        [Fact]
        public void MayRepresentASingleResourceObject()
        {
            var instance = new JDocumentObject(new JResourceObject("dwarf", "gimly"));
            var result = instance.ToString(Newtonsoft.Json.Formatting.None);
            result.Should().Be("{\"data\":{\"type\":\"dwarf\",\"id\":\"gimly\"}}");
        }
    }
}