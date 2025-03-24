using F1Dashboard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace F1Dashboard.API.Data
{
    public class F1DbContext : DbContext
    {
        public F1DbContext(DbContextOptions<F1DbContext> options) : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Circuit> Circuits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names to match PostgreSQL schema
            modelBuilder.Entity<Driver>().ToTable("driver");
            modelBuilder.Entity<Constructor>().ToTable("constructor");
            modelBuilder.Entity<Race>().ToTable("race");
            modelBuilder.Entity<Circuit>().ToTable("circuit");
        }
    }
} 