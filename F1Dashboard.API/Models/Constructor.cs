using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Dashboard.API.Models
{
    [Table("constructor")]
    public class Constructor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ref")]
        public string? Reference { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("nationality")]
        public string? Nationality { get; set; }

        [Column("url")]
        public string? Url { get; set; }
    }
} 