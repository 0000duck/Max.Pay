using Max.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Common
{
    /// <summary>
    /// 获取手机端跳转链接地址
    /// </summary>
    public class APPUrl
    {
        /// <summary>
        /// 不跳转
        /// </summary>
        /// <returns></returns>
        public static string GetNoJumpUrl(int type = 0)
        {
            return string.Format("Mall:ProductCategory?Type={0}", type);
        }

        /// <summary>
        /// 跳转链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static string GetJumpToLinkUrl(string link)
        {
            string url = "#";
            if(string.IsNullOrEmpty(link))
            {
                return GetNoJumpUrl();
            }

            if (link != "Mall:ProductCategory?Type=1" && link != "Mall:ProductCategory?Type=2" && !link.StartsWith("AppGlobal")) // 充值中心、全部专用
            {
                url = string.Format("Mall:MetroZone?Type=3&url={0}", link);
            }
            else
            {
                url = link;
            }

            return url;
        }

        /// <summary>
        /// 跳转到商户
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public static string GetJumpToMerchantUrl(string merchantId)
        {
            if (string.IsNullOrEmpty(merchantId))
            {
                return GetNoJumpUrl();
            }

            return string.Format("Mall:Supplier?id={0}", merchantId);
        }

        /// <summary>
        /// 跳转到商品详情
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static string GetJumpToProductDetailUrl(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return GetNoJumpUrl();
            }

            return string.Format("Mall:JumpToProductDetail?ProductId={0}", productId);
        }

        /// <summary>
        /// 跳转到项目详情
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="assetNo"></param>
        /// <returns></returns>
        public static string GetJumpToProjectDetailUrl(string projectId, string assetNo)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                return GetNoJumpUrl();
            }

            return string.Format("Mall:JumpToProjectDetail?ProjectId={0}&AssetNo={1}", projectId, assetNo);
        }

        /// <summary>
        /// 跳转到商品分类
        /// </summary>
        /// <param name="title"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static string GetJumpToProductCategoryUrl(string title, string categoryId)
        {
            string url = "#";
            if (title == "充值中心")
            {
                url = "Mall:ProductCategory?Type=1";
            }
            else if (title == "全部")
            {
                url = "Mall:ProductCategory?Type=2";
            }
            else if (string.IsNullOrEmpty(categoryId))
            {
                return GetNoJumpUrl();
            }
            else
            {
                url = string.Format("Mall:ProductCategory?Type={0}&orderBy=1&isNeedJump=1", categoryId);
            }

            return url;
        }

        /// <summary>
        /// 跳转到专场
        /// </summary>
        /// <param name="specialActivityId"></param>
        /// <returns></returns>
        public static string GetJumpToSpecialActivity(string specialActivityId)
        {
            if (string.IsNullOrEmpty(specialActivityId))
            {
                return GetNoJumpUrl();
            }

            return string.Format("Mall:MetroZone?Type=2&id={0}", specialActivityId);
        }

        /// <summary>
        /// 跳转到原生登录
        /// </summary>
        /// <returns></returns>
        public static string GetJumpToLoginUrl()
        {
            return "Appglobal:GType=12";
        }

        /// <summary>
        /// 跳转到实名认证
        /// </summary>
        /// <returns></returns>
        public static string GetJumpToAuthed()
        {
            return "Appglobal:GType=14";
        }

        public static string GetJumpToBankCardList()
        {
            return "AppGlobal:GType=21";
        }

        /// <summary>
        /// 选择联系人
        /// </summary>
        /// <returns></returns>
        public static string GetJumpToSelectContactUrl(string tag = null)
        {
            if (tag.IsNullOrWhiteSpace())
                return "AppGlobal:GType=33";
            else
                return "AppGlobal:GType=33&tag=" + tag;
        }
    }
}