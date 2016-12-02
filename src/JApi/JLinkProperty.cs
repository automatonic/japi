using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JApi
{
    /// <summary>
    /// Each member of a links object is a "link"
    /// </summary>
    public class JLinkProperty : JProperty
    {
        public JLinkProperty (string name, string href, JObject meta = null) : base(
            name: name, 
            content: content(href: href, meta: meta))
        {
        }

        internal JLinkProperty (string name, object content) : base(
            name: name, 
            content: content)
        {
        }

        private static object content(string href, JObject meta = null)
        {
            if (href == null)
            {
                throw new ArgumentNullException(nameof(href));
            }
            return ContentOrDefault(
                    href: href, 
                    meta: meta);
        }

        /// <summary>
        /// Builds the Link's content
        /// </summary>
        /// <param name="href"></param>
        /// <param name="meta"></param>
        /// <returns></returns>
        public static object ContentOrDefault(string href, JObject meta = null)
        {
            if (href == null)
            {
                return null;
            }
            if (meta == null)
            {
                return href;
            }
            return new JObject(
                new JProperty(name: nameof(href), content: href),
                new JProperty(name: nameof(meta), content: meta));
        }

        public static IEnumerable<JLinkProperty> Concat(
            string self,
            string related,
            string first, 
            string last,
            string prev,
            string next,
            params JLinkProperty[] links) 
        {   
            if (!string.IsNullOrWhiteSpace(self))
            {
                yield return new JLinkProperty(nameof(self), self);
            }
            if (!string.IsNullOrWhiteSpace(related))
            {
                yield return new JLinkProperty(nameof(related), related);
            }
            if (!string.IsNullOrWhiteSpace(first))
            {
                yield return new JLinkProperty(nameof(first), first);
            }
            if (!string.IsNullOrWhiteSpace(last))
            {
                yield return new JLinkProperty(nameof(last), last);
            }
            if (!string.IsNullOrWhiteSpace(prev))
            {
                yield return new JLinkProperty(nameof(prev), prev);
            }
            if (!string.IsNullOrWhiteSpace(next))
            {
                yield return new JLinkProperty(nameof(next), next);
            }
            if (links != null)
            {
                foreach (var link in links)
                {
                    yield return link;
                }
            }
        }

    }
}
