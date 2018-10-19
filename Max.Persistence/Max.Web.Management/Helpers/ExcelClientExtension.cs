using NPOI;
using NPOI.XSSF.UserModel;
using Max.Framework.File;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Max.Web.Management.Helpers
{
    public static class ExcelClientExtension
    {
        public static void MultiSheetHttpExport(this IExcelClient client, Dictionary<Type, List<object>> source, string fileName="")
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            CreateExcel(source, wb);
            if (string.IsNullOrEmpty(fileName))
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xlsx", fileName));
            wb.Write(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        private static void CreateExcel(Dictionary<Type, List<object>> source, XSSFWorkbook wb)
        {
            int sheetCount = 0;
            foreach (var key in source.Keys)
            {
                sheetCount++;
                string sheetName = "Sheet" + sheetCount;
                var classdisplay = key.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .Cast<DisplayNameAttribute>()
                        .FirstOrDefault();
                if (classdisplay != null)
                {
                    sheetName = classdisplay.DisplayName;
                }
                var sh = (XSSFSheet)wb.CreateSheet(sheetName);

                POIXMLProperties props = wb.GetProperties();
                props.CoreProperties.Creator = "广东钱端商务服务有限公司";
                props.CoreProperties.Created = DateTime.Now;

                var properties = key.GetProperties().ToList();

                //构建表头
                var header = sh.CreateRow(0);
                for (var j = 0; j < properties.Count; j++)
                {
                    var display = properties[j].GetCustomAttributes(typeof(DisplayAttribute), true)
                        .Cast<DisplayAttribute>()
                        .FirstOrDefault();
                    if (display != null)
                        header.CreateCell(j).SetCellValue(display.Name);
                    else
                        header.CreateCell(j).SetCellValue(properties[j].Name);
                }
                var list = source[key];

                //填充数据
                for (var i = 0; i < list.Count; i++)
                {
                    var r = sh.CreateRow(i + 1);
                    for (var j = 0; j < properties.Count; j++)
                    {
                        var value = properties[j].GetValue(list[i], null);
                        r.CreateCell(j).SetCellValue(value == null ? "" : value.ToString());
                    }
                }
            }
        }

    }
}