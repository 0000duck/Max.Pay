using log4net;
using Max.BUS.Message.Log;
using Max.Framework.ESB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.Framework;
using Max.Framework.NoSql;
using System.Web;
using System.Text.RegularExpressions;

namespace Max.BUS.ApiLog
{
    public class MainService
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));
        private IServiceBus bus;
        private IMongoProxy mongo;

        public MainService(IServiceBus bus, IMongoProxy mongo)
        {
            this.bus = bus;
            this.mongo = mongo;
        }

        public bool Start()
        {
            try
            {
                this.bus.Subscribe<ApiLogMessage>("", msg =>
                {
                    FilterPassword(msg);
                    log.Info(msg.ToJson());
                    var dbName = "ApiLog"+DateTime.Now.ToString("yyyyMM");
                    var colName = msg.Cmd ?? "Default";
                    mongo.InsertOne(dbName, colName, msg);
                });

                log.Info("服务已启动");
                return true;
            }
            catch (Exception ex)
            {
                log.Error("服务启动失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 过滤密码明文
        /// </summary>
        /// <param name="msg"></param>
        private void FilterPassword(ApiLogMessage msg)
        {
            try
            {
                switch (msg.Cmd)
                {
                    case "My.SetLoginPwd":
                        Regex slpRegex = new Regex(@"(?<=""Password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, slpRegex);
                        break;
                    case "My.UpdateLoginPwd":
                        Regex ulpRegex = new Regex(@"(?<=Password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, ulpRegex);
                        break;
                    case "My.UpdatePayPwd":
                        Regex uppRegex = new Regex(@"(?<=Password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, uppRegex);
                        break;
                    case "My.PwdLogin":
                        Regex plRegex = new Regex(@"(?<=""Password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, plRegex);
                        break;
                    case "My.SetPayPwd":
                        Regex sppRegex = new Regex(@"(?<=""Password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, sppRegex);
                        break;
                    case "Invest.PayOrder":
                        Regex payOrderRegex = new Regex(@"(?<=""payCode""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, payOrderRegex);
                        break;
                    case "Mall.Pay":
                        Regex payRegex = new Regex(@"(?<=""pwd""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, payRegex);
                        break;
                    case "My.Register":
                        Regex registerRegex = new Regex(@"(?<=""password""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, registerRegex);
                        break;
                    case "My.CheckPayPwd":
                        Regex checkPayPwdRegex = new Regex(@"(?<=""PayPass""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, checkPayPwdRegex);
                        break;
                    case "My.WithdrawRP":
                        Regex withdrawRPRegex = new Regex(@"(?<=""PayPwd""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, withdrawRPRegex);
                        break;
                    case "CreditEx.ConfirmRepay":
                        Regex confirmRepayRegex = new Regex(@"(?<=""pwd""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, confirmRepayRegex);
                        break;
                    case "VehicleInsurance.PayOrder":
                        Regex vpayOrderRegex = new Regex(@"(?<=""payCode""\s*?:\s*?"")(.*?)(?="")", RegexOptions.IgnoreCase);
                        ReplacePassword(msg, vpayOrderRegex);
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("过滤密码明文失败", ex);
            }
        }

        private void ReplacePassword(ApiLogMessage msg, Regex regx)
        {
            var requestJson = msg.RequestJson;
            var requestDataStr = msg.RequestDataStr;
            requestDataStr = HttpUtility.UrlDecode(requestDataStr);
            requestDataStr = Base64Utils.DecodeBase64String(requestDataStr);
            requestJson = regx.Replace(requestJson, new MatchEvaluator(Match));
            requestDataStr = regx.Replace(requestDataStr, new MatchEvaluator(Match));
            requestDataStr = Base64Utils.EncodeBase64String(requestDataStr);
            requestDataStr = HttpUtility.UrlEncode(requestDataStr);
            msg.RequestJson = requestJson;
            msg.RequestDataStr = requestDataStr;
        }

        private static string Match(Match match)
        {
            return "******";
        }

        public bool Stop()
        {
            return true;
        }
    }
}
