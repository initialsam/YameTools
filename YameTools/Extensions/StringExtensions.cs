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
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this String Input) => String.IsNullOrEmpty(Input);
        public static bool IsNullOrWhiteSpace(this String Input) => String.IsNullOrWhiteSpace(Input);
        public static bool HasValue(this String Input) => String.IsNullOrEmpty(Input) == false;

        /// <summary>
        /// 取得文字中的數字 若沒有數字 回傳0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetNumber(this string value)
        {
            var getNumbers = new string(value.Where(x => char.IsDigit(x)).ToArray());

            if (int.TryParse(getNumbers, out int result))
            {
                return result;
            }

            return default;

        }
        /// <summary>
        /// 將 \n 換成 <br/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceNewlinesToBr(this string value)
        {
            if (String.IsNullOrEmpty(value)) return value;

            return value.Replace("\n", "<br/>");
        }

        /// <summary>
        /// \u9a57\u8b49\u5931\u6557 => 驗證失敗
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string UnicodeToString(string srcText)
        {
            if (srcText.StartsWith(@"\u") == false) return srcText;

            string dst = "";
            string src = srcText;
            int len = srcText.Length / 6;

            for (int i = 0; i <= len - 1; i++)
            {
                string str = "";
                str = src.Substring(0, 6).Substring(2);
                src = src.Substring(6);
                byte[] bytes = new byte[2];
                bytes[1] = byte.Parse(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                bytes[0] = byte.Parse(int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                dst += Encoding.Unicode.GetString(bytes);
            }
            return dst;
        }
    }
}
