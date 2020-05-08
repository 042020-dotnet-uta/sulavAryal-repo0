using Microsoft.EntityFrameworkCore;
using MvcMovie.Domain;

namespace MvcMovie.DataAccess
{
    public class MvcMovieDbContext:DbContext
    {
        public MvcMovieDbContext(DbContextOptions<MvcMovieDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }

    }
}
