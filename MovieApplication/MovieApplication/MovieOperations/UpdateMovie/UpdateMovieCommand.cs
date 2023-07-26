using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.UpdateBook
{
    public class UpdateMovieCommand
    {
        private readonly MovieApplicationDbContext _context;
        public UpdatedMovieViewModel Model { get; set; }
        public int MovieId { get; set; }
        public UpdateMovieCommand(MovieApplicationDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(s => s.MovieId == MovieId);
            if(movie == null)
            {
                throw new InvalidOperationException("There is no any movie which is that updating record!!");
            }

            movie.MovieName = Model.MovieName != default ? Model.MovieName : movie.MovieName;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            movie.MovieStory = Model.MovieStory != default ? Model.MovieStory : movie.MovieStory;
            _context.SaveChanges();
        }
        public class UpdatedMovieViewModel
        {
            public string MovieName { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
            public string MovieStory { get; set; }
        }
    }
}
