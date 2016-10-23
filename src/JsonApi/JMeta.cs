using Newtonsoft.Json.Linq;

namespace Automatonic.JsonApi
{
    //http://jsonapi.org/format/#document-meta
    public class JMeta : JObject
    {
        public JMeta (JProperty[] members) 
            : base(members)
        {
        }
    }
}
