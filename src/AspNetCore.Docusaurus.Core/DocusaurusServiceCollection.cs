using AspNetCore.Docusaurus.Core.Entitites;
using AspNetCore.Docusaurus.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace AspNetCore.Docusaurus.Core
{
    public static class DocusaurusServiceCollection
    {
        private static DocusaurusOptions _options = default;

        public static DocusaurusOptions Options
        {
            get
            {
                if (_options == default)
                    throw new ArgumentNullException(nameof(_options));
                return _options;
            }
            set
            {
                _options = value;
            }
        }

        public static IServiceCollection AddDocusaurus(this IServiceCollection services,DocusaurusOptions options)
        {
            Options = options;
            IDocusaurusCore docusaurusCore = new DocusaurusCore(options);            
            services.TryAddSingleton(docusaurusCore);
            return services;
        }
    }
}
