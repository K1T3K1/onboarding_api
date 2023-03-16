using System;
using Microsoft.EntityFrameworkCore;

namespace OnboardingApi.Entities
{
    public class DriversContext : DbContext
    {
        private string _connectionString = "Server=127.0.0.1,1433\\mssqllocaldb;Database=OnboardingApi.BasicDB;User Id=sa;Password=P@ssw0rd;TrustServerCertificate=True;Integrated Security=False";
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Driver> Driver { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.SerialNumber).IsUnique();
            modelBuilder.Entity<Driver>().HasIndex(d => d.LicenseId).IsUnique();
            modelBuilder.Entity<Driver>().HasOne(d => d.Vehicle).WithOne(v => v.Driver).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Vehicle>().HasOne(v => v.Driver).WithOne(d => d.Vehicle).OnDelete(DeleteBehavior.SetNull);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}