using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Models
{
    #region 文案

    public class ShakeResult
    {
        public int AvailableShakeTimes { get; set; }
        public int NoAccountHighChance { get; set; }
        public float ShareInterest { get; set; }
        public string ShakeRepeat { get; set; }
        public Noresult NoResult { get; set; }
        public Unavailableresult UnAvailableResult { get; set; }
        public Nobalanceresult NoBalanceResult { get; set; }
        public Highprofitresult HighProfitResult { get; set; }
        public Productresult ProductResult { get; set; }
        public Firstshakeresult FirstShakeResult { get; set; }
        public Shareresult ShareResult { get; set; }
        public NotAllowShake NotAllowShake { get; set; }
    }

    public class Noresult
    {
        public string Title { get; set; }
        public string[] Description { get; set; }
    }

    public class Unavailableresult
    {
        /// <summary>
        /// 是否显示功能按钮
        /// </summary>
        public bool ShowBtn { set; get; }

        /// <summary>
        /// 是否显示分享按钮
        /// </summary>
        public bool ShowShareBtn { set; get; }
        public string Title { get; set; }
        public string Description { get; set; }

        public BtnInfo btnInfo { set; get; }

        public string SharebtnTitle { set; get; }

        public string AfterShareBtnTitle { get; set; }
        public string ImagUrl { set; get; }
        public string shareId { set; get; }

    }

    public class Nobalanceresult
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string MainTitle { set; get; }

    }

    public class Highprofitresult
    {
        public string Title { get; set; }
        public string BtnTitle { get; set; }
        public string Description { get; set; }
    }

    public class Productresult
    {
        public string Description { get; set; }
    }

    public class Firstshakeresult
    {
        public string InterestTitle { get; set; }
        public string InterestDescription { get; set; }
        public string ShareInterestTitle { get; set; }
        public string ShareInterestDescription { get; set; }
    }

    public class Shareresult
    {
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class NotAllowShake
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string Description { get; set; }
    }
    #endregion
}