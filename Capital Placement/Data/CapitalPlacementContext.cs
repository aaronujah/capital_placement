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
        public CapitalPlacementContext(DbContextOptions options) : base(options) { }
        public DbSet<AppProgram> AppPrograms { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);

            modelBuilder.HasDefaultContainer("AppPrograms");

            modelBuilder.Entity<AppProgram>()
                .ToContainer("AppPrograms")
                .HasPartitionKey(p => p.Id);

            modelBuilder.Entity<Application>()
                .ToContainer("Applications")
                .HasPartitionKey(a => a.Id);
        }
    }
}