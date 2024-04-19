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

            pizzas = _pizzaRepository.Pizzas.Where(l => l.Category.CategoryName.Equals(category))
            .OrderBy(c => c.Name);

            currentCategory = category;
            
        }

        var pizzaListViewModel = new PizzaListViewModels
        {
            Pizzas = pizzas,
            CurrentCategory = currentCategory
        };

        return View(pizzaListViewModel);
    }

    public IActionResult Details(int pizzaId)
    {
        var pizza = _pizzaRepository.Pizzas.FirstOrDefault(l => l.PizzaId == pizzaId);
        return View(pizza);
    }

    public ViewResult Search(string searchString)
    {
        IEnumerable<Pizza> pizzas;
        string currentCategory = string.Empty;

        if (string.IsNullOrEmpty(searchString))
        {
            pizzas = _pizzaRepository.Pizzas.OrderBy(p => p.PizzaId);
            currentCategory = "Todas as Pizzas";
        }else
        {
            pizzas = _pizzaRepository.Pizzas
            .Where(p => p.Name.ToLower().Contains(searchString.ToLower()));

            if (pizzas.Any())
            {
                currentCategory = "Pizzas";
            }else
            {
                currentCategory = "Nenhum Produto foi encontrado";
            }
        }
            return View("~/Views/Pizza/List.cshtml", new PizzaListViewModels
            {
                Pizzas = pizzas,
                CurrentCategory = currentCategory
            });
    }
   } 
}