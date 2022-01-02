using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;


namespace YameTools.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// To Json
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static string ToJson(this object @object)
        {
            return JsonConvert.SerializeObject(@object, Formatting.Indented);
        }
    }
}
