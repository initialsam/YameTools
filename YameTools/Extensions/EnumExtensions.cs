using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using System.Text;

namespace YameTools.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 取得 Enum 的 Description
        /// </summary>
        /// <param name="enumValue">Enum</param>
        /// <returns>Enum 的 Description</returns>
        public static string GetEnumDescription(this Enum enumValue)
        {
            var enumString = enumValue.ToString();
            var field = enumValue.GetType().GetField(enumString);

            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>(false);
            var description = descriptionAttribute?.Description;
            return string.IsNullOrWhiteSpace(description)
                ? enumString
                : description;

        }
        /// <summary>
        /// 取得 Enum 的 DisplayName
        /// </summary>
        /// <param name="enumValue">Enum</param>
        /// <returns>Enum 的 DisplayName</returns>
        public static string GetEnumDisplayName(this Enum enumValue)
        {
            var enumString = enumValue.ToString();
            var field = enumValue.GetType().GetField(enumString);

            var displayAttribute = field.GetCustomAttribute<DisplayAttribute>(false);
            if (displayAttribute == null) return enumString;

            var resource = displayAttribute.ResourceType;
            if (resource == null || string.IsNullOrEmpty(displayAttribute.Name))
            {
                return string.IsNullOrWhiteSpace(displayAttribute.GetName())
                   ? enumString
                   : displayAttribute.GetName();
            }

            var rm = new ResourceManager(resource);
            return rm.GetString(displayAttribute.Name);

        }
    }
}
