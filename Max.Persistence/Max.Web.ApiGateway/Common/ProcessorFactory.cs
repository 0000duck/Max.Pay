using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Max.Web.ApiGateway.Common
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
        private static Regex regexRequest = new Regex("^Request[0-9]+$", RegexOptions.Compiled);
        private static Dictionary<string, Type> dicRequest = new Dictionary<string, Type>();
        private static Dictionary<string, string> dicBizCode = new Dictionary<string, string>();
        private static Dictionary<string, string[]> dicApiAliasList = new Dictionary<string, string[]>();

        static ProcessorUtil()
        {
            try
            {
               // dicRequest = Assembly.GetExecutingAssembly().GetTypes()
               //.Where(t => regexRequest.IsMatch(t.Name))
               //.ToDictionary(t => regexBizCode.Match(t.Name).Value, t => t);

                var types = Assembly.GetAssembly(typeof(Max.Web.ApiGateway.Common.BaseRequest)).GetTypes()
           .Where(t => t.IsSubclassOf(typeof(Max.Web.ApiGateway.Common.BaseRequest)));
                foreach (var type in types)
                {
                    var description = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (description.Length > 0)
                    {
                        dicRequest.Add(description[0].Description, type);
                        //dicBizCode.Add(description[0].Description, type.Name);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            var members = typeof(Max.Web.ApiGateway.Common.ApiEnum.BizCode).GetMembers();
            var enumDic = new Dictionary<string, string>();
            foreach (var val in Enum.GetValues(typeof(Max.Web.ApiGateway.Common.ApiEnum.BizCode)))
            {
                enumDic.Add(Enum.GetName(typeof(Max.Web.ApiGateway.Common.ApiEnum.BizCode), val), Convert.ToInt32(Enum.Parse(typeof(Max.Web.ApiGateway.Common.ApiEnum.BizCode), val.ToString())).ToString());
            }

            foreach (var m in members)
            {
                var desc = m.GetCustomAttributes(typeof(DescriptionAttribute), true)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault();
                if (desc != null && !string.IsNullOrEmpty(desc.Description))
                    dicBizCode.Add(desc.Description, enumDic[m.Name]);
            }

            foreach (var k in dicBizCode.Keys)
            {
                var deconstruct = k.Split(new string[] { "[" }, StringSplitOptions.RemoveEmptyEntries);
                if (deconstruct.Length == 0) continue;

                var cmd = deconstruct[0];
                if (dicApiAliasList.Keys.Contains(cmd)) continue;
                var prefix = "{0}[".Fmt(cmd);
                var apiAliasList = dicBizCode.Keys.Where(c => c.Equals(cmd, StringComparison.CurrentCultureIgnoreCase) || c.StartsWith(prefix, StringComparison.CurrentCultureIgnoreCase)).ToArray();

                for (int i = 0; i < apiAliasList.Length; i++)
                {
                    for (int j = i + 1; j < apiAliasList.Length; j++)
                    {
                        var item1 = apiAliasList[i].Replace(cmd, "").Replace("[", "").Replace("]", "").Trim();
                        var item2 = apiAliasList[j].Replace(cmd, "").Replace("[", "").Replace("]", "").Trim();

                        if (CompareVersion(item1, item2) < 0)
                        {
                            var temp = apiAliasList[j];
                            apiAliasList[j] = apiAliasList[i];
                            apiAliasList[i] = temp;
                        }
                    }
                }

                dicApiAliasList.Add(cmd, apiAliasList);
            }
        }

        public static BaseRequest GetRequest(string bizCode, string json)
        {
            try
            {
                if (!dicRequest.ContainsKey(bizCode))
                    return null;
                if (string.IsNullOrEmpty(json))
                {
                    Type t = dicRequest[bizCode];
                    return Activator.CreateInstance(t) as BaseRequest;
                }
                return JsonConvert.DeserializeObject(json, dicRequest[bizCode]) as BaseRequest;
            }
            catch { return null; }
        }

        public static List<Type> GetProcessors()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IProcessor)))
                .ToList();
        }

        private static Regex regexBizCode = new Regex("[0-9]+$", RegexOptions.Compiled);

        public static string GetBizCode(Type type)
        {
            var match = regexBizCode.Match(type.Name);
            if (match.Success)
                return match.Value;
            throw new Exception("IProcessor：{0} 的命名规则不正确".Fmt(type.Name));
        }

        public static string GetBizCode(string cmd, string appVersion)
        {
            if (!dicApiAliasList.Keys.Contains(cmd)) return null;

            var apiAliasList = dicApiAliasList[cmd];
            if (apiAliasList.Length == 1)
            {
                return dicBizCode[apiAliasList.First()];
            }

            // 当前业务编码存在多版本API
            for (int i = 0; i < apiAliasList.Length; i++)
            {
                var apiAlias = apiAliasList[i];
                var deconstruct = apiAlias.Split(new string[] { "[" }, StringSplitOptions.RemoveEmptyEntries);
                if (deconstruct.Length == 0) continue;
                var apiMapAppVersion = deconstruct.Length > 1 ? deconstruct[1].Replace("]", "").Trim() : appVersion;
                if (CompareVersion(appVersion, apiMapAppVersion) < 0 == false)        // App的版本号 >= 接口映射App的版本号
                {
                    return dicBizCode[apiAlias];
                }
            }

            return null;
        }

        private static int CompareVersion(string version1, string version2)
        {
            if (version1.IsNullOrWhiteSpace() && version2.IsNullOrWhiteSpace()) return 1;

            if (version1.IsNullOrWhiteSpace()) return -1;

            if (version2.IsNullOrWhiteSpace()) return 1;

            version1 = version1.ToUpper().Trim();
            version2 = version2.ToUpper().Trim();

            string[] varray1 = version1.Split(new string[] { ".", "." }, StringSplitOptions.RemoveEmptyEntries),
                     varray2 = version2.Split(new string[] { ".", "." }, StringSplitOptions.RemoveEmptyEntries);

            var minLength = Math.Min(varray1.Length, varray2.Length);
            int index = 0, diff = 0;

            while (index < minLength && (diff = varray1[index].Length - varray2[index].Length) == 0 && (diff = varray1[index].CompareTo(varray2[index])) == 0)
            {
                index++;
            }

            return diff != 0 ? diff : varray1.Length - varray2.Length;
        }
    }
}