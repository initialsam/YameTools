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
    public static class TypeExtensions
    {
        /// <summary>
        /// 取得有該Attribute的PropertyInfo List
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="TypeAttribute"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertyInfoList(this Type classType, Type TypeAttribute)
        {
            var list = (from property in classType.GetProperties()
                        where Attribute.IsDefined(property, TypeAttribute)
                        select property).ToList();
            return list;
        }

        /// <summary>
        /// 取得有該Attribute的PropertyInfo 取第一筆或預設
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="TypeAttribute"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfoFirstOrDefault(this Type classType, Type TypeAttribute)
        {
            var propertyInfo = (from property in classType.GetProperties()
                                where Attribute.IsDefined(property, TypeAttribute)
                                select property).FirstOrDefault();
            return propertyInfo;
        }
    }
}
