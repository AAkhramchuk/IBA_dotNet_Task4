namespace Task4MovieLibraryApi.Interfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IEnumerable<Movie> GetPopularMovie(int count);
    }
}
