using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Max.Web.PayApi.Common
{
    public class ProcessorFactory : IProcessorFactory
    {
        private Func<string, IProcessor> create;

        public ProcessorFactory(Func<string, IProcessor> create)
        {
            this.create = create;
        }

        public IProcessor Create(string bizCode)
        {
            return this.create(bizCode);
        }
    }

    public static class ProcessorUtil
    {
        //private static Regex regexRequest = new Regex("^Request[0-9]+$", RegexOptions.Compiled);
        //private static Dictionary<string, Type> dicRequest = new Dictionary<string, Type>();
        //private static Dictionary<string, string> dicBizCode = new Dictionary<string, string>();

        static ProcessorUtil()
        {
            //var types = Assembly.GetAssembly(typeof(IProcessor)).GetTypes()
            //   .Where(t => t.IsSubclassOf(typeof(IProcessor)));
            //foreach (var type in types)
            //{
            //    var description = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //    if (description.Length > 0)
            //    {
            //        //dicRequest.Add(description[0].Description, type);
            //        dicBizCode.Add(description[0].Description, type.Name);
            //    }
            //}



            //================================
            //try
            //{
            //    dicRequest = Assembly.GetExecutingAssembly().GetTypes()
            //   .Where(t => regexRequest.IsMatch(t.Name))
            //   .ToDictionary(t => regexBizCode.Match(t.Name).Value, t => t);
                
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            //var members = typeof(Max.Web.PayApi.Common.ApiEnum.BizCode).GetMembers();
            //var enumDic = new Dictionary<string, string>();
            //foreach (var val in Enum.GetValues(typeof(Max.Web.PayApi.Common.ApiEnum.BizCode)))
            //{
            //    enumDic.Add(Enum.GetName(typeof(Max.Web.PayApi.Common.ApiEnum.BizCode), val), Convert.ToInt32(Enum.Parse(typeof(Max.Web.PayApi.Common.ApiEnum.BizCode), val.ToString())).ToString());
            //}

            //foreach (var m in members)
            //{
            //    var desc = m.GetCustomAttributes(typeof(DescriptionAttribute), true)
            //            .Cast<DescriptionAttribute>()
            //            .FirstOrDefault();
            //    if (desc != null && !string.IsNullOrEmpty(desc.Description))
            //        dicBizCode.Add(desc.Description, enumDic[m.Name]);
            //}

           
        }

        //public static BaseRequest GetRequest(string bizCode, string json)
        //{
        //    try
        //    {
        //        if (!dicRequest.ContainsKey(bizCode))
        //            return null;
        //        if (string.IsNullOrEmpty(json))
        //        {
        //            Type t = dicRequest[bizCode];
        //            return Activator.CreateInstance(t) as BaseRequest;
        //        }
        //        return JsonConvert.DeserializeObject(json, dicRequest[bizCode]) as BaseRequest;
        //    }
        //    catch { return null; }
        //}

        public static List<Type> GetProcessors()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IProcessor)))
                .ToList();
        }

        private static Regex regexBizCode = new Regex("[0-9]+$", RegexOptions.Compiled);

        public static string GetBizCode(Type type)
        {
            //var match = regexBizCode.Match(type.Name);
            //if (match.Success)
            //    return match.Value;
            //throw new Exception("IProcessor：{0} 的命名规则不正确".Fmt(type.Name));


            var description = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (description.Length > 0)
            {
                //    dicRequest.Add(description[0].Description, type);
                //    dicBizCode.Add(description[0].Description, type.Name);
                return description[0].Description;
            }
            else
            {
                throw new Exception("IProcessor：{0} 未标记DescriptionAttribute特性".Fmt(type.Name));
            }
        }

        //public static string GetBizCode(string cmd)
        //{
        //    if (!dicBizCode.Keys.Contains(cmd)) return null;
        //    return dicBizCode[cmd];
        //}
        
    }

    
}