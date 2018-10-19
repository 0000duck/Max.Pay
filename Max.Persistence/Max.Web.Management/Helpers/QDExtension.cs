using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;

namespace Max.Web.Management.Helpers
{
    /// <summary>
    /// 扩展公用方法
    /// </summary>
    public static class QDExtension
    {
        #region 是否身份证号码格式
        /// <summary>
        /// 是否身份证号码格式
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsIDCard(this string InputStr)
        {
            if (InputStr.Length == 18)
            {
                bool check = CheckIDCard18(InputStr);
                return check;
            }
            else if (InputStr.Length == 15)
            {
                bool check = CheckIDCard15(InputStr);
                return check;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 根据身份证获取年龄
        /// <summary>
        /// 根据身份证获取年龄
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static int GetAgeFromIDCard(this string identityCard)
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
        #endregion

        #region 根据身份证获取性别
        /// <summary>
        /// 根据身份证获取性别
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static string GetGenderFromIDCard(this string InputStr)
        {
            string gender = "未知";
            if (InputStr.IsIDCard())
            {
                if (InputStr.Length == 18)
                {
                    int g = Convert.ToInt32(InputStr.Substring(14, 3));
                    if (g % 2 == 0)
                        gender = "女";
                    else
                        gender = "男";
                }
                else if (InputStr.Length == 15)
                {
                    int g = Convert.ToInt32(InputStr.Substring(12, 3));
                    if (g % 2 == 0)
                        gender = "女";
                    else
                        gender = "男";
                }
            }
            return gender;
        }
        #endregion

        #region 私有方法
        private static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        #endregion

        #region 字符串格式转日期格式（例如20160101转2016-01-01）
        public static string ConvertDate(string time)
        {
            return DateTime.ParseExact(time, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
        }
        #endregion

        #region 检查小数位是否正确
        /// <summary>
        /// 检查小数位是否正确
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="digits">几位小数</param>
        /// <returns></returns>
        public static bool CheckDigits(this decimal InputStr, int digits)
        {
            //数值(包括整数和小数)正则表达式
            string format = @"^[0-9]+(\.[0-9]{0," + digits + "})?$";
            Regex _numericregex = new Regex(format);
            return _numericregex.IsMatch(InputStr.ToString());
        }
        #endregion
        #region 检查是否正整数
        /// <summary>
        /// 检查是否正整数
        /// </summary>
        /// <param name="InputStr">输入字符串</param>        
        /// <returns></returns>
        public static bool IsInt(this int InputStr)
        {

            string format = @"^[0-9]+$";
            Regex _numericregex = new Regex(format);
            return _numericregex.IsMatch(InputStr.ToString());
        }
        #endregion

        #region 检查小数位是否正确
        /// <summary>
        /// 检查小数位是否正确
        /// </summary>
        /// <param name="InputStr">输入字符串</param>
        /// <param name="digits">几位小数</param>
        /// <returns></returns>
        public static bool CheckDigits(this string InputStr, int digits)
        {
            //数值(包括整数和小数)正则表达式
            string format = @"^[0-9]+(\.[0-9]{0," + digits + "})?$";
            Regex _numericregex = new Regex(format);
            return _numericregex.IsMatch(InputStr);
        }
        #endregion
        #region 检查是否正整数
        /// <summary>
        /// 检查是否正整数
        /// </summary>
        /// <param name="InputStr">输入字符串</param>        
        /// <returns></returns>
        public static bool IsInt(this string InputStr)
        {

            string format = @"^[0-9]+$";
            Regex _numericregex = new Regex(format);
            return _numericregex.IsMatch(InputStr);
        }
        #endregion

        #region 检查日期格式
        /// <summary>
        /// 检查日期格式（2016-01-02）
        /// </summary>
        /// <param name="InputStr">输入字符串</param>        
        /// <returns></returns>
        public static bool CheckDate(this string InputStr)
        {
            string format = @"^(\d{4})-(\d{2})-(\d{2})$";
            Regex _numericregex = new Regex(format);
            return _numericregex.IsMatch(InputStr);
        }
        #endregion

        #region 去除HTML格式
        public static string NoHtml(this string Htmlstring)
        {
            if (Htmlstring.Length > 0)
            {
                //删除脚本
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&ldquo;", "\"", RegexOptions.IgnoreCase);//保留【 “ 】的标点符合
                Htmlstring = Regex.Replace(Htmlstring, @"&rdquo;", "\"", RegexOptions.IgnoreCase);//保留【 ” 】的标点符合
                Htmlstring = Regex.Replace(Htmlstring, @"\n", " ", RegexOptions.IgnoreCase);//保留【 ” 】的标点符合
                Htmlstring.Replace("<", "");
                Htmlstring.Replace(">", "");
                Htmlstring.Replace("\r\n", "");
            }
            return Htmlstring;
        }
        #endregion

        #region
        public static decimal? ToFixed(this decimal? d, int s)
        {
            decimal dc = (decimal)d;
            decimal sp = Convert.ToDecimal(Math.Pow(10, s));

            if (d < 0)
                return Math.Truncate(dc) + Math.Ceiling((dc - Math.Truncate(dc)) * sp) / sp;
            else
                return Math.Truncate(dc) + Math.Floor((dc - Math.Truncate(dc)) * sp) / sp;
        }
        #endregion
    }
}