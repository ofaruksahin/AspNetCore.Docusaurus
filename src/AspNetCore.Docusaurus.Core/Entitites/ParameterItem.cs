using System;
using System.Collections.Generic;

namespace AspNetCore.Docusaurus.Core.Entitites
{
    public class ParameterItem
    {
        public string Name { get; private set; }
        public Type ParameterType { get;private set; }

        public List<ParameterItem> Properties 
        {
            get
            {
                if (_properties == null)
                    _properties = new List<ParameterItem>();
                return _properties;
            }
        }

        public object[] Attributes { get; private set; }

        public string Description { get; private set; }

        private List<ParameterItem> _properties { get; set; }        
    }
}
