using MovieApplication.DBOperations;

namespace MovieApplication.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieApplicationDbContext _dbcontext;
        public int  MovieId {get; set;}
        public DeleteMovieCommand(MovieApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public void Handle()
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x => x.MovieId == MovieId);

            if (movie == null)
                throw new InvalidOperationException("Movie record with id is not found!!");

            _dbcontext.Movies.Remove(movie);
            _dbcontext.SaveChanges();
        }
    }
}

