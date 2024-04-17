using AloPizza.Models;
using AloPizza.Repositories.Interface;
using AloPizza.Context;
using Microsoft.EntityFrameworkCore;


namespace AloPizza.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly AppDbContext _context;
        public PizzaRepository(AppDbContext contextPizza)
        {
            _context = contextPizza;
        }

        public IEnumerable<Pizza> Pizzas => _context.Pizzas.Include(c => c.Category);

        public IEnumerable<Pizza> FavoritePizza => _context.Pizzas.Where(p => p.IsPizzaPreferred).Include(c => c.Category);

        public Pizza GetPizzaById(int pizzaId)
        {
            return _context.Pizzas.FirstOrDefault(p => p.PizzaId == p.PizzaId);
        }
    }
}