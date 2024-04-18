using AloPizza.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AloPizza.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorys = _categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(categorys);
        }
    }
}