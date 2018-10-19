using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Max.Common.Utils.Encrypt;
using Max.Framework;

namespace Max.Web.OpenApi.Common.CarLoan
{
    public static class CarLoanOpenApiHelper
    {
        // DES密钥
        //private const string CARLOAN_DES_SECRET_KET = "";
        private static readonly string CarLoanDesSecretKey = "CarLoanDesSecretKey".ValueOfAppSetting() ?? "12345678";

        // 机构号（钱端提供给调用方，目前调用方只有安邦）
        private static readonly string CarLoanInstitutionNo = "CarLoanInstitutionNo_AnBang".ValueOfAppSetting() ?? "17000";

        /// <summary>
        /// 报文解密
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public static string DecryptRequestData(string requestData)
        {
            //// Base64 解码
            //var data = Base64Utils.DecodeBase64String(requestData);

            //if (string.IsNullOrEmpty(data))
            //{
            //    return string.Empty;
            //}

            // DES 解密
            var json = CryptographyUtils.DesDecrypt(requestData, CarLoanDesSecretKey);

            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }

            return json;
        }

        /// <summary>
        /// 校验报文内容
        /// </summary>        
        public static ServiceResult VerifyFormData(CarLoanFormData formData)
        {
            var result = new ServiceResult();

            if (formData.Head == null)
            {
                return result.IsFailed("报文格式不正确");
            }
            //if (string.IsNullOrEmpty(formData.Head.RequestAt))
            //{
            //    return result.IsFailed("请求时间不能为空");
            //}
            if (!Enum.IsDefined(typeof(CarLoanOpenApiEnums.BizCode), formData.Head.BizCode))
            {
                return result.IsFailed("业务编码不存在");
            }
            if (string.IsNullOrEmpty(formData.Head.InstitutionNo))
            {
                return result.IsFailed("机构号不能为空");
            }
            if (formData.Head.InstitutionNo != CarLoanInstitutionNo)
            {
                return result.IsFailed(string.Format("机构号[{0}]不存在", formData.Head.InstitutionNo));
            }

            return result.IsSucceed();
        }

        /// <summary>
        /// 校验 CheckSum
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCheckSum(string json, string checkSum)
        {
            return CryptographyUtils.MD5Encrypt(json).ToLower() == checkSum.ToLower();
        }
    }
}