using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Location)
                .HasColumnType("geometry(Point, 4326)"); // Spatial veri tipi

            modelBuilder.Entity<Region>()
                .Property(p => p.Polygon)
                .HasColumnType("geometry(Polygon, 4326)"); // Spatial veri tipi
        }
    }
}
