using Max.Web.Management.Infrastructure;
using Max.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Max.Web.Management.Models.Common;

namespace Max.Web.Management.Controllers
{
    public class UploadController : Controller
    {

        private static readonly string FileServerUrl = "FileUploadUrl".ValueOfAppSetting();
        string uploadUrl = null;

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileType">文件类型 0代表图片 1代表视频···</param>
        /// <param name="InnerOrOut">内部或外部上传</param>
        /// <param name="businessDir">业务目录 例如是商品图片或者用户头像之类···</param>
        /// <param name="uploadFrom">上传来源 普通上传或者编辑器上传</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FileUpload(int fileType = 0, bool InnerOrOut = false, string businessDir = "common", int uploadFrom = 0)
        {
            //接口参数如下
            //string fileExt, int fileSize, int fileType = 0, bool InnerOrOut = true, string businessDir = "common", string originalName = null
            string result = null;

            try
            {
                HttpPostedFileBase file = Request.Files[0];//接收用户传递的文件数据.
                if (file == null || file.ContentLength <= 0)
                {
                    return Json(new { Code = 0, Message = "文件不存在或者文件大小为0" }, JsonRequestBehavior.AllowGet);
                }

                string fileName = Path.GetFileName(file.FileName);//获取文件名
                string fileExt = Path.GetExtension(fileName).ToLower();//获取文件扩展名

                string miniType = file.ContentType;

                byte[] buffer = new byte[file.InputStream.Length];
                uploadUrl = string.Format("{0}/File", FileServerUrl);

                uploadUrl = string.Format("{0}?fileExt={1}&fileSize={2}&fileType={3}&InnerOrOut={4}&businessDir={5}&originalName={6}",
                    uploadUrl,
                    fileExt,
                    file.ContentLength,
                    fileType,
                    InnerOrOut,
                    businessDir,
                    Server.UrlEncode(fileName)
                   );

                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                file.InputStream.Read(buffer, 0, buffer.Length);
                file.InputStream.Seek(0, SeekOrigin.Begin);
                var data = wc.UploadData(uploadUrl, "Post", buffer);
                result = Encoding.UTF8.GetString(data);
                if (uploadFrom == (int)UploadFrom.UMEditor编辑器上传)
                {
                    ResultResponse resultResponse = result.FromJson<ResultResponse>();
                    UploadFileInfo fileInfo = new UploadFileInfo();
                    if (resultResponse.Result != null)
                    {
                        fileInfo = resultResponse.Result.ToString().FromJson<UploadFileInfo>();
                    }
                    else
                    {
                        fileInfo.state = resultResponse.Message;
                    }

                    result = fileInfo.ToJson();

                    return Content(result);
                }


                return Content(result);
            }
            catch (Exception ex)
            {
                var webException = ex as WebException;
                if (!webException.IsNull())
                {
                    return Content(new { Code = 400, Message = ex.Message }.ToJson());
                }
                return Content(new { Code = 0, Message =ex.Message }.ToJson());
            }
        }


    }


    /// <summary>
    /// 文件上传来源
    /// </summary>
    public enum UploadFrom
    {
        普通文件上传 = 0,
        UMEditor编辑器上传 = 1
    }

    /// <summary>
    /// 文件上传类型
    /// </summary>
    public enum FileType
    {
        图片 = 0,
        视频 = 1
    }
}