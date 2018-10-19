using Max.Framework;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Max.Web.Presentation.Controllers
{
    public class UploadController : Controller
    {
        private readonly string FileServerUrl = "FileUploadUrl".ValueOfAppSetting();

        [HttpPost]
        public ActionResult FileUpload(string FileData, string FileName, string FileSize, int fileType = 0, bool InnerOrOut = false, string businessDir = "HuiXiaoFei")
        {
            try
            {
                if (FileData.IsNullOrWhiteSpace())
                {
                    return Content(new { Code = 400, Message = "上传文件为空" }.ToJson());
                }
                var data = FileData.Split(',');
                if (data[1].IsNullOrWhiteSpace())
                {
                    return Content(new { Code = 400, Message = "上传文件为空" }.ToJson());
                }

                var file = Convert.FromBase64String(data[1]);

                string fileExt = Path.GetExtension(FileName).ToLower();//获取文件扩展名

                string uploadUrl = string.Format("{0}/File", FileServerUrl);

                uploadUrl = string.Format("{0}?fileExt={1}&fileSize={2}&fileType={3}&InnerOrOut={4}&businessDir={5}&originalName={6}",
                    uploadUrl,
                    fileExt,
                    FileSize,
                    fileType,
                    InnerOrOut,
                    businessDir,
                    Server.UrlEncode(FileName)
                );

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                var response = webClient.UploadData(uploadUrl, "Post", file);

                return Content(Encoding.UTF8.GetString(response).ToJson());
            }
            catch (Exception ex)
            {
                return Content(new { Code = 400, Message = ex.Message }.ToJson());
            }
        }
    }
}