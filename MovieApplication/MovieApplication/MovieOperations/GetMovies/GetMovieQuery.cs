using MovieApplication.Comman;
using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.GetMovies
{
    public class GetMovieQuery
    {
        private readonly MovieApplicationDbContext _dbContext;
        public GetMovieQuery(MovieApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(s => s.MovieId).ToList<Movie>();

            List<MoviesViewModel> viewModel = new List<MoviesViewModel>();

            foreach (var movie in movieList)
            {
                viewModel.Add(new MoviesViewModel()
                {
                    MovieName = movie.MovieName,
                    Director = movie.Director,
                    ReleaseYear = movie.ReleaseYear.Date.ToString("yyyy/MM/dd"),
                    Genre = ((GenreEnum)movie.GenreId).ToString(),
                    IMDB = movie.IMDB,
                    Price = movie.Price,
                    MovieStory = movie.MovieStory
                }); 
            }
            return viewModel;
        }
        public class MoviesViewModel
        {
            public string MovieName { get; set; }
            public string Director { get; set; }
            public string ReleaseYear { get; set; }
            public string Genre { get; set; }
            public double IMDB { get; set; }
            public double Price { get; set; }
            public string MovieStory { get; set; }
        }
    }
}
