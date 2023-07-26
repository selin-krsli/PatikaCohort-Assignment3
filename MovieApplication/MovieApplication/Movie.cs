using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApplication
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public double IMDB { get; set; }
        public double Price { get; set; }
        public string MovieStory { get; set; }
    }
}
