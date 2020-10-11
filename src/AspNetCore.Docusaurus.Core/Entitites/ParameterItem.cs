using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

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

        public string Description { get; private set; }

        [JsonIgnore]
        public object[] Attributes { get; private set; }

        private List<ParameterItem> _properties { get; set; }

        public ParameterItem(ParameterInfo parameterInfo)
        {
            SetName(parameterInfo);
            SetParameterType(parameterInfo);
            SetDescription(parameterInfo);
            SetAttributes(parameterInfo);
        }

        public ParameterItem(PropertyInfo propertyInfo)
        {
            SetName(propertyInfo);
            SetParameterType(propertyInfo);
            SetDescription(propertyInfo);
            SetAttributes(propertyInfo);
        }

        private void SetName(ParameterInfo parameterInfo)
        {
            Name = parameterInfo.Name;
        }

        private void SetName(PropertyInfo propertyInfo)
        {
            Name = propertyInfo.Name;
        }

        private void SetParameterType(ParameterInfo parameterInfo)
        {
            ParameterType = parameterInfo.ParameterType;
        }

        private void SetParameterType(PropertyInfo propertyInfo)
        {
            ParameterType = propertyInfo.PropertyType;
        }

        private void SetDescription(ParameterInfo parameterInfo)
        {
            var descriptionAttribute = parameterInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            if (descriptionAttribute != null)
                Description = ((DescriptionAttribute)descriptionAttribute).Description;            
        }

        private void SetDescription(PropertyInfo propertyInfo)
        {
            var descriptionAttribute = propertyInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            if (descriptionAttribute != null)
                Description = ((DescriptionAttribute)descriptionAttribute).Description;
        }

        private void SetAttributes(ParameterInfo parameterInfo)
        {
            Attributes = parameterInfo.GetCustomAttributes(true);
        }

        private void SetAttributes(PropertyInfo propertyInfo)
        {
            Attributes = propertyInfo.GetCustomAttributes(true);
        }
    }
}
