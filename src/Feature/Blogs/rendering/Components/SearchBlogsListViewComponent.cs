using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mvp.Foundation.Search.Services;
using System.Threading.Tasks;
using System.Web;
using Mvp.Feature.Blog.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Mvp.Feature.Blog.Components
{
    public class SearchBlogsListViewComponent : ViewComponent
    {
        private readonly ISearchService _searchService;

        private const int PageSize = 10;

        public SearchBlogsListViewComponent(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = GetQueryKeyword();
            var pageNumber = GetPageNumber() ?? 1;

            var results = await _searchService.SearchAsync(query, PageSize, pageNumber);
            var blogs = results.GetResults();
            var totalCount = results.TotalCount ?? 0;

            var model = new BlogsList()
            {
                Blogs = blogs.AsPages().SelectMany(p => p.Values).Select(r => new Rendering.Models.Blog
                {
                    Author = r.Document.People?.FirstOrDefault(),
                    PublicationUrl = HttpUtility.UrlDecode(r.Document.MetadataStorageName?.Replace(".html", "")),
                    ShortDescription = r.Document.MetadataDescription,
                    Title = r.Document.MetadataTitle
                }),
                TotalCount = totalCount,
                CurrentPage = pageNumber,
                LastPage = 10000,
                StartCursor = totalCount > 0 ? (pageNumber-1)*PageSize + 1 : 0,
                EndCursor = PageSize < totalCount ? (pageNumber-1)*PageSize + blogs.Count() : totalCount,
                PagerStart = 1,
                PagerEnd = (totalCount / PageSize) + 1,
                UpdatePagerInUrl = pageNumber,
                Keyword = query,
                BlogsTitle = new TextField("Blogs Title")
            };

            return View(model);
        }


        private string GetQueryKeyword()
        {
            if (this.HttpContext.Request.Query.ContainsKey(Constants.QueryParameters.Query))
                return Request.Query[Constants.QueryParameters.Query];
            return "";
        }

        private int? GetPageNumber()
        {
            int? pageNumber =1;

            if (this.HttpContext.Request.Query.ContainsKey(Constants.QueryParameters.Page))
                return int.Parse(Request.Query[Constants.QueryParameters.Page]);

            return pageNumber;
        }
    }
}
