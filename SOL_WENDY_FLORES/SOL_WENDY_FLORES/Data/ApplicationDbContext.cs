using SOL_WENDY_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SOL_WENDY_FLORES.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");
        }
        public DbSet<USUARIOS> USUARIOS { get; set; }
        public DbSet<LIBROS> LIBROS { get; set; }
        public DbSet<PRESTAMOLIBROS> PRESTAMOLIBROS { get; set; }
    }
}