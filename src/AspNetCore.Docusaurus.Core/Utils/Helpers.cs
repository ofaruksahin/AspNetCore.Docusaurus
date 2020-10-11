using AspNetCore.Docusaurus.Core.Entitites;
using AspNetCore.Docusaurus.Core.Entitites.Docs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace AspNetCore.Docusaurus.Core.Utils
{
    public static class Helpers
    {
        public static Type[] GetClasses(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var item in assembly.GetTypes())
            {
                string[] namespaces = item.Namespace.Split('.');
                if (
                    namespaces[namespaces.Length - 1] == "Controllers"
                    &&
                    item.CustomAttributes.Any(x => x.AttributeType == typeof(ApiControllerAttribute)))
                    types.Add(item);
            }
            return types.ToArray();
        }

        public static List<MethodInfo> GetMethods(Type type)
        {
            List<MethodInfo> methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList();
            methods.RemoveAll(x=>!x.CustomAttributes.Any(y=>y.AttributeType.BaseType == typeof(HttpMethodAttribute)));
            return methods;
        }

        public static ParameterInfo[] GetParameters(MethodInfo methodInfo) => methodInfo.GetParameters();

        public static Doc ParseXml(string xmlContent)
        {
            Doc result = default;
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute();
            xmlRootAttribute.ElementName = "doc";
            xmlRootAttribute.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(Doc), xmlRootAttribute);
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContent)))
            {
                result = (Doc)serializer.Deserialize(memoryStream);
            }
            return result;
        }

        public static string GenerateDocumentPath(ControllerItem controllerItem,ActionItem actionItem)
        {
            var path = $"{DocusaurusServiceCollection.Options.DocumentPath}/docs/{controllerItem.Name.ToLower()}_{actionItem.Path.Replace("/", "").ToLower()}.md";
            if(path.Contains("{"))
            {
                var index = path.IndexOf("{");
                path = path.Substring(0, index)+".md";
            }
            return path;
        }

        public static string GenerateDocumentName(ControllerItem controllerItem, ActionItem actionItem)
        {
            var name = $"{controllerItem.Name.ToLower()}_{actionItem.Path.Replace("/", "").ToLower()}";
            if(name.Contains("{"))
            {
                var index = name.IndexOf("{");
                name = name.Substring(0, index);
            }
            return name;
        }

        public static string GetSidebarConfigFilePath(string documentPath)
        {
            return $"{documentPath}/website/sidebars.json";
        }
    }
}
