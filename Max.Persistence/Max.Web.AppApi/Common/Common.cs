using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq; 
using System.IO; 
using System.Text;
using System.Web.Script.Serialization;
using Max.Framework;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace Max.Web.AppApi.Common
{
    public static class Common
    {
        #region 获取UserUniqueID
        public static string GetUserUniqueID(string userID)
        {
            string AppDesSecretKey = "UserUniqueIDDesSecretKey".ValueOfAppSetting() ?? "83j5WmUh";

            return DESUtil.Encrypt(userID, AppDesSecretKey);
        }
        #endregion

        #region 获取图片地址
        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="picId">图片Id</param>
        /// <param name="picType">0:原图 1：缩略图 2：中图 3：小图</param>
        /// <returns></returns>
        public static string PicPath(string picId, int picType, string domain = "")
        {
            var picUrl = string.Empty;
            string[] _PicTypeMap_ = { "jpg", "jpeg", "bmp", "png", "gif" };

            if (!string.IsNullOrWhiteSpace(picId))
            {
                try
                {
                    var picArr = picId.Split('-');
                    var picDomain = domain.IsNullOrWhiteSpace() ? "PicServiceUrl".ValueOfAppSetting() : domain;
                    picUrl = picDomain + '/' + picType + '/' + picArr[1] + '/' + picId + '.' + _PicTypeMap_[int.Parse(picArr[3])];
                }
                catch (Exception ex)
                {
                    

                }
            }
            return picUrl;
        }
        #endregion

        /// <summary>
        /// 字符串去掉制表符、换行符、空格
        /// </summary>
        /// <param name="str">输入字符</param>
        /// <returns>处理过后的字符</returns>
        public static string ReplaceSpecialChar(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
                return Regex.Replace(str, @"\s", "");
            return str;
        }
    }
}
