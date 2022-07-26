using Microsoft.AspNetCore.WebUtilities;
using Domain.Entities;
using Domain.Interfaces;

namespace DataAccess.EFCore.Services
{
    /// <summary>
    /// URI service repository
    /// </summary>
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        /// <summary>
        /// URI constructor
        /// </summary>
        /// <param name="filter">URI filter parameters</param>
        /// <param name="route">URI route</param>
        /// <returns>URI unique sequence</returns>
        public Uri GetPageUri(PagingFilter filter, string route)
        {
            Uri endpointUri = new (string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString()
                                                          , "pageNumber"
                                                          , filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri
                                                      , "pageSize"
                                                      , filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
