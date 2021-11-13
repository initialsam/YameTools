using System;
using System.Collections.Generic;
using System.Text;

using YameTools.Format;

namespace YameTools.Extensions
{
    public static class DateTimeExtension
    {
        private static DateTimeFormatSetting _dateTimeFormatSetting;
        public static DateTimeFormatSetting DateTimeFormatSetting
        {
            get { 
                if(_dateTimeFormatSetting == null) _dateTimeFormatSetting = new DateTimeFormatSetting();
                return _dateTimeFormatSetting; 
            }
            set { _dateTimeFormatSetting = value; }
        }

        /// <summary>
        /// DateTime 轉顯示字串 yyyy/MM/dd HH:mm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayDateTime(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.DateTimeFormat);
        }

        /// <summary>
        /// DateTime 轉顯示字串 yyyy/MM/dd
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayDate(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.DateFormat);
        }

        /// <summary>
        /// DateTime 轉顯示字串 HH:mm
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayTime(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.TimeFormat);
        }

        /// <summary>
        /// DateTime 轉顯示字串 yyyy_MM_dd_HH_mm_ss
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayFileName(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.DateTimeFileName);
        }

        /// <summary>
        /// DateTime 轉顯示字串 yyyyMMdd
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayDateWithoutSlash(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.DateFormatWithoutSlash);
        }

        /// <summary>
        /// Smarterasp.Net DB備份日期格式 12_31_2019
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDisplayDateFormatForSmarteraspDb(this DateTime source)
        {
            return source.ToString(DateTimeFormatSetting.DateFormatForSmarteraspDb);
        }


    }
}
