using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Common
{
    /// <summary>
    /// 商品标签颜色值
    /// </summary>
    public class TagColorConfig:ConfigurationSection
    {
        /// <summary>
        /// 第一个颜色值
        /// </summary>
        [ConfigurationProperty("FirstColor", IsRequired=true)]
        public string FirstColor
        {
            get { return (string)base["FirstColor"]; }
            set { base["FirstColor"] = value; }
        }

        /// <summary>
        /// 第二个颜色值
        /// </summary>
        [ConfigurationProperty("SecondColor", IsRequired = true)]
        public string SecondColor
        {
            get { return (string)base["SecondColor"]; }
            set { base["SecondColor"] = value; }
        }

        /// <summary>
        /// 第三个颜色值
        /// </summary>
        [ConfigurationProperty("ThirdColor", IsRequired = true)]
        public string ThirdColor
        {
            get { return (string)base["ThirdColor"]; }
            set { base["ThirdColor"] = value; }
        }
    }
}