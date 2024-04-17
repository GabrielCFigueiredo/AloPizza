using AloPizza.Models;
using AloPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AloPizza.Components;

public class ShoppingCartSummary : ViewComponent
{
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        //var itens = _shoppingCart.GetCartPurchaseItems();

        var itens = new List<CartPurchaseItem>()
        {
            new CartPurchaseItem(),
            new CartPurchaseItem()
        };
        _shoppingCart.CartPurchaseItems = itens;

        var shoppingCartVM = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetCartTotal()
        };
        return View(shoppingCartVM);
    }
}