using Newtonsoft.Json.Linq;

namespace Automatonic.JsonApi
{
    //http://jsonapi.org/format/#document-resource-identifier-objects
    public class JResourceIdentifierObject : JObject
    {
        public JResourceIdentifierObject (string type, object id) 
            : base(
                new JProperty(nameof(type), type),
                new JProperty(nameof(id), id)
                )
        {
        }

        public JResourceIdentifierObject (string type, object id, JMeta meta) 
            : base(
                new JProperty(nameof(type), type),
                new JProperty(nameof(id), id),
                new JProperty(nameof(meta), meta)
                )
        {
        }
    }
}
