using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-jsonapi-object
    /// </summary>
    public class JApiObject : JObject
    {
        /// <summary>
        /// Creates a new JSON API Object
        /// </summary>
        /// <param name="version">an optional version string</param>
        /// <param name="meta">an optional meta object</param>
        public JApiObject(string version = null, JObject meta = null)
            : base(content: Content(version: version, meta: meta).ToArray())
        {
        }

        /// <summary>
        /// Constructs the content of the JObject representation of this type
        /// </summary>
        /// <param name="version"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static IEnumerable<object> Content(string version = null, JObject meta = null)
        {
            if (!string.IsNullOrWhiteSpace(version))
            {
                yield return new JProperty(nameof(version), version);
            }
            if (meta != null)
            {
                yield return new JProperty(nameof(meta), meta);
            }
        }
    }
}