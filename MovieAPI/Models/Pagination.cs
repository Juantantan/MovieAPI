namespace MovieAPI.Models
{
    /// <summary>
    /// Class to hold Pagination Data. This forms the Parent part of a Text/Json response for Movie Children
    /// </summary>
    public class Pagination
    {
        public int TotalRecordCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public Pagination(int pageNumber, int pageSize, int totalRecordCount, int totalPages)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecordCount = totalRecordCount;
            TotalPages = totalPages;
        }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
