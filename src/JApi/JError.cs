using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JApi
{
    public class JErrorObject : JObject
    {
        public JErrorObject(
            string id = null, 
            string aboutUrl = null, 
            JObject aboutMeta = null, 
            string status = null, 
            string code = null, 
            string title = null, 
            string detail = null, 
            string sourcePointer = null, 
            string sourceParameter = null, 
            JObject meta = null) : base(
            content:
                ToContent(
                    id,
                    aboutUrl,
                    aboutMeta,
                    status,
                    code,
                    title,
                    detail,
                    sourcePointer,
                    sourceParameter,
                    meta
                ).ToArray())
        {
        }

        public static IEnumerable<object> ToContent(
            string id = null,
            string aboutUrl = null,
            JObject aboutMeta = null,
            string status = null,
            string code = null,
            string title = null,
            string detail = null,
            string sourcePointer = null,
            string sourceParameter = null,
            JObject meta = null)
        {

        }
        
    }
}
