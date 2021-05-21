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

        public DbSet<Product> Product { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
