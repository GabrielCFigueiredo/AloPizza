using AloPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace AloPizza.Context
{
    public class AppDbContext : DbContext
    {
#pragma warning disable IDE0290 // Usar construtor primário
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
#pragma warning restore IDE0290 // Usar construtor primário
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pizza> Pizzas {get; set; }
        public DbSet<CartPurchaseItem> CartShoppingItems { get; set; }
        public object CartPurchaseItems { get; internal set; }
    }
}