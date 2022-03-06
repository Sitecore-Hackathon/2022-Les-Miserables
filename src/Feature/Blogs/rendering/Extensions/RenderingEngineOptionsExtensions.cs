using Mvp.Feature.Blog.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Mvp.Feature.Blog.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBlog(this RenderingEngineOptions options)
        {
            options.AddViewComponent("BlogsList", "SearchBlogsList");
            return options;
        }
    }
}