using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeConService.Controllers;

namespace TeConService.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tests> Tests { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Tests).Assembly);
            modelBuilder.Entity<Tests>(a =>
            {
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        }
    }
}
