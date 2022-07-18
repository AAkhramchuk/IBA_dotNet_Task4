using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Task4MovieLibraryApi
{
    /// <summary>
    /// Movie data context class
    /// </summary>
    public class MovieContext : DbContext
    {
        public MovieContext() : base() { }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        /// <summary>
        /// Used to query and save Movie instances
        /// </summary>
        public DbSet<Movie> Movies { get { return Set<Movie>(); } set { } }
    }
}
