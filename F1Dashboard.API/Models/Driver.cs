using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Dashboard.API.Models
{
    [Table("driver")]
    public class Driver
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ref")]
        public string? Reference { get; set; }

        [Column("number")]
        public int? Number { get; set; }

        [Column("code")]
        public string? Code { get; set; }

        [Column("forename")]
        public string? Forename { get; set; }

        [Column("surname")]
        public string? Surname { get; set; }

        [Column("dob")]
        public DateTime? DateOfBirth { get; set; }

        [Column("nationality")]
        public string? Nationality { get; set; }

        [Column("url")]
        public string? Url { get; set; }
    }
} 