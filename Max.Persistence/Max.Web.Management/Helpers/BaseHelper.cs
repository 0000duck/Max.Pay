using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Max.Framework;

namespace Max.Web.Management.Helpers
{
    public class BaseHelper
    {
        /// <summary>
        /// 根据身份证号码获取性别
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public static string GetSex(string identityCard)
        {
            if (identityCard.IsNullOrWhiteSpace())
            {
                return "";
            }
            if (identityCard.Length != 18 && identityCard.Length != 15)
            {
                return "";
            }
            string sex = null;
            if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到性别代码
            {
                
                sex = identityCard.Substring(14, 3);
            }
            if (identityCard.Length == 15)
            {              
                sex = identityCard.Substring(12, 3);
            }
            return int.Parse(sex) % 2 == 0 ? "女" : "男";
        }


        /// <summary>
        /// 根据身份证号码获取年龄
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public static int GetAge(string identityCard)
        {

            if (identityCard.IsNullOrWhiteSpace())
            {
                return 0;
            }
            if (identityCard.Length != 18 && identityCard.Length != 15)
            {
                return 0;
            }
            string cardBirthday = string.Format("{0}/{1}/{2}", string.Format("19{0}", identityCard.Substring(6, 2)),
                identityCard.Substring(8, 2),
                identityCard.Substring(10, 2));
            if (identityCard.Length == 18)
            {
                cardBirthday = string.Format("{0}/{1}/{2}", identityCard.Substring(6, 4), identityCard.Substring(10, 2),
                    identityCard.Substring(12, 2));
            }
            DateTime birthday;
            if (DateTime.TryParse(cardBirthday, out birthday))
            {
                DateTime now = DateTime.Now;
                int age = now.Year - birthday.Year;
                if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day)) age--;
                return age;
            }
            return 0;

        }

        /// <summary>
        /// 显示格式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ShowCount">显示多少个字符</param>
        /// <param name="IsFront">true显示前面，flse显示后面</param>
        /// <returns></returns>
        public static string ShowStr(string str,int ShowCount,bool IsFront )
        {
            if (str.IsNullOrWhiteSpace())
            {
                return "";
            }
            var _lenght = str.Length;
            if (ShowCount >= _lenght)
            {
                return str;
            }
            var _str="";
            if (IsFront)
            {
                _str = str.Substring(0, ShowCount);
                return _str.PadRight(_lenght,'*');
            }
            else
            {
                _str = str.Substring(_lenght - ShowCount);
                return _str.PadLeft(_lenght, '*');
            }
          
        }
    }
}