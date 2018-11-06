using System;
using System.Web.Mvc;
using Max.Framework;
using Max.Framework.DAL;
using System.Text;
using Max.Service.Payment;
using Max.Models.Payment;
using Max.Web.Presentation.Common;
using Max.Web.Presentation.Business.Response;

namespace Max.Web.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private IProcessorFactory factory;
        private PayChannelService _payChannelService;
        private PayOrderService _payOrderService;
        public HomeController(IProcessorFactory factory, PayChannelService payChannelService,
             PayOrderService payOrderService)
        {
            this.factory = factory;
            this._payChannelService = payChannelService;
            this._payOrderService = payOrderService;
        }

        public ActionResult Index(string orderId)
        {
            var response = new BaseResponse();
            BaseRequest baseRequest = new BaseRequest();
            ServiceResult result = new ServiceResult();
            var bizCode = string.Empty;
            string errMsg = "";
            PayOrder order = null;
            PayChannel payChannel = null;

            if (orderId.IsNullOrWhiteSpace())
            {
                return Json(result.IsFailed("参数错误，orderid"));
            }
            //订单校验
            if (!OrderVerify(orderId, out order, out payChannel, out errMsg))
            {
                return Json(result.IsFailed(errMsg));
            }

            baseRequest.Order = order;
            baseRequest.PayChannel = payChannel;
            bizCode = payChannel.ChannelCode;
            if (bizCode.IsNullOrWhiteSpace())
            {
                return Json(result.IsFailed("无效交易类型,ChannelCode为空"));
            }

            if (!ProcessorUtil.BizCodeValid(bizCode))
            {
                return Json(result.IsFailed("支付标识和DescriptionAttribute不一致"));
            }
            var processor = this.factory.Create(bizCode);

            //构建请求参数
            var payParams = processor.CreatePayRequest(baseRequest);
            //如果是浏览器表单提交
            if (processor.IsPostForm)
            {
                ViewData["url"] = processor.PayUrl;
                ViewData["method"] = processor.RequestMethod;
                return View(payParams);
            }

            //异步请求
            PayResponse payResponse = processor.Process(payParams);
            if (!payResponse.Success)
            {
                return Json(result.IsFailed(payResponse.Message));
            }
            switch (processor.PayModel)
            {
                case PayModelEnum.无:
                    break;
                case PayModelEnum.URL跳转:
                    return Redirect(payResponse.Data);
                case PayModelEnum.扫码:
                    break;
                case PayModelEnum.二维码生成:
                    break;
                case PayModelEnum.HTML输出:
                    return Content(payResponse.Data, "text/html");
                default:
                    break;
            }
            return View();
        }

        /// <summary>
        /// 验证商户
        /// </summary>
        /// <param name="model"></param>
        /// <param name="merchant"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool OrderVerify(string orderId, out PayOrder payOrder, out PayChannel payChannel, out string msg)
        {

            msg = "";
            payChannel = null;
            payOrder = null;

            var order = this._payOrderService.Get(c => c.OrderId == orderId);
            payOrder = order;

            if (order.IsNull())
            {
                msg = "订单不存在";
                return false;
            }

            var channel = this._payChannelService.Get(c => c.ChannelId == order.ChannelId);
            payChannel = channel;

            if (channel.IsNull())
            {
                msg = "渠道不存在";
                return false;
            }

            return true;
        }
    }
}