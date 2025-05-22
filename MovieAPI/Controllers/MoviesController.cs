using Microsoft.AspNetCore.Mvc;
using MovieAPI.Interfaces;

namespace MovieAPI.Controllers
{
    /// <summary>
    /// ApiController for Movies
    /// </summary>
    [ApiController]
    
    public class MoviesController(IMovieDataAccess _movieDataAccess) : ControllerBase
    {
        /// <summary>
        /// ApiController method for returning Movies by Title, with paging and sorting
        /// </summary>
        [Route("api/GetMoviesByTitle")]
        [HttpGet()]

        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByTitle(string movieTitle, int? pageNumber = 0, int? pageSize = 0, string SortBy = "Title")
        {
            if (string.IsNullOrEmpty(movieTitle))
            {
                return BadRequest("Movie title is required.");
            }
            var movies = await _movieDataAccess.GetMoviesByTitle(movieTitle, pageNumber, pageSize, SortBy);
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found with the given title.");
            }
            return Ok(movies);
        }

        /// <summary>
        /// ApiController method for returning Movies by Genre, with paging and sorting
        /// </summary>
        [Route("api/GetMoviesByGenre")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenre(string Genre, int? PageNumber = 0, int? PageSize = 0, string SortBy = "Title")
        {
            if (string.IsNullOrEmpty(Genre))
            {
                return BadRequest("Movie genre is required.");
            }
            var movies = await _movieDataAccess.GetMoviesByGenre(Genre, PageNumber, PageSize, SortBy);
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found in the given genre.");
            }
            return Ok(movies);
        }
    }
}
