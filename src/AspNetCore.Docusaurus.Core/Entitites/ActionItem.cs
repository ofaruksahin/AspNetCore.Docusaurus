using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspNetCore.Docusaurus.Core.Entitites
{
    public class ActionItem
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Method { get; private set; }
        public List<ParameterItem> Parameters
        {
            get
            {
                if (_parameters == null)
                    _parameters = new List<ParameterItem>();
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }

        [JsonIgnore]
        public object[] Attributes { get; set; }

        public string Description { get;  set; }

        private List<ParameterItem> _parameters { get; set; }

        public ActionItem(ControllerItem controller, MethodInfo action)
        {
            SetName(action);
            SetPath(controller);
            SetMethod(action);
            SetAttributes(action);
        }

        private void SetName(MethodInfo action)
        {
            Attribute httpMethodAttribute = action.GetCustomAttributes().FirstOrDefault(x => x.GetType().BaseType == typeof(HttpMethodAttribute));
            if (httpMethodAttribute != null)
            {
                Name = ((HttpMethodAttribute)httpMethodAttribute).Template;
            }
            else
            {
                Name = action.Name;
            }
        }

        private void SetPath(ControllerItem controller)
        {
            object routeAttribute = controller.Attributes.FirstOrDefault(x => x.GetType() == typeof(RouteAttribute));
            var controllerName = "";
            if (routeAttribute != null)
                controllerName = ((RouteAttribute)routeAttribute).Template;
            else
                controllerName = controller.Name;
            controllerName = controllerName.Replace("[controller]", controller.Name.Replace("Controller","").ToLower());
            controllerName = $"{controllerName}/{Name}";
            Path = controllerName;
        }

        private void SetMethod(MethodInfo action)
        {
            Attribute httpMethodAttribute = action.GetCustomAttributes().FirstOrDefault(x => x.GetType().BaseType == typeof(HttpMethodAttribute));
            if (httpMethodAttribute != null)
            {                
                Method = ((HttpMethodAttribute)httpMethodAttribute).HttpMethods.FirstOrDefault();
            }
            else
            {
                throw new ArgumentNullException(nameof(httpMethodAttribute));
            }
        }

        private void SetAttributes(MethodInfo action)
        {
            Attributes = action.GetCustomAttributes(true);
        }        
    }
}
