using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    /// <summary>
    /// Class to hold retrieved Movie Data
    /// </summary>
    public class Movie
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public DateTime Release_Date { set; get; }
        [Required]
        public string Title { set; get; }
        public string Overview { set; get; }
        public float Popularity { set; get; }
        public float Vote_Count { set; get; }
        public float Vote_Average { set; get; }
        public string Original_Language { set; get; }
        public string Genre { set; get; }
        public string Poster_Url { set; get; }
    }
}
