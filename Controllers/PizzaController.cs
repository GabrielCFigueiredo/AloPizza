using AloPizza.Models;
using AloPizza.Repositories.Interface;
using AloPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace alo_pizza.Controllers
{
   public class PizzaController : Controller
   {
    private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IActionResult List(string category)
    {
        IEnumerable<Pizza> pizzas;
        string currentCategory = string.Empty;

        if (string.IsNullOrEmpty(category))
        {
            pizzas = _pizzaRepository.Pizzas.OrderBy(l => l.PizzaId);
            currentCategory = "Todas as Pizzas";
        }else
        {
            if (string.Equals("salt", category, StringComparison.OrdinalIgnoreCase))
            {
                pizzas = _pizzaRepository.Pizzas
                .Where(l => l.Category.CategoryName.Equals("salt"))
                .OrderBy(l => l.Name);
            }
            if (string.Equals("sweet", category, StringComparison.OrdinalIgnoreCase))
            {
                pizzas = _pizzaRepository.Pizzas
                .Where(l => l.Category.CategoryName.Equals("sweet"))
                .OrderBy(l => l.Name);
            }else
            {
               pizzas = _pizzaRepository.Pizzas
                .Where(l => l.Category.CategoryName.Equals("Special"))
                .OrderBy(l => l.Name); 
            }

            currentCategory = category;
            
        }

        var pizzaListViewModel = new PizzaListViewModels
        {
            Pizzas = pizzas,
            CurrentCategory = currentCategory
        };

        return View(pizzaListViewModel);
    }
   } 
}