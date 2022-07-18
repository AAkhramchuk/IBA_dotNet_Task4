using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4MovieLibraryApi
{
    /// <summary>
    /// Model Movie
    /// </summary>
    [Table("Movie")]
    public class Movie
    {
        public int ID { get; set; }
        public string? ProducerName { get; set; }
        public string? ProducerSurname { get; set; }
        public string? MovieName { get; set; }
        public int? MovieYear { get; set; }
        public int? MovieRating { get; set; }
    }
}