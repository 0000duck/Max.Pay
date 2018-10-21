/*
 * 本文件由根据实体插件自动生成，请勿更改
 * =========================== */

using System;
using Max.Framework.MVC;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Max.Models.Payment
{
    public class V_MerchantPayProduct 
    {

        public string MerchantPayServiceId{ get; set; }

        public int IsOpen{ get; set; }

        public int? Status{ get; set; }

        public string PayChannelId{ get; set; }

        public string CreateBy{ get; set; }

        public int ServiceType{ get; set; }

        public string ChannelName{ get; set; }

        public decimal? AgentFeeRate{ get; set; }

        public string ServiceId{ get; set; }

        public int? Isdelete{ get; set; }

        public string Remark{ get; set; }

        public decimal? FeeRate{ get; set; }

        public string ServiceCode{ get; set; }

        public string MerchantId{ get; set; }

        public decimal? MerchantFeeRate{ get; set; }

        public DateTime? CreateTime{ get; set; }

        public string MerchantName{ get; set; }

        public string ServiceName{ get; set; }

    }
}