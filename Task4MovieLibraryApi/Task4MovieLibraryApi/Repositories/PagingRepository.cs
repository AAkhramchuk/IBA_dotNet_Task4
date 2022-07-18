using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Task4MovieLibraryApi.Interfaces;
using Task4MovieLibraryApi.Wrappers;

namespace Task4MovieLibraryApi.Repositories
{
    public class PagingRepository : IPagingRepository<Movie>, IUriService
    {
        public PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData
                                                            , PaginationFilter validFilter
                                                            , int totalRecords
                                                            , IUriService uriService
                                                            , string route)
        {
            var response = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            int totalPages = (totalRecords + validFilter.PageSize - 1) / validFilter.PageSize;

            if (validFilter.PageNumber >= 1 && validFilter.PageNumber < totalPages)
            {
                response.NextPage = uriService.GetPageUri(new(validFilter.PageNumber + 1, validFilter.PageSize), route);
            }
            else
            {
                response.NextPage = null;
            }

            if (validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= totalPages)
            {
                response.PreviousPage = uriService.GetPageUri(new(validFilter.PageNumber - 1, validFilter.PageSize), route);
            }
            else
            {
                response.PreviousPage = null;
            }

            response.FirstPage = uriService.GetPageUri(new(1, validFilter.PageSize), route);
            response.LastPage = uriService.GetPageUri(new(totalPages, validFilter.PageSize), route);
            response.TotalPages = totalPages;
            response.TotalRecords = totalRecords;
            return response;
        }
    }
}
