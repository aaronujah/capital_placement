using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Models;
using Microsoft.EntityFrameworkCore;

namespace Capital_Placement.Data
{
    public class CapitalPlacementContext: DbContext
    {
        public DbSet<AppProgram>? Programs { get; set; }
        public DbSet<Application>? Applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "CapitalPLacementDb"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);

            modelBuilder.HasDefaultContainer("Products");

            modelBuilder.Entity<AppProgram>()
                .ToContainer("Programs")
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<Application>()
                .ToContainer("Applications")
                .HasPartitionKey(a => a.Id);
        }
    }
}