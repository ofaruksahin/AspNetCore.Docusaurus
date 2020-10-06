using System;

namespace AspNetCore.Docusaurus.Core.Attributes
{
    public class DocusaurusDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public DocusaurusDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
