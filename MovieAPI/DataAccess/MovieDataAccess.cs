using Microsoft.Data.SqlClient;
using MovieAPI.Interfaces;

namespace MovieAPI.DataAccess
{
    /// <summary>
    /// Class for Movie Data Access 
    /// </summary>
    public class MovieDataAccess(IConfiguration config): IMovieDataAccess
    {
        private string? connectionString = config.GetConnectionString("Default");

        /// <summary>
        /// Method to get a List of Movies by required Title with optional paging (Page number and Page size) and optional sorting (SortColumn)
        /// If SortColumn is null or empty, it defaults to "Title" and this is passed to the Stored Procedure
        /// </summary>  
        public async Task<IEnumerable<Movie>> GetMoviesByTitle(string MovieTitle, int? PageNumber = 0, int? PageSize = 0, string? SortColumn = "Title")
        {
             
            List<Movie> movies = new List<Movie>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "GetMoviesByTitleWithOptionalPaging_SP";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await con.OpenAsync();
                cmd.Parameters.AddWithValue("@MovieTitle", MovieTitle);
                cmd.Parameters.AddWithValue("@PageNumber",
                    PageNumber > 0 ? (object)PageNumber.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@PageSize",
                    PageSize > 0 ? (object)PageSize.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@SortColumn", SortColumn);

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    
                    movies.Add (new Movie
                    {
                        Title = rdr["Title"].ToString(),
                        Release_Date = Convert.ToDateTime(rdr["Release_Date"]),
                        Overview = rdr["Overview"].ToString(),
                        Popularity = (float)Convert.ToDouble(rdr["Popularity"]),
                        Vote_Count = (float)Convert.ToDouble(rdr["Vote_Count"]),
                        Vote_Average = (float)Convert.ToDouble(rdr["Vote_Average"]),
                        Original_Language = rdr["Original_Language"].ToString(),
                        Genre = rdr["Genre"].ToString(),
                        Poster_Url = rdr["Poster_Url"].ToString(),
                        Id = Convert.ToInt32(rdr["Id"])
                    });
                }
            }
            return movies;
        }

        /// <summary>
        /// Method to get a List of Movies by required Genre with optional paging (Page number and Page size) and optional sorting (SortColumn)
        /// If SortColumn is null or empty, it defaults to "Title" and this is passed to the Stored Procedure
        /// </summary>
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(string Genre, int? PageNumber = 0, int? PageSize = 0, string? SortColumn = "Title")
        {

            List<Movie> movies = new List<Movie>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "GetMoviesByGenreWithOptionalPaging_SP";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await con.OpenAsync();
                cmd.Parameters.AddWithValue("@Genre", Genre);
                cmd.Parameters.AddWithValue("@PageNumber",
                    PageNumber > 0 ? (object)PageNumber.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@PageSize",
                    PageSize > 0 ? (object)PageSize.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@SortColumn", SortColumn);

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (rdr.Read())
                {
                    movies.Add(new Movie
                    {
                        Title = rdr["Title"].ToString(),
                        Release_Date = Convert.ToDateTime(rdr["Release_Date"]),
                        Overview = rdr["Overview"].ToString(),
                        Popularity = (float)Convert.ToDouble(rdr["Popularity"]),
                        Vote_Count = (float)Convert.ToDouble(rdr["Vote_Count"]),
                        Vote_Average = (float)Convert.ToDouble(rdr["Vote_Average"]),
                        Original_Language = rdr["Original_Language"].ToString(),
                        Genre = rdr["Genre"].ToString(),
                        Poster_Url = rdr["Poster_Url"].ToString(),
                        Id = Convert.ToInt32(rdr["Id"])
                    });
                }
            }
            return movies;
        }
    }
}
