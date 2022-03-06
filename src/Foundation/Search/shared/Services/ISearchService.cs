using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Mvp.Foundation.Search.Models;

namespace Mvp.Foundation.Search.Services
{
    public interface ISearchService
    {
        Task<SearchResults<Publication>> SearchAsync(string searchText, int size = 0, int pageNumber = 1);
    }
}
