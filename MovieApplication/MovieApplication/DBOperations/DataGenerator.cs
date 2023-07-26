using Microsoft.EntityFrameworkCore;

namespace MovieApplication.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieApplicationDbContext>>()))
            {
                if(context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(
                new Movie
                    
                {
                    //MovieId = 1,
                    MovieName = "One Flew Over the Cuckoo's Nest",
                    Director = "Milos Forman",
                    MovieStory = "Randle P. McMurphy is a prisoner who pretends to be crazy to get out of working at the prison where he is incarcerated.",
                    ReleaseYear = new DateTime(1975,02,14),
                    GenreId = 1, //Dramatic Film
                    Price = 150,
                    IMDB = 8.5,
                 },
                new Movie
                {
                   // MovieId = 2,
                    MovieName = "The Silence of the Lambs",
                    Director = "Jonathan Demme",
                    MovieStory = "Clarice Starlin is an FBI agent. Starlin, an FBI agent, is just about to graduate from the academy.",
                    ReleaseYear = new DateTime(1991,04,14),
                    GenreId = 2, //Thriller Film
                    Price = 168,
                    IMDB = 9.1,
                },
                new Movie
                {
                   // MovieId = 3,
                    MovieName = "The Dark Night",
                    Director = "Christopher Nolan",
                    MovieStory = "The Dark Knight tells the story of Batman, who takes on the task of saving the Streets of Gotham again, which returned to chaos with the appearance of the Joker.",
                    ReleaseYear = new DateTime(2008,05,16),
                    GenreId = 3, //Action Film
                    Price = 100,
                    IMDB = 8.5,
                },
                new Movie
                {
                   // MovieId = 4,
                    MovieName = "The Devil's Advocate",
                    Director = "Taylor Hackford",
                    MovieStory = "The film follows the life of Kevin Lomax (Keanu Reeves), a successful lawyer, who becomes strange after meeting rich",
                    ReleaseYear = new DateTime(1997,04,14),
                    GenreId = 2, //Thriller Film
                    Price = 142,
                    IMDB = 8.8,
                });
                context.SaveChanges();
            }
        }
    }
}
