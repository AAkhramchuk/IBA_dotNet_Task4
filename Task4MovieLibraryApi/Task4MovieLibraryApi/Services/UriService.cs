using Microsoft.AspNetCore.WebUtilities;
using Task4MovieLibraryApi.Interfaces;
using Task4MovieLibraryApi.Repository;

namespace Task4MovieLibraryApi.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            string modifiedUri;

            Uri enpointUri = new (string.Concat(_baseUri, route));
            modifiedUri = QueryHelpers.AddQueryString(enpointUri.ToString()
                                                      , "pageNumber"
                                                      , filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri
                                                      , "pageSize"
                                                      , filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
