using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Dashboard.API.Models
{
    [Table("circuit")]
    public class Circuit
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ref")]
        public string? Reference { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("country")]
        public string? Country { get; set; }

        [Column("lat")]
        public decimal? Latitude { get; set; }

        [Column("lng")]
        public decimal? Longitude { get; set; }

        [Column("alt")]
        public int? Altitude { get; set; }

        [Column("url")]
        public string? Url { get; set; }
    }
} 