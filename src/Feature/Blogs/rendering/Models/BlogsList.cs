using Sitecore.LayoutService.Client.Response.Model.Fields;

using System.Collections.Generic;

namespace Mvp.Feature.Blog.Models
{
    public class BlogsList
    {
        public TextField BlogsTitle { get; set; }

        public RichTextField BlogsDescription { get; set; }

        public string Keyword { get; set; }

        public int StartCursor { get; set; }

        public long EndCursor { get; set; }

        public long TotalCount { get; set; }

        public IEnumerable<Rendering.Models.Blog> Blogs { get; set; }

        public int CurrentPage { get; set; }

        public int UpdatePagerInUrl { get; set; }

        public int PagerStart { get; set; }

        public long PagerEnd { get; set; }

        public int LastPage { get; set; }

        public string BlogPageUrl { get; set; }
    }
}
