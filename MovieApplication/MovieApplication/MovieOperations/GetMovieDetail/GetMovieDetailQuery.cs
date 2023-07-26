using Microsoft.EntityFrameworkCore;
using MovieApplication.Comman;
using MovieApplication.DBOperations;
using System.Reflection.Metadata;

namespace MovieApplication.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieApplicationDbContext _dbContext;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(MovieApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(movie => movie.MovieId == MovieId).FirstOrDefault();
            if (movie == null)
                throw new InvalidOperationException("Movie record is not found!!");

            //aldığım movie'yi ViewModele maplemem lazım.
            MovieDetailViewModel viewModel = new MovieDetailViewModel();
            viewModel.MovieName = movie.MovieName;
            viewModel.Genre = ((GenreEnum)movie.GenreId).ToString();
            viewModel.Director = movie.Director;
            viewModel.ReleaseYear = movie.ReleaseYear.Date.ToString("yyyy/MM/dd");
            viewModel.IMDB = movie.IMDB;
            viewModel.Price = movie.Price;  
            viewModel.MovieStory = movie.MovieStory;
            return viewModel;
        }
    }
    public class MovieDetailViewModel
    {
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string ReleaseYear { get; set; }
        public double Price { get; set; }
        public double IMDB { get; set; }
        public string MovieStory { get; set; }
    }
}
