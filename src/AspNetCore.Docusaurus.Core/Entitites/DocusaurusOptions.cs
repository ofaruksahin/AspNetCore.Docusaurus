using AspNetCore.Docusaurus.Core.Interfaces;
using System;
using System.Reflection;

namespace AspNetCore.Docusaurus.Core.Entitites
{
    public class DocusaurusOptions
    {
        private string _documentTitle { get; set; }        
        private string _documentPath { get; set; }
        private string _mainPage { get; set; }
        private Assembly _projectAssembly { get; set; }
        private string _xmlFilePath { get; set; }

        private IDocusaurusDocumentWriter _documentWriter { get; set; }

        public string DocumentTitle
        {
            get
            {
                if (String.IsNullOrEmpty(_documentTitle))
                    throw new ArgumentNullException(nameof(_documentTitle));
                return _documentTitle;
            }
            set
            {
                _documentTitle = value;
            }
        }

        public string DocumentPath
        {
            get
            {
                if (String.IsNullOrEmpty(_documentPath))
                    throw new ArgumentNullException(nameof(_documentPath));
                return _documentPath;
            }
            set
            {
                _documentPath = value;
            }
        }

        public string MainPage
        {
            get
            {
                if (String.IsNullOrEmpty(_mainPage))
                    throw new ArgumentNullException(nameof(_mainPage));
                return _mainPage;
            }
            set
            {
                _mainPage = value;
            }
        }

        public Assembly ProjectAssembly
        {
            get
            {
                if (_projectAssembly == default)
                    throw new ArgumentNullException(nameof(_projectAssembly));
                return _projectAssembly;
            }
            set
            {
                _projectAssembly = value;
            }
        }

        public string XmlFilePath
        {
            get
            {
                if (_xmlFilePath == null)
                    throw new ArgumentNullException(nameof(_xmlFilePath));
                return _xmlFilePath;
            }
            set
            {
                _xmlFilePath = value;
            }
        }

        public IDocusaurusDocumentWriter DocumentWriter
        {
            get
            {
                if (_documentWriter == null)
                    _documentWriter = new  DocusaurusDocumentWriter();
                return _documentWriter;
            }
            set
            {
                _documentWriter = value;
            }
        }
    }
}
