using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizzeria_Simone.Data
{
    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=pizza_reustaurante;Integrated Security=True");
        }
    }
}
