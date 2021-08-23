using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace YYhUpload
{
    public static class XmlUtils<T> where T : new()
    {
        public static T XmlDeserialize(string inXml)
        {
            try
            {
                using var reader = new StringReader(inXml);
                var type = typeof(T);
                var serializer = new XmlSerializer(type);
                return (T)serializer.Deserialize(reader);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// 将对象序列化为xml字符串
        /// </summary>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string SerializeToXmlString(T t)
        {
            string outStr;
            var setting = new XmlWriterSettings
            {
                //去除xml声明
                OmitXmlDeclaration = true,
                Encoding = Encoding.UTF8,
                //Xml缩进
                Indent = true
            };
            //去除去除默认命名空间xmlns:xsd和xmlns:xsi
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (var stream = new MemoryStream())
            {
                var xmlWriter = XmlWriter.Create(stream, setting);
                var type = typeof(T);
                var serializer = new XmlSerializer(type);
                serializer.Serialize(xmlWriter, t,ns);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                outStr = Encoding.UTF8.GetString(stream.ToArray());
                xmlWriter.Dispose();
            }
            //去掉xml前面的？
            return Regex.Replace(outStr, "^[^<]", "");
        }

        /// <summary>
        /// 序列化对象返回XElement
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static XElement SerializeToXElement(T t)
        {
            XElement xmlElement;
            var setting = new XmlWriterSettings
            {
                //去除xml声明
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8,
                //Xml缩进
                Indent = true
            };
            //去除去除默认命名空间xmlns:xsd和xmlns:xsi
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using var stream = new MemoryStream();
            var type = typeof(T);
            var xmlWriter = XmlWriter.Create(stream, setting);
            var serializer = new XmlSerializer(type);
            serializer.Serialize(xmlWriter, t, ns);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            var reader = XmlReader.Create(stream);
            xmlElement = XElement.Load(reader);
            reader.Dispose();
            xmlWriter.Dispose();
            return xmlElement;
        }
    }
}
