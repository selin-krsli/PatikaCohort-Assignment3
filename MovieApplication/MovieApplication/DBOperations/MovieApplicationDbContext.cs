using Microsoft.EntityFrameworkCore;

namespace MovieApplication.DBOperations
{
    public class MovieApplicationDbContext: DbContext
    {
        public MovieApplicationDbContext(DbContextOptions<MovieApplicationDbContext> options):base(options) //base yani DbContext sınıfından gelen optionsı parametre olarak alacam.
        { } 
        public DbSet<Movie> Movies { get; set; }

    }
}
