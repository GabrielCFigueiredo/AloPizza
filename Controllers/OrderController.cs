using AloPizza.Models;
using AloPizza.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AloPizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalItemsOrdered = 0;
            decimal totalAskingPrice = 0.0m;

            List<CartPurchaseItem> items = _shoppingCart.GetCartPurchaseItems();
            _shoppingCart.CartPurchaseItems = items;

            if (_shoppingCart.CartPurchaseItems.Count == 0)
            {
                    ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um produto....");
            }
            foreach (var item in items)
            {
                totalItemsOrdered += item.Quantity;
                totalAskingPrice +=  item.Pizza.Price * item.Quantity;
            }

            order.TotalItemsOrdered = totalItemsOrdered;
            order.TotalOrder = totalAskingPrice;

            if (ModelState.IsValid)
            {
                _orderRepository.CreatOrder(order);

                ViewBag.CheckoutCompleteMessage = "Obrigado pelo seu pedido : )";
                ViewBag.TotalOrder = _shoppingCart.GetCartTotal();

                _shoppingCart.CleanFromCart();

                return View("~/Views/Order/FullCheckout.cshtml", order);
            }
            return View(order);
        }
    }
}