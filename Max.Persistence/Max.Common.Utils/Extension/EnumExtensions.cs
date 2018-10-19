using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Max.Common.Utils.Extension
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return string.Empty;
            }
            var attr = field.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute;
            if (attr == null)
            {
                return string.Empty;
            }
            return attr.StringValue;
        }
    }
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
        public string StringValue
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }
    }
}
