using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Max.Framework;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Max.Web.Presentation.Common
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
        private static Dictionary<string, string> dicBizCode = new Dictionary<string, string>();

        static ProcessorUtil()
        {
            //    var types = Assembly.GetAssembly(typeof(IProcessor)).GetTypes()
            //    .Where(t => t.IsSubclassOf(typeof(IProcessor)));
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IProcessor)))
                .ToList();
            foreach (var type in types)
            {
                var description = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (description.Length > 0)
                {
                    dicBizCode.Add(description[0].Description, type.Name);
                }
            }
        }


        public static List<Type> GetProcessors()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IProcessor))&&t!=typeof(BasePay))
                .ToList();
        }


        public static string GetBizCode(Type type)
        {
            var description = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (description.Length > 0)
            {
                return description[0].Description;
            }
            else
            {
                throw new Exception("IProcessor：{0} 未标记DescriptionAttribute特性".Fmt(type.Name));
            }
        }

        public static bool BizCodeValid(string cmd)
        {
            if (dicBizCode.ContainsKey(cmd))
                return true;
            return false;
        }

    }


}