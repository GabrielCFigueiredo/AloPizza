using AloPizza.Models;
using AloPizza.Repositories.Interface;
using AloPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace alo_pizza.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPizzaRepository pizzaRepository, ShoppingCart shoppingCart)
        {
            _pizzaRepository = pizzaRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetCartPurchaseItems();
            _shoppingCart.CartPurchaseItems = itens;

            var shoppingCartVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetCartTotal()
            };
            return View(shoppingCartVM);
        }

        public RedirectToActionResult AddItemToShoppingCart(int pizzaId)
        {
            var SelectedPizza = _pizzaRepository.Pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (SelectedPizza != null)
            {
                _shoppingCart.AddCart(SelectedPizza);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveItemFromCart(int pizzaId)
        {
            var RemoveSelectedPizza = _pizzaRepository.Pizzas.FirstOrDefault(r => r.PizzaId == pizzaId);
            if (RemoveSelectedPizza != null)
            {
                _shoppingCart.RemoveFromCart(RemoveSelectedPizza);
            }
            return RedirectToAction("Index");
        }
    }
}