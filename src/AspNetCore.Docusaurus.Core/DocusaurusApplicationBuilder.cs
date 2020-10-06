using AspNetCore.Docusaurus.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using System;

namespace AspNetCore.Docusaurus.Core
{
    public static class DocusaurusApplicationBuilder
    {
        public static IApplicationBuilder UseDocusaurus(this IApplicationBuilder app)
        {
            IDocusaurusCore docusaurusCore =  (IDocusaurusCore)app.ApplicationServices.GetService(typeof(IDocusaurusCore));
            if (docusaurusCore == null)
                throw new ArgumentNullException(nameof(docusaurusCore));
            docusaurusCore.Initialize();
            return app;
        }
    }
}
