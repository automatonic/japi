using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JApi
{
    /// <summary>
    /// Represents a single link with optional metadata
    /// </summary>
    public class JLinksProperty : JProperty
    {
        public JLinksProperty (params JLinkProperty[] links) : base(
            name: nameof(links), 
            content: new JObject(content: links))
        {
    }
}
