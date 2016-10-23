
using Newtonsoft.Json.Linq;

namespace Automatonic.JsonApi
{
    public class JResource : JObject
    {
        public JResource (JResource resource) : base(data)
        {
        }

        public JResource (params JResource[] errors) : base(errors)
        {
        }

        public JResource (JMeta meta, params JError[] errors) : base(new [] {meta}.Concat(errors).ToArray())
        {
        }
    }
}
