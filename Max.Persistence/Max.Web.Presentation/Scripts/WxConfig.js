wxCofig = {};
wxShareData = {};
$.ajax({
    async: false,
    type: "post",
    data: "url=" + encodeURIComponent(location.href.split('#')[0]),
    url: "/Weixin/GetWeixinConfig",
    success: function (jsonResult) {
        wxCofig.appId = jsonResult.Data.appId;
        wxCofig.timestamp = jsonResult.Data.jsConfig.Timestamp;
        wxCofig.nonceStr = jsonResult.Data.jsConfig.Noncestr;
        wxCofig.signature = jsonResult.Data.jsConfig.Signdata;
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: wxCofig.appId, // 必填，公众号的唯一标识
            timestamp: wxCofig.timestamp, // 必填，生成签名的时间戳
            nonceStr: wxCofig.nonceStr, // 必填，生成签名的随机串
            signature: wxCofig.signature, // 必填，签名，见附录1
            jsApiList: ['onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ', 'hideMenuItems'] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });


        //微信分享config
        wx.ready(function () {
            // 要隐藏的菜单项，所有menu项见附录3
            wx.hideMenuItems({
                menuList: [
                'menuItem:share:QZone'
                ]
            });
            wx.onMenuShareAppMessage(wxShareData);
            wx.onMenuShareTimeline(wxShareData);
            wx.onMenuShareQQ(wxShareData);
        });
        wx.error(function (res) {
            //alert(res.errMsg);
        });

    },
    error: function (jsonResult) {
        //alert(jsonResult.Message);
    }
});



