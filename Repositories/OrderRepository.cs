using AloPizza.Context;
using AloPizza.Models;
using AloPizza.Repositories.Interface;
using Name;

namespace AloPizza.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appContext;
            _shoppingCart = shoppingCart;
        }
        public void CreatOrder(Order order)
        {
            order.OrderDispatched = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var cartBuyItems = _shoppingCart.CartPurchaseItems;

            foreach (var cartItems in cartBuyItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = cartItems.Quantity,
                    PizzaId = cartItems.Pizza.PizzaId,
                    OrderId = order.OrderId,
                    Price = cartItems.Pizza.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}