using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Max.Framework;
using System.Text.RegularExpressions;

namespace Max.Web.Management.Helpers
{
    public class CarLoanFinanceApplyHeper
    {
        public static bool DocxReplace(string fileName,string newFileName,Dictionary<string,string> date)
        {
            try
            {
                date = date.ToDictionary(p => p.Key.ToLower(), v => v.Value);
                if (fileName.Substring(0, 1) != "/")
                {
                    fileName = "/" + fileName;
                }
                if (newFileName.Substring(0, 1) != "/")
                {
                    newFileName = "/" + newFileName;
                }
                using (FileStream stream = System.IO.File.OpenRead(GetAboPath(fileName)))
                {

                    XWPFDocument doc = new XWPFDocument(stream);

                    foreach (var para in doc.Paragraphs)
                    {
                        string cell_value = para.ParagraphText;
                        var cell_value_trim = cell_value.Trim();
                        if (cell_value_trim.IsNullOrWhiteSpace())
                        {
                            continue;
                        }
          
                        var paras = para.Runs.Where(p => date.Keys.Contains(p.Text.Trim().ToLower()));
                        foreach (var run in paras)
                        {
                            var runValue = run.Text.ToLower(); ;
                            if (date.Any(p =>p.Key==runValue))
                            {
                               runValue = runValue.Replace(runValue, date[runValue]);
                                run.SetText(runValue);
                            }
                        }
                    }

                    using (FileStream fs = new FileStream(GetAboPath(newFileName), FileMode.Create, FileAccess.Write))
                    {
                        doc.Write(fs);

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public static byte[] DocxReplaceToByte(string fileName, string newFileName, Dictionary<string, string> date)
        {
            try
            {
                if (fileName.Substring(0, 1) != "/")
                {
                    fileName = "/" + fileName;
                }
                if (newFileName.Substring(0, 1) != "/")
                {
                    newFileName = "/" + newFileName;
                }
                fileName=GetAboPath(fileName);
                newFileName=GetAboPath(newFileName);
                date = date.ToDictionary(p => p.Key.ToLower(), v => v.Value);
               
       
                using (FileStream stream = System.IO.File.OpenRead(fileName))
                {

                    XWPFDocument doc = new XWPFDocument(stream);

                    foreach (var para in doc.Paragraphs)
                    {
                        string cell_value = para.ParagraphText;
                        var cell_value_trim = cell_value.Trim();
                        if (cell_value_trim.IsNullOrWhiteSpace())
                        {
                            continue;
                        }

                        var paras = para.Runs.Where(p => date.Keys.Contains(p.Text.Trim().ToLower()));
                        foreach (var run in paras)
                        {
                            var runValue = run.Text.ToLower(); ;
                            if (date.Any(p => p.Key == runValue))
                            {
                                runValue = runValue.Replace(runValue, date[runValue]);
                                run.SetText(runValue);
                            }
                        }
                    }

                    using (FileStream fs = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
                    {
                        doc.Write(fs);
                    }


                    byte[] pReadByte = new byte[0];
                    using (FileStream _filStream = new FileStream(newFileName, FileMode.Open, FileAccess.Read))
                    {
                            BinaryReader r = new BinaryReader(_filStream);

                            r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开  

                            pReadByte = r.ReadBytes((int)r.BaseStream.Length);

                    }
                    System.IO.File.Delete(newFileName);
                    return pReadByte;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static string GetAboPath(string path)
        {
            return System.Web.HttpContext.Current.Server.MapPath(path);
        }


        private static String[] Ls_ShZ = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
        private static String[] Ls_DW_Zh = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
        private static String[] Num_DW = { "", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
        private static String[] Ls_DW_X = { "角", "分" };

        /// <summary>
        /// 金额小写转中文大写。
        /// 整数支持到万亿；小数部分支持到分(超过两位将进行Banker舍入法处理)
        /// </summary>
        /// <param name="Num">需要转换的双精度浮点数</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertToChinese(double x)
        {
            var mantissa = "";
            int i = (int)x;
            if (x-i<=0)
            {
                mantissa = "整";
            }
            string s = x.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");                     
            return Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟萬億兆京垓秭穰"[m.Value[0] - '-'].ToString())+mantissa;
        } 
    }
}