using Microsoft.EntityFrameworkCore;
using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.CreateBook
{
    public class CreateMovieCommand
    {
        private readonly MovieApplicationDbContext _dbContext;
        public CreateMovieModel Model { get; set; }
        public CreateMovieCommand(MovieApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(movie => movie.MovieName == Model.MovieName);

            if (movie != null)
                throw new InvalidOperationException("Movie is already exist!!");

            //context'im Entity alıyor, Entity'i yaratıp onun fieldlarına Model içerisinden setliyor olmam gerekiyor.
            movie = new Movie();
            movie.MovieName = Model.MovieName;
            movie.Director = Model.Director;
            movie.GenreId = Model.GenreId;
            movie.ReleaseYear = Model.ReleaseYear;
            movie.IMDB = Model.IMDB;
            movie.Price = Model.Price;
            movie.MovieStory = Model.MovieStory;

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            
        }
        //buradaki model Usera göstermek istediğimiz model değil almak sitediğimiz model, input.
        //Yani controllerdaki Entity Model'e karşılık geliyor.
        public class CreateMovieModel
        {
            public string MovieName { get; set; }
            public string Director { get; set; }
            public int GenreId { get; set; }
            public DateTime ReleaseYear { get; set; }
            public double IMDB { get; set; }
            public double Price { get; set; }
            public string MovieStory { get; set; }
        }
    }
}
