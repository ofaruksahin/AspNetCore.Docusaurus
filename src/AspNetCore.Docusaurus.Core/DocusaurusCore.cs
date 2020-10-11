using AspNetCore.Docusaurus.Core.Entitites;
using AspNetCore.Docusaurus.Core.Entitites.Docs;
using AspNetCore.Docusaurus.Core.Interfaces;
using AspNetCore.Docusaurus.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Docusaurus.Core
{
    public class DocusaurusCore : IDocusaurusCore
    {
        private DocusaurusOptions options;
        public List<ControllerItem> controllerItems = new List<ControllerItem>();
        public DocusaurusCore(DocusaurusOptions _options)
        {
            options = _options;
        }

        public void Initialize()
        {
            string xmlFileContent = File.ReadAllText(options.XmlFilePath);
            Doc docsAssembly = Helpers.ParseXml(xmlFileContent);
            var controllers = Helpers.GetClasses(options.ProjectAssembly);
            List<ControllerItem> controllerItems = new List<ControllerItem>();
            foreach (var controller in controllers)
            {
                ControllerItem controllerItem = new ControllerItem(controller);
                controllerItem.Description = docsAssembly.Members.Member.FirstOrDefault(x => x.Name == $"T:{controller.Namespace}.{controller.Name}").Summary;
                controllerItem.Description = controllerItem.Description.Trim().Replace("\n", "");
                var actions = Helpers.GetMethods(controller);
                foreach (var action in actions)
                {
                    ActionItem actionItem = new ActionItem(controllerItem, action);
                    string actionXmlName = $"M:{controller.Namespace}.{controller.Name}.{action.Name}";
                    actionItem.Description = docsAssembly.Members.Member.FirstOrDefault(x => x.Name == actionXmlName)?.Summary;
                    actionXmlName += "(";
                    var parameters = Helpers.GetParameters(action);
                    foreach (var parameter in parameters)
                    {
                        if (String.IsNullOrEmpty(actionItem.Description))
                            actionXmlName += parameter.ParameterType + ",";
                            bool isVariable = parameter.ParameterType.BaseType == typeof(ValueType);
                        ParameterItem parameterItem = new ParameterItem(parameter);
                        if (!isVariable)
                        {
                            AppendSubProperties(ref parameterItem, parameter);
                        }                       
                        actionItem.Parameters.Add(parameterItem);
                    }
                    if(String.IsNullOrEmpty(actionItem.Description))
                    {
                        actionXmlName = actionXmlName.TrimEnd(',') + ")";
                        actionItem.Description = docsAssembly.Members.Member.FirstOrDefault(x => x.Name == actionXmlName)?.Summary;
                    }
                    actionItem.Description = actionItem.Description?.Trim().Replace("\n", "");
                    controllerItem.Actions.Add(actionItem);
                }
                controllerItems.Add(controllerItem);
            }
            options.DocumentWriter.WriteDocument(controllerItems);
        }

        private void AppendSubProperties(ref ParameterItem parameterItem, ParameterInfo parameter)
        {
            var properties = parameter.ParameterType.GetProperties();
            foreach (var property in properties)
            {
                ParameterItem subParameterItem = new ParameterItem(property);
                var serializableAttribute = property.PropertyType.GetCustomAttribute(typeof(SerializableAttribute));
                if (serializableAttribute == null && property.PropertyType != property.DeclaringType)
                    AppendSubProperties(ref subParameterItem, property);
                parameterItem.Properties.Add(subParameterItem);
            }
        }

        private void AppendSubProperties(ref ParameterItem parameterItem, PropertyInfo propertyInfo)
        {
            var properties = propertyInfo.PropertyType.GetProperties();
            foreach (var property in properties)
            {
                ParameterItem subParameterItem = new ParameterItem(property);
                var serializableAttribute = property.PropertyType.GetCustomAttribute(typeof(SerializableAttribute));
                if (serializableAttribute == null && property.PropertyType != property.DeclaringType)
                    AppendSubProperties(ref subParameterItem, property);
                parameterItem.Properties.Add(subParameterItem);
            }
        }
    }
}
