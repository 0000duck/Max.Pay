using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Models
{
    public class UserData
    {
        public string EPlusAccountId { get; set; }
        public string IDCard { get; set; }
        public string InstitutionNo { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string UserId { get; set; }
        public string Usrnbr { get; set; }
    }

    public class RequestData
    {
        public object body { get; set; }
        public string cmd { get; set; }
        public Head head { get; set; }
    }

    public class Head
    {
        public string appVersion { get; set; }
        public string clientModel { get; set; }
        public string iMEI { get; set; }
        public string oSVersion { get; set; }
        public string reqTime { get; set; }
        public string sN { get; set; }
        public string sessionid { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string ip { get; set; }
        public string location { get; set; }
        public string deviceBrans { get; set; }
        public string channelId { get; set; }
        public string macAddress { get; set; }
        public string sSN { get; set; }

        /// <summary>
        /// 手机是否越狱(越狱设备，登录不返回任何指纹信息)
        /// </summary>
        public bool HasJailbreak { get; set; }

        /// <summary>
        /// 操作系统类型
        /// </summary>
        public OsEnum OS
        {
            get
            {
                if (String.IsNullOrEmpty(oSVersion))
                {
                    return OsEnum.Unknown;
                }

                OsEnum os = OsEnum.Unknown;
                string str = oSVersion.Trim().ToLower().Substring(0, 1);
                switch (str)
                {
                    case "a":
                        os = OsEnum.Android;
                        break;
                    case "i":
                        os = OsEnum.IOS;
                        break;
                    case "w":
                        os = OsEnum.Web;
                        break;
                }

                return os;
            }
        }

    }

    /// <summary>
    /// 操作系统类型
    /// </summary>
    public enum OsEnum
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        IOS = 1,

        Android = 2,

        Web
    }

    /// <summary>
    /// 安全选项分值
    /// </summary>
    public class SecOptionAmount
    {
        public int Id { set; get; }
        public float Amount { set; get; }

        public string Name { set; get; }

    }

    public class YQBProduct
    {
        /// <summary>
        /// 商品图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// 闪惠价
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }
    }


    public class RequestPayModel
    {
        [Required]
        public string MerchantNo { get; set; }
        [Required]
        public string PayType { get; set; }
        [Required]
        public string MerchantOrderNo { get; set; }
        [Required]
        public string MerchantOrderTime { get; set; }
        [Required]
        public string OrderAmount { get; set; }
        [Required]
        public string NotifyUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string DeviceType { get; set; }
        public string OrderDescription { get; set; }
        public string ExtendField { get; set; }
        public string Ip { get; set; }
        [Required]
        public string Sign { get; set; }


    }
}