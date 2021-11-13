using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using System.Text;

namespace YameTools.Extensions
{
    public static class StringBuilderExtension
    {
        /// <summary>
        /// CSV格式用Append 最後會放逗號
        /// </summary>
        /// <param name="value"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static StringBuilder AppendForCsv(this StringBuilder value, string word)
        {
            return value.Append($"{word},");
        }
        /// <summary>
        /// Html格式用Append 最後會放<BR/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static StringBuilder AppendForHtml(this StringBuilder value, string word)
        {
            return value.Append($"{word}<BR/>");
        }

        /// <summary>
        /// CSV格式用ToString 會移除最後一個逗號
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringForCSV(this StringBuilder value)
        {
            return value.ToString().TrimEnd(',');
        }
    }
}
