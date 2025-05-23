
using MovieAPI.Models;

namespace MovieAPI.Interfaces
{
    /// <summary>
    /// Interface for Movie Data Access 
    /// </summary>
    public interface IMovieDataAccess
    {
        /// <summary>
        /// Method to get a Pagination for Movies by required Title with (Page number and Page size)
        /// </summary>  
        public Task<Pagination> GetMoviesByTitlePagination(string MovieTitle, int PageNumber = 0, int PageSize = 0, string SortColumn = "Title");

        /// <summary>
        /// Method to get a Pagination for Movies by required Genre with (Page number and Page size)
        /// </summary>  
        public Task<Pagination> GetMoviesByGenrePagination(string Genre, int PageNumber = 0, int PageSize = 0, string SortColumn = "Title");

        /// <summary>
        /// Method to get a List of Movies by required Title with optional paging (Page number and Page size) and optional sorting (SortBy)
        /// </summary>  
        public Task<IEnumerable<Movie>> GetMoviesByTitle(string MovieTitle, string? SortColumn = "Title");

        /// <summary>
        /// Method to get a List of Movies by required Genre with optional paging (Page number and Page size) and optional sorting (SortBy)
        /// </summary>
        public Task<IEnumerable<Movie>> GetMoviesByGenre(string Genre, string? SortColumn = "Title");

    }
}
