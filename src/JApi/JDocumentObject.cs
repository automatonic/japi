using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JApi
{
    /// <summary>
    /// http://jsonapi.org/format/#document-structure
    /// </summary>
    public class JDocumentObject : JObject
    {
        /// <summary>
        /// Creates a JSON API document for a single resource
        /// </summary>
        /// <param name="data">the document's "primary data" resource</param>
        /// <param name="meta">a meta object that contains non-standard meta-information</param>
        /// <param name="jsonapi">details about the api</param>
        /// <param name="self">the link that generated the current response document</param>
        /// <param name="related">a related resource link when the primary data represents a resource relationship</param>
        /// <param name="first">the first page of data</param>
        /// <param name="last">the last page of data</param>
        /// <param name="prev">the prev page of data</param>
        /// <param name="next">the next page of data</param>
        /// <param name="links">additional custom links</param>
        /// <param name="included">an array of resource objects that are related to the primary data and/or each other</param>
        public JDocumentObject (
            JResourceObject data, 
            JObject meta = null,
            JApiObject jsonapi = null,
            string self = null,
            string related = null,
            string first = null, 
            string last = null,
            string prev = null,
            string next = null,
            JLinkProperty[] additionalLinks = null,
            JResourceObject[] included = null) : base(
                content(
                    data: data, 
                    meta: meta, 
                    jsonapi: jsonapi,
                    links: links( 
                        self: self,
                        related: related,
                        first: first, 
                        last: last,
                        prev: prev,
                        next: next,
                        additionalLinks: additionalLinks), 
                    included: included)
                .ToArray()) {}

        /// <summary>
        /// Creates a JSON API document for a resource collection
        /// </summary>
        /// <param name="data">the document's "primary data" resource collection</param>
        /// <param name="meta">a meta object that contains non-standard meta-information</param>
        /// <param name="jsonapi">details about the api</param>
        /// <param name="self">the link that generated the current response document</param>
        /// <param name="related">a related resource link when the primary data represents a resource relationship</param>
        /// <param name="first">the first page of data</param>
        /// <param name="last">the last page of data</param>
        /// <param name="prev">the prev page of data</param>
        /// <param name="next">the next page of data</param>
        /// <param name="links">additional custom links</param>
        /// <param name="included">an array of resource objects that are related to the primary data and/or each other</param>
        public JDocumentObject (
            JResourceObject[] data, 
            JObject meta = null,
            JApiObject jsonapi = null,
            string self = null,
            string related = null,
            string first = null, 
            string last = null,
            string prev = null,
            string next = null,
            JLinkProperty[] additionalLinks = null,
            JResourceObject[] included = null) : base(
                content(
                    data: data, 
                    meta: meta, 
                    jsonapi: jsonapi, 
                    links: links( 
                        self: self,
                        related: related,
                        first: first, 
                        last: last,
                        prev: prev,
                        next: next,
                        additionalLinks: additionalLinks),  
                    included: included)
                .ToArray()) {}

        /// <summary>
        /// Creates a JSON API document that represents one or more errors
        /// </summary>
        /// <param name="data">an array of error objects</param>
        /// <param name="meta"></param>
        /// <param name="jsonapi"></param>
        /// <param name="self"></param>
        /// <param name="related"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        /// <param name="links"></param>
        /// <param name="meta"></param>
        public JDocumentObject (
            JErrorObject[] data, 
            JObject meta = null,
            JApiObject jsonapi = null,
            string self = null,
            string related = null,
            string first = null, 
            string last = null,
            string prev = null,
            string next = null,
            JLinkProperty[] additionalLinks = null) : base(
                content(
                    data: data, 
                    meta: meta, 
                    jsonapi: jsonapi, 
                    links: links( 
                        self: self,
                        related: related,
                        first: first, 
                        last: last,
                        prev: prev,
                        next: next,
                        additionalLinks: additionalLinks),  
                    included: null)
                .ToArray()) {}
        private static IEnumerable<JLinkProperty> links(
            string self,
            string related,
            string first, 
            string last,
            string prev,
            string next,
            params JLinkProperty[] additionalLinks) 
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
            if (additionalLinks != null)
            {
                foreach (var link in additionalLinks)
                {
                    yield return link;
                }
            }
        }

        private static IEnumerable<object> content(
            object data, 
            JObject meta,
            JApiObject jsonapi,
            IEnumerable<JLinkProperty> links,
            JResourceObject[] included) 
        {
            yield return new JProperty(nameof(data), data);
            if (meta != null)
            {
                yield return new JProperty(nameof(meta), meta);
            }
            if (jsonapi != null)
            {
                yield return new JProperty(nameof(jsonapi), jsonapi);
            }
            if (links != null && links.Any())
            {
                yield return new JProperty(nameof(links), new JLinksObject(links.ToArray()));
            }
            if (included != null)
            {
                yield return new JProperty(nameof(included), new JArray(included));
            }
        }
    }
}
