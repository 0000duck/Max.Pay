using System;
using System.IO;
using System.Xml.Serialization;

namespace Max.Common.Utils.Extension
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public static class XmlExtensions
    {

        public static T XmlToObject<T>(this string str) where T : class
        {
            return Deserialize<T>(str);
        }
        //public static string ToXml(this Object obj)
        //{
        //    return Serializer(obj);
        //}

        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlStr) where T : class
        {
            try
            {
                using (var sr = new StringReader(xmlStr))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return xmldes.Deserialize(sr) as T;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

      
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        #region 序列化XML文件

        /// <summary> 

        /// 序列化XML文件 

        /// </summary> 

        /// <param name="type">类型</param> 

        /// <param name="obj">对象</param> 

        /// <returns></returns> 

        public static string Serializer(Type type, object obj)
        {

            MemoryStream Stream = new MemoryStream();

            //创建序列化对象 

            XmlSerializer xml = new XmlSerializer(type);

            try
            {

                //序列化对象 

                xml.Serialize(Stream, obj);

            }

            catch (InvalidOperationException)
            {

                throw;

            }

            Stream.Position = 0;

            StreamReader sr = new StreamReader(Stream);

            string str = sr.ReadToEnd();

            return str;

        } 

        #endregion
    }
}
