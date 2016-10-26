using Newtonsoft.Json.Linq;

namespace JApi
{
    //http://jsonapi.org/format/#document-resource-identifier-objects
    public class JResourceObject : JObject
    {
        public JResourceObject (string type, object id) 
            : base(
                new JProperty(nameof(type), type),
                new JProperty(nameof(id), id)
                )
        {
        }

        public JResourceObject (string type, object id, JObject meta) 
            : base(
                new JProperty(nameof(type), type),
                new JProperty(nameof(id), id),
                new JProperty(nameof(meta), meta)
                )
        {
        }

        internal JResourceObject (string type, object id, JObject meta, object[] content) 
            : base(
                new JProperty(nameof(type), type),
                new JProperty(nameof(id), id),
                new JProperty(nameof(meta), meta)
                )
        {
        }
    }
}
