using Task4MovieLibraryApi.Repository;

namespace Task4MovieLibraryApi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IPagingRepository Paging { get; }
        int Complete();
    }
}
