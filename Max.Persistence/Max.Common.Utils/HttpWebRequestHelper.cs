using System.IO;
using System.Net;

namespace Max.Common.Utils
{
    public class HttpWebRequestHelper
    {
        /// <summary>
        /// PostXml帮助方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="streamValue"></param>
        /// <returns></returns>
        public static string PostXml(string url, string streamValue)
        {
            var objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            //objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "text/xml"; //提交xml 
            using (var myWriter = new StreamWriter(objRequest.GetRequestStream()))
            {
                myWriter.Write(streamValue);
            }
            var objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (var sr = new StreamReader(objResponse.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}

