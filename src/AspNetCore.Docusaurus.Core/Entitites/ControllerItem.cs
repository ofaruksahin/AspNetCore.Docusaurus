using System;
using System.Collections.Generic;

namespace AspNetCore.Docusaurus.Core.Entitites
{
    public class ControllerItem
    {
        public string Name { get; private set; }
        public List<ActionItem> Actions
        {
            get
            {
                if (_actions == null)
                    _actions = new List<ActionItem>();
                return _actions;
            }           
        }
        public object[] Attributes{ get;private set; }

        public string Description { get; private set; }

        private List<ActionItem> _actions { get;  set; }        

        public ControllerItem(Type controller)
        {
            SetName(controller.Name);
            SetAttributes(controller.GetCustomAttributes(true));
        }

        private void SetName(string name) => Name = name;

        private void SetAttributes(object[] attributes) => Attributes = attributes;

        private void SetDescription()
        {

        }
    }
}
