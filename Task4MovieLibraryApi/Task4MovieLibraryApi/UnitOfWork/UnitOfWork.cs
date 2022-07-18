using Task4MovieLibraryApi.Interfaces;

namespace Task4MovieLibraryApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext _context;

        public IMovieRepository Movie { get; private set; }
        public IPagingRepository Paging { get; private set; }

        public UnitOfWork(MovieContext context)
        {
            _context = context;
            Movie = new MovieRepository(_context);
            Paging = new PagingRepository();
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
