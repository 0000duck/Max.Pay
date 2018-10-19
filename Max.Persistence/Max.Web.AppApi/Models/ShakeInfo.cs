using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.AppApi.Models
{
    public class ShakeInfo
    {
        public int AvailableShakeTimes { set; get; }
        public string ShakeRepeat { set; get; }
        public Unavailableresult Unavailableresult { set; get; }

        public Nobalanceresult Nobalanceresult { set; get; }

        public float ShareInterest { get; set; }

        public NotAllowShake NotAllowShake { get; set; }
    }

    #region 按钮详细信息
    public class BtnInfo
    {
        /// <summary>
        /// 平台编号
        /// </summary>
        public string AssetNo { set; get; }

        /// <summary>
        /// 是否需要登录
        /// </summary>
        public bool IsNeedLogin { set; get; }

        /// <summary>
        /// 按钮标题
        /// </summary>
        public string BtnTitle { set; get; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 链接
        /// </summary>
        public string LinkAddr { set; get; }
    }
    #endregion

}