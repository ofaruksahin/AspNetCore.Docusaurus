using AspNetCore.Docusaurus.Core.Entitites;
using System.Collections.Generic;

namespace AspNetCore.Docusaurus.Core.Interfaces
{
    public interface IDocusaurusDocumentWriter
    {
        void WriteDocument(List<ControllerItem> controllers);
    }
}
