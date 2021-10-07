using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeConService.Controllers;
using TeConService.Models;

namespace TeConService.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Varient> Varients { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Test).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Question).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Varient).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
