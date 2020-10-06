using System;

namespace AspNetCore.Docusaurus.Core.Attributes
{
    public class DocusaurusTitleAttribute : Attribute
    {
        public string Title { get; set; }
        public DocusaurusTitleAttribute(string title)
        {
            Title = title;
        }
    }
}
