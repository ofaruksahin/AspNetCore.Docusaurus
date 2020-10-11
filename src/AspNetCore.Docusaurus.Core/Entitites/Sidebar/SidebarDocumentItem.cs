using System.Collections.Generic;

namespace AspNetCore.Docusaurus.Core.Entitites.Sidebar
{
    public class SidebarDocumentItem
    {
        public string type { get;private set; }
        public string label { get; set; }
        public List<string> ids { get; set; }

        public SidebarDocumentItem()
        {
            type = "subcategory";
            ids = new List<string>();
        }
    }
}
