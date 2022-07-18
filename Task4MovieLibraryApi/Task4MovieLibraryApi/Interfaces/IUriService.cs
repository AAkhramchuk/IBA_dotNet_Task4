using Task4MovieLibraryApi.Repository;

namespace Task4MovieLibraryApi.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
