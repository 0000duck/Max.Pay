using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Helpers
{
    public class FileHelper
    {

        public static void SaveFile(string path, string fileName, HttpPostedFileBase file)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            System.IO.Stream MyStream = file.InputStream;
            byte[] buffer = new byte[MyStream.Length];
            MyStream.Read(buffer, 0, buffer.Length);
            using (FileStream fsRead = new FileStream(path+fileName, FileMode.Create))
            {
                fsRead.Write(buffer, 0, buffer.Length);              
          
            } 
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileStream GetFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return File.OpenRead(path);
            }
            else
            {
                return null;
            }

        }

        public static bool ExistsFile(string path)
        {
            return File.Exists(path);
        }
    }
}