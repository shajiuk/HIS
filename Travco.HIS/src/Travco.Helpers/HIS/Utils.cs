using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
namespace Travco.Helpers.HIS
{
    public static class Utils
    {

        /// <summary>
        /// Serialize a [Serializable] object of type T into an XML-formatted string using XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any T object</param>
        /// <returns>an XML-formatted string</returns>
        public static string SerializeToXML<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new Utf8StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static string SerializeToXMLSOAP<T>(this T value, string namespacePrefix, string namespaceValue, string soapPrefix)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(namespacePrefix, namespaceValue);

                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new Utf8StringWriter();                

                xmlserializer.Serialize(stringWriter, value, ns);

                return stringWriter.ToString()
                    .Replace("q1", soapPrefix);
                    

                /*using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString().Replace("q1", "soap-env");
                }
                */
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        /// <summary>
        /// De-serialize to a [Serializable] object of type T from an XML-formatted string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">any XML-formatted string</param>
        /// <returns>an object of type T</returns>
        public static T DeserializeFromXML<T>(this string xml)
        {
            if (String.IsNullOrEmpty(xml)) throw new NotSupportedException("ERROR: input string cannot be null.");
            try
            {

                var xmlserializer = new XmlSerializer(typeof(T));
                var stringReader = new StringReader(xml);

                using (var reader = XmlReader.Create(stringReader))
                {
                    return (T)xmlserializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new HISStandardErrorException("An error occurred", ex);
            }
        }


        public static string GetXml(string xmlFile)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);

            return document.InnerXml;
        }

        public static object GetPropertyValue(object source, string property, string value)
        {
            PropertyInfo prop = source.GetType().GetProperty(property);
            if (prop == null)
            {
                foreach (PropertyInfo propertyMember in source.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0))
                {
                    object newSource = propertyMember.GetValue(source, null);
                    return GetPropertyValue(newSource, property, value);
                }
            }
            else
            {
                //PropertyInfo propertyToSet = source.GetType().GetProperty(bits[bits.Length - 1]);
                if (value.Length > 0) prop.SetValue(source, value, null);
                return prop.GetValue(source, null);
            }
            return null;
        }

        public static IList GetPropertyValue2(object source, string property, string value)
        {
            PropertyInfo prop = source.GetType().GetProperty(property);
            if (prop == null)
            {
                foreach (PropertyInfo propertyMember in source.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0))
                {
                    object newSource = propertyMember.GetValue(source, null);
                    var e1 = GetPropertyValue(newSource, property, value);
                    return e1 as IList;
                }
            }
            else
            {
                //PropertyInfo propertyToSet = source.GetType().GetProperty(bits[bits.Length - 1]);
                if (value.Length > 0) prop.SetValue(source, value, null);
                var e = prop.GetValue(source, null);

                return (List<Travco.HIS.Model.Response.Error.SearchAvailability.EnvelopeBody>) e;
            }
            return null;
        }

    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
