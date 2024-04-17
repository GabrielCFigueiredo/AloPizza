using AloPizza.Models;
using AloPizza.Repositories.Interface;
using AloPizza.Context;

namespace AloPizza.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}