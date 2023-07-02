using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            return JsonSerializer.Serialize(@object);
        }
    }
}
