using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Dashboard.API.Models
{
    [Table("race")]
    public class Race
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("round")]
        public int Round { get; set; }

        [Column("circuit_id")]
        public int CircuitId { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("time")]
        public TimeSpan? Time { get; set; }

        [Column("url")]
        public string? Url { get; set; }

        [ForeignKey("CircuitId")]
        public Circuit? Circuit { get; set; }
    }
} 