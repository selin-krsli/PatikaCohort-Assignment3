using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.DBOperations;
using MovieApplication.MovieOperations.CreateBook;
using MovieApplication.MovieOperations.DeleteMovie;
using MovieApplication.MovieOperations.GetMovieDetail;
using MovieApplication.MovieOperations.GetMovies;
using MovieApplication.MovieOperations.UpdateBook;
using static MovieApplication.MovieOperations.CreateBook.CreateMovieCommand;
using static MovieApplication.MovieOperations.UpdateBook.UpdateMovieCommand;

namespace MovieApplication.Controllers
{
    [ApiController]
    [Route("first-week/hmw/[controller]s")]
    public class MovieController: ControllerBase
    {
        //constructorlar aracılığyla inject edilen DbContexi alabilirim.
        private readonly MovieApplicationDbContext _context;
      
        public MovieController(MovieApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public IActionResult GetMovies()
        {
            GetMovieQuery query = new GetMovieQuery(_context);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByMovieId(int id)
        {          
            object result = null;
            try
            {
                GetMovieDetailQuery query = new GetMovieDetailQuery(_context);
                query.MovieId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }         
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context);
            try
            {

                command.Model = newMovie;
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdatedMovieViewModel updatedMovie)
        {

            try
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_context);
                command.MovieId = id;
                command.Model = updatedMovie;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();

        }

    }
}
