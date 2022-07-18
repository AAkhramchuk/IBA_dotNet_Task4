using Task4MovieLibraryApi.Services;
using Task4MovieLibraryApi.Wrappers;

namespace Task4MovieLibraryApi.Interfaces
{
    public interface IPagingRepository : IGenericRepository
    {
        PagedResponse<List<T>> CreatePagedReponse<T>(List<T> pagedData
                                                     , PaginationFilter validFilter
                                                     , int totalRecords
                                                     , IUriService uriService
                                                     , string route);
    }
}
