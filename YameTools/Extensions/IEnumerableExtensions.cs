using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace YameTools.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string JoinString<T>(this IEnumerable<T> source, string seperator) =>
            string.Join(seperator, source.Select(x => x.ToString()));

        public static string JoinString(this IEnumerable<string> source, string seperator) =>
            string.Join(seperator, source);

        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            if (list is ICollection<T>) return ((ICollection<T>)list).Count == 0;

            return list.Any() == false;
        }

        /// <summary>
        /// 分頁
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="page">第幾頁</param>
        /// <param name="pageSize">一頁幾筆</param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> @list, int page, int pageSize)
        {
            return @list.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
