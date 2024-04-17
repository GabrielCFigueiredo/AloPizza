using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AloPizza.Models;
using AloPizza.Repositories.Interface;
using AloPizza.ViewModels;

namespace alo_pizza.Controllers;

public class HomeController : Controller
{
    private readonly IPizzaRepository _pizzaRepository;

    public HomeController(IPizzaRepository pizzaRepository)
    {
        _pizzaRepository = pizzaRepository;
    }

    public IActionResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            FavoritePizza = _pizzaRepository.FavoritePizza
        };
        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
