using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftNETProject.Data;

namespace SoftNETProject.Data
{
    public class SoftNETProjectContext : DbContext
    {
        public SoftNETProjectContext (DbContextOptions<SoftNETProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SoftNETProject.Data.Product> Product { get; set; }

        public DbSet<SoftNETProject.Data.Supplier> Supplier { get; set; }

        public DbSet<SoftNETProject.Data.Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
