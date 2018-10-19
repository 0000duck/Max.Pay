using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Max.Framework;
using System.Security.Cryptography;

namespace Max.Web.Presentation.Common
{
    public class ImagePath
    {
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
    }
}