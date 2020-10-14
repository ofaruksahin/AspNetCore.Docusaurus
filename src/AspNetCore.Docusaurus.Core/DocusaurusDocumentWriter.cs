using AspNetCore.Docusaurus.Core.Entitites;
using AspNetCore.Docusaurus.Core.Entitites.Sidebar;
using AspNetCore.Docusaurus.Core.Interfaces;
using AspNetCore.Docusaurus.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AspNetCore.Docusaurus.Core
{
    public class DocusaurusDocumentWriter : IDocusaurusDocumentWriter
    {
        DocusaurusOptions options = DocusaurusServiceCollection.Options;

        public void WriteDocument(List<ControllerItem> controllers)
        {
            try
            {
                List<SidebarDocumentItem> sidebarDocument = new List<SidebarDocumentItem>();
                foreach (var controller in controllers)
                {
                    SidebarDocumentItem sidebarDocumentItem = new SidebarDocumentItem();
                    sidebarDocumentItem.label = controller.Name;
                    foreach (var action in controller.Actions)
                    {
                        var documentPath = Helpers.GenerateDocumentPath(controller, action);
                        var documentName = Helpers.GenerateDocumentName(controller, action);
                        var parameterJsonSerialize = JsonConvert.SerializeObject(action, Formatting.Indented);
                        var documentContent = String.Format(Constants.DOCUMENT_CONTENT, documentName, action.Path, action.Description, parameterJsonSerialize);
                        File.WriteAllText(documentPath, documentContent);
                        sidebarDocumentItem.ids.Add(documentName);
                    }
                    sidebarDocument.Add(sidebarDocumentItem);
                }
                var sidebarDocumentSerialize = JsonConvert.SerializeObject(sidebarDocument);
                var firstSquareBracket = sidebarDocumentSerialize.IndexOf("[");
                var lastSquareBracket = sidebarDocumentSerialize.LastIndexOf("]");
                firstSquareBracket++;
                lastSquareBracket--;
                sidebarDocumentSerialize = sidebarDocumentSerialize.Substring(firstSquareBracket, lastSquareBracket);
                string sidebarContent = @"
            {
                ""docs"":{
                    ""{0}"":[
                        ""{1}"",
                        {2}
                    ]
                }
            }
            ";
                sidebarContent = sidebarContent.Replace("{0}", options.DocumentTitle);
                sidebarContent = sidebarContent.Replace("{1}", options.MainPage);
                sidebarContent = sidebarContent.Replace("{2}", sidebarDocumentSerialize);
                File.WriteAllText(Helpers.GetSidebarConfigFilePath(options.DocumentPath), sidebarContent);
            }
            catch (Exception ex)
            {
                if(ex is IOException)
                {
                    throw ex;
                }
            }
        }
    }
}
