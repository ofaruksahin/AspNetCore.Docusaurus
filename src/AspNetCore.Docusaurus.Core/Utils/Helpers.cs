using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
    }
}
