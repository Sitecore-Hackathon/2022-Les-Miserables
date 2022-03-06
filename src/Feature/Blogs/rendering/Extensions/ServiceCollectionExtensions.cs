using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Mvp.Foundation.Search.Services;

namespace Mvp.Feature.Blog.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSearchService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ISearchService, SearchService>();
        }
    }
}
