using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Max.Web.Presentation.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            DisplayAttribute[] descriptionAttributes =
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null)
            {
                return string.Empty;
            }
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Name : enumValue.ToString();
        }
    }
}