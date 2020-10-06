using System.Collections.Generic;
using System.Reflection;
using HttpMethod = AspNetCore.Docusaurus.Core.Enums.HttpMethod;

namespace AspNetCore.Docusaurus.Core.Entitites
{
    public class ActionItem
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public HttpMethod Method{ get; private set; }
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
        public object[] Attributes { get; set; }

        public string Description { get; private set; }

        private List<ParameterItem> _parameters { get; set; }

        public ActionItem(ControllerItem controller,MethodInfo action)
        {
            
        }

        private void SetName(MethodInfo action)
        {

        }

        private void SetPath(ControllerItem controller,MethodInfo action)
        {

        }

        private void SetMethod(MethodInfo action)
        {

        }

        private void SetAttributes(MethodInfo action)
        {

        }

        private void SetDescription()
        {

        }
    }
}
