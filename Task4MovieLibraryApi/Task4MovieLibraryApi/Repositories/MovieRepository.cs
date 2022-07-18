namespace Task4MovieLibraryApi.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context)
        {
        }
        public IEnumerable<Movie> GetPopularMovie(int count)
        {
            return _context.Movies.OrderByDescending(m => m.MovieRating).Take(count).ToList();
        }
    }
}
