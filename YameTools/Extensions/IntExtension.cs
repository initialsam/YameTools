using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools.Extensions
{
    public static class IntExtension
    {
        /// <summary>
        /// 轉int 若null 回傳0
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int ToSafeInt(this int? @int)
        {
            if (@int.HasValue == false) return 0;
            return @int.Value;
        }

        /// <summary>
        /// 不能轉int 回0
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static int ToInt32(this string @string)
        {
            if (int.TryParse(@string, out int number))
            {
                return number;
            }

            return 0;
        }
    }
}
