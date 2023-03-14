using System;
using Microsoft.EntityFrameworkCore;

namespace OnboardingApi.Entities
{
    public class DriversContext : DbContext
    {
        private string _connectionString = "Server=127.0.0.1,1433\\mssqllocaldb;Database=OnboardingApi.BasicDB;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;Integrated Security=False";
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Driver { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}