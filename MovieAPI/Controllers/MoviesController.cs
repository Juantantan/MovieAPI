using Microsoft.AspNetCore.Mvc;
using MovieAPI.Interfaces;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    /// <summary>
    /// ApiController for Movies
    /// </summary>
    [ApiController]
    
    public class MoviesController(IMovieDataAccess _movieDataAccess) : ControllerBase
    {
        /// <summary>
        /// ApiController method for returning Movies by Title, with pagination and sorting
        /// </summary>
        [Route("api/GetMoviesByTitleWithPagination")]
        [HttpGet()]
        public async Task<ActionResult<Pagination>> GetMoviesByTitlePagination(string MovieTitle, int PageNumber = 0, int PageSize = 0, string SortColumn = "Title")
        {
            if (string.IsNullOrEmpty(MovieTitle))
            {
                return BadRequest("Movie title is required.");
            }
            var pagination = await _movieDataAccess.GetMoviesByTitlePagination(MovieTitle, PageNumber, PageSize, SortColumn);
            if (pagination == null)
            {
                return NotFound("No movies found with the given title.");
            }
            return Ok(pagination);
        }

        /// <summary>
        /// ApiController method for returning Movies by Genre, with pagination and sorting
        /// </summary>
        [Route("api/GetMoviesByGenreWithPagination")]
        [HttpGet()]
        public async Task<ActionResult<Pagination>> GetMoviesByGenrePagination(string Genre, int PageNumber = 0, int PageSize = 0, string SortColumn = "Title")
        {
            if (string.IsNullOrEmpty(Genre))
            {
                return BadRequest("Movie title is required.");
            }
            var pagination = await _movieDataAccess.GetMoviesByGenrePagination(Genre, PageNumber, PageSize, SortColumn);
            if (pagination == null)
            {
                return NotFound("No movies found with the given Genre.");
            }
            return Ok(pagination);
        }

        /// <summary>
        /// ApiController method for returning Movies by Title, with sorting
        /// </summary>
        [Route("api/GetMoviesByTitle")]
        [HttpGet()]

        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByTitle(string MovieTitle, string SortBy = "Title")
        {
            if (string.IsNullOrEmpty(MovieTitle))
            {
                return BadRequest("Movie title is required.");
            }
            var movies = await _movieDataAccess.GetMoviesByTitle(MovieTitle, SortBy);
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found with the given title.");
            }
            return Ok(movies);
        }

        /// <summary>
        /// ApiController method for returning Movies by Genre, with sorting
        /// </summary>
        [Route("api/GetMoviesByGenre")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenre(string Genre, string SortBy = "Title")
        {
            if (string.IsNullOrEmpty(Genre))
            {
                return BadRequest("Movie genre is required.");
            }
            var movies = await _movieDataAccess.GetMoviesByGenre(Genre, SortBy);
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found in the given genre.");
            }
            return Ok(movies);
        }
    }
}
