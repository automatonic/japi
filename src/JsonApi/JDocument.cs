using System.Linq;
using Newtonsoft.Json.Linq;

namespace Automatonic.JsonApi
{
    public class JDocument : JObject
    {
        public JDocument (JResource data) : base(
            data != null ? new JProperty(nameof(data), data) : null)
        {
        }

        public JDocument (JResourceIdentifierObject data) : base(
            data != null ? new JProperty(nameof(data), data) : null)
        {
        }

        public JDocument (JResource[] data) : base(
            data != null ? new JProperty(nameof(data), new JArray(data)) : null)
        {
        }

        public JDocument (JResourceIdentifierObject[] data) : base(
            data != null ? new JProperty(nameof(data), new JArray(data)) : null)
        {
        }

        public JDocument (JResource data, JMeta meta) : base(
            data != null ? new JProperty(nameof(data), data) : null,
            meta != null ? new JProperty(nameof(meta), meta) : null)
        {
        }

        public JDocument (JResourceIdentifierObject data, JMeta meta) : base(
            data != null ? new JProperty(nameof(data), data) : null,
            meta != null ? new JProperty(nameof(meta), meta) : null)
        {
        }

        public JDocument (JResource[] data, JMeta meta) : base(
            data != null ? new JProperty(nameof(data), new JArray(data)) : null,
            meta != null ? new JProperty(nameof(meta), meta) : null)
        {
        }

        public JDocument (JResourceIdentifierObject[] data, JMeta meta) : base(
            data != null ? new JProperty(nameof(data), new JArray(data)) : null,
            meta != null ? new JProperty(nameof(meta), meta) : null)
        {
        }



        public JDocument (params JError[] errors) : base(errors)
        {
        }

        public JDocument (JMeta meta, params JError[] errors) : base(
            errors != null ? new JProperty(nameof(errors), new JArray(errors)) : null,
            meta != null ? new JProperty(nameof(meta), meta) : null)
        {
        }
    }
}
