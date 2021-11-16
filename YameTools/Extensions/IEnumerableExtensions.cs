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

    }
}
