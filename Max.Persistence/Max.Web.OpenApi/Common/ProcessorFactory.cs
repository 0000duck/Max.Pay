using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;
using Newtonsoft.Json;

namespace Max.Web.OpenApi.Common
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
        private static Regex regexRequest = new Regex("Request[0-9]+", RegexOptions.Compiled);
        private static Dictionary<string, Type> dicRequest = new Dictionary<string, Type>();

        static ProcessorUtil()
        {
            dicRequest = Assembly.GetExecutingAssembly().GetTypes()
               .Where(t => regexRequest.IsMatch(t.Name))
               .ToDictionary(t => regexBizCode.Match(t.Name).Value, t => t);
        }

        public static BaseRequest GetRequest(string bizCode, string json)
        {
            if (!dicRequest.ContainsKey(bizCode))
                return null;
            return JsonConvert.DeserializeObject(json, dicRequest[bizCode]) as  BaseRequest;
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
    }
}