using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Absa.Infrastructure.EntityFramework.Entities;

namespace Absa.Infrastructure.EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().ToTable("Entries", schema: "Absa");

            modelBuilder.Entity<Phonebook>().ToTable("Phonebooks", schema: "Absa");
        }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<Phonebook> Phonebooks { get; set; }
    }
}