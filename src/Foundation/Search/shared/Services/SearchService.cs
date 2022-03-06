using Azure.Search.Documents;
using System;
using System.Threading.Tasks;
using Azure;
using Azure.Search.Documents.Models;
using Mvp.Foundation.Search.Models;

namespace Mvp.Foundation.Search.Services
{
    /// <summary>
    /// Azure Cognitive Search Client
    /// </summary>
    /// <seealso cref="Mvp.Foundation.Search.Services.ISearchService" />
    public class SearchService : ISearchService
    {
        private const string ServiceName = "searchmvppublication";

        private const string ApiKey = "6C712029F7151B2373A21CFF894FD744";

        private const string IndexName = "azureblob-index";

        public SearchService()
        { 
        
            Uri serviceEndpoint = new Uri($"https://{ServiceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(ApiKey);

            // Create a SearchClient to load and query documents
            this.SearchClient = new SearchClient(serviceEndpoint, IndexName, credential);
        }

        private SearchClient SearchClient { get; }


        public async Task<SearchResults<Publication>> SearchAsync(string searchText, int size=0, int pageNumber=1)
        {
            var searchOptions = new SearchOptions();
            searchOptions.QueryType = SearchQueryType.Full;
            searchOptions.SearchMode = SearchMode.All;
            searchOptions.IncludeTotalCount = true;
            if(size > 0)
            {
                searchOptions.Size = size;
                if(pageNumber > 1)
                {
                    searchOptions.Skip = (pageNumber - 1)*size;
                }
                
            }

            return await this.SearchClient.SearchAsync<Publication>(searchText, searchOptions).ConfigureAwait(false);
        }
    }
}
