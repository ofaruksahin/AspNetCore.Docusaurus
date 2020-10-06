using AspNetCore.Docusaurus.Core.Entitites;
using AspNetCore.Docusaurus.Core.Interfaces;
using AspNetCore.Docusaurus.Core.Utils;
using System;
using System.Collections.Generic;

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
            
            var controllers = Helpers.GetClasses(options.ProjectAssembly);
            foreach (var controller in controllers)
            {
                ControllerItem controllerItem = new ControllerItem(controller);
                var actions = Helpers.GetMethods(controller);
                foreach (var action in actions)
                {
                    ActionItem actionItem = new ActionItem(controllerItem, action);
                    var parameters = Helpers.GetParameters(action);
                    foreach (var parameter in parameters)
                    {
                        bool isVariable = parameter.ParameterType.BaseType == typeof(ValueType);
                        if (isVariable)
                        {

                        }
                        else
                        {

                        }
                    }
                    controllerItem.Actions.Add(actionItem);
                }
            }
        }
    }
}
