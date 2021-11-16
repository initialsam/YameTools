using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace YameTools.Helper
{
    public static class AppSettingHelper
    {
        /// <summary>
        /// 取得 Web.config 中的設定值
        /// </summary>
        /// <typeparam name="T">設定值的泛型T</typeparam>
        /// <param name="key">設定值的Key</param>
        /// <param name="defaultVale">取不到時要回傳的預設值</param>
        /// <returns>轉型失敗時會回傳泛型T的預設值。(Ex: int的預設值是0)</returns>
        public static T GetAppSetting<T>(string key, T defaultVale = default(T))
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (setting == null) return defaultVale;

            try
            {
                return (T)Convert.ChangeType(setting, typeof(T));
            }
            catch
            {
                return defaultVale;
            }

        }
    }
}
