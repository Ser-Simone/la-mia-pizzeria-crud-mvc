using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_Simone.Models;

namespace Pizzeria_Simone.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Pizza> Pizzaset { get; set; }

        public DbSet<Category> Category { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=pizza_reustaurante;Integrated Security=True");
        }
    }
}