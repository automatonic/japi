using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JApi
{
    /// <summary>
    /// Where specified, a links member can be used to represent links. The value of each links member MUST be an object (a “links object”).
    /// </summary>
    public class JLinksObject : JObject
    {
        /// <summary>
        /// Creates a links object from the specified properties
        /// </summary>
        /// <param name="links"></param>
        public JLinksObject (params JLinkProperty[] links) : base(
            content: links)
        {
        }
    }
}
