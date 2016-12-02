using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace JApi
{
    /// <summary>
    /// Error objects provide additional information about problems encountered while performing an operation. Error objects MUST be returned as an array keyed by errors in the top level of a JSON API document.
    /// </summary>
    public class JErrorObject : JObject
    {
        /// <summary>
        /// An error object MAY have the following members:
        /// </summary>
        /// <param name="id">a unique identifier for this particular occurrence of the problem</param>
        /// <param name="aboutHref">a link that leads to further details about this particular occurrence of the problem.</param>
        /// <param name="aboutMeta">meta data for the about link</param>
        /// <param name="status"> the HTTP status code applicable to this problem, expressed as a string value.</param>
        /// <param name="code">an application-specific error code, expressed as a string value.</param>
        /// <param name="title">a short, human-readable summary of the problem that SHOULD NOT change from occurrence to occurrence of the problem, except for purposes of localization.</param>
        /// <param name="detail">a human-readable explanation specific to this occurrence of the problem. Like title, this field’s value can be localized.</param>
        /// <param name="sourcePointer">an object containing references to the source of the error, optionally including any of the following members: a JSON Pointer [RFC6901] to the associated entity in the request document [e.g. "/data" for a primary data object, or "/data/attributes/title" for a specific attribute].</param>
        /// <param name="sourceParameter">a string indicating which URI query parameter caused the error.</param>
        /// <param name="meta">a meta object containing non-standard meta-information about the error.</param>
        public JErrorObject(
            string id = null, 
            string aboutHref = null, 
            JObject aboutMeta = null, 
            string status = null, 
            string code = null, 
            string title = null, 
            string detail = null, 
            string sourcePointer = null, 
            string sourceParameter = null, 
            JObject meta = null) 
        : base(
            content: content(
                id: id,
                links: links(
                    about: about(
                        href: aboutHref, 
                        meta: aboutMeta)),
                status: status,
                code: code,
                title: title,
                detail: detail,
                source: source(
                    pointer: sourcePointer,
                    parameter: sourceParameter),
                meta: meta).ToArray())
        {
        }

        private static JLinkProperty about(string href, JObject meta)
        {
            var content = JLinkProperty.ContentOrDefault(href, meta);
            if (content == null)
            {
                return null;
            }
            return new JLinkProperty(nameof(about), content);
        }
        private static JLinksObject links(JLinkProperty about)
        {
            if (about == null)
            {
                return null;
            }
            return new JLinksObject(about);
        }

        private static JObject source(
            string pointer,
            string parameter)
        {
            var flags = 0x0000;
            if (pointer != null)
            {
                flags |= 0x0001;
            }
            if (parameter != null)
            {
                flags |= 0x0002;
            }
            switch (flags)
            {
                case 0x0001:
                    return new JObject(
                        new JProperty(nameof(pointer), pointer));
                case 0x0002:
                    return new JObject(
                        new JProperty(nameof(parameter), parameter));
                case 0x0003:
                    return new JObject(
                        new JProperty(nameof(pointer), pointer),
                        new JProperty(nameof(parameter), parameter));
                default:
                    return null;
            }
        }

        private static IEnumerable<object> content(
            string id = null,
            JLinksObject links = null,
            string status = null,
            string code = null,
            string title = null,
            string detail = null,
            JObject source = null,
            JObject meta = null)
        {
            if (id != null)
            {
                yield return new JProperty(nameof(id), id);
            }
            if (links != null)
            {
                yield return new JProperty(nameof(links), links);
            }
            if (status != null)
            {
                yield return new JProperty(nameof(status), status);
            }
            if (code != null)
            {
                yield return new JProperty(nameof(code), code);
            }
            if (title != null)
            {
                yield return new JProperty(nameof(title), title);
            }
            if (detail != null)
            {
                yield return new JProperty(nameof(detail), detail);
            }
            if (source != null)
            {
                yield return new JProperty(nameof(source), source);
            }
            if (meta != null)
            {
                yield return new JProperty(nameof(meta), meta);
            }
        }
        
    }
}
