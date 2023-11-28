using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Title = "Portare a spasso il cane", Description = "Devi farlo per forza mi dispiace", IssueDate = DateTime.UtcNow.AddDays(2)},
                new Item { Id = 2, Title = "Controllare il gas", Description = "A meno che tu non voglia esplodere..", IssueDate = DateTime.UtcNow.AddDays(1)},
                new Item { Id = 3, Title = "Mettere da parte dei soldi", Description = "Non sei ricco :(", IssueDate = DateTime.UtcNow.AddDays(2).AddMinutes(10).AddHours(4)}
            );
        }

        public DbSet<Item> Items { get; set; }
    }
}