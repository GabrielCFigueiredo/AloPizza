using AloPizza.Context;
using Microsoft.EntityFrameworkCore;

namespace AloPizza.Models;

public class ShoppingCart
{
    private readonly AppDbContext _context;

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public string ShoppingCartId { get; set; }
    public List<CartPurchaseItem> CartPurchaseItems { get; set; }
    public static ShoppingCart GetShopping(IServiceProvider services)
    {
        ISession session = 
        services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var context = services.GetService<AppDbContext>();

        string CartId = session.GetString("CartId")?? Guid.NewGuid().ToString();

        session.SetString("CartId", CartId);

        return new ShoppingCart(context)
    {
        ShoppingCartId = CartId
    };
    }
    public void AddCart(Pizza pizza)
    {
        var cartPurchaseItem = _context.CartShoppingItems.SingleOrDefault(item => item.Pizza.PizzaId == pizza.PizzaId && 
        item.ShoppingCartId == ShoppingCartId
        );

        if (cartPurchaseItem == null)
        {
            cartPurchaseItem = new CartPurchaseItem
            {
                ShoppingCartId = ShoppingCartId,
                Pizza = pizza,
                Quantity = 1
            };
            _context.CartShoppingItems.Add(cartPurchaseItem);
        }
        else
        {
            cartPurchaseItem.Quantity++;
        }
        _context.SaveChanges();
    }
    public int RemoveFromCart(Pizza pizza)
    {
        var cartPurchaseItem = _context.CartShoppingItems.SingleOrDefault(item => item.Pizza.PizzaId == pizza.PizzaId && 
        item.ShoppingCartId == ShoppingCartId
        );

        var LocalQuantity = 0;

        if (cartPurchaseItem != null)
        {
            if (cartPurchaseItem.Quantity > 1)
            {
                cartPurchaseItem.Quantity--;
                LocalQuantity = cartPurchaseItem.Quantity;
            }
        else
        {
            _context.CartShoppingItems.Remove(cartPurchaseItem);
        }
        }
        _context.SaveChanges();
        return LocalQuantity;
    }

    public List<CartPurchaseItem> GetCartPurchaseItems()
    {
        return CartPurchaseItems ?? 
        (CartPurchaseItems = _context.CartShoppingItems
        .Where(c => c.ShoppingCartId == ShoppingCartId)
            .Include(s => s.Pizza).ToList());
    }

    public void CleanFromCart()
    {
        var cartItens = _context.CartShoppingItems.Where(cart 
        => cart.ShoppingCartId == ShoppingCartId);

        _context.CartShoppingItems.RemoveRange(cartItens);
        _context.SaveChanges();
    }

    public decimal GetCartTotal()
    {
        var total = _context.CartShoppingItems
        .Where(c => c.ShoppingCartId == ShoppingCartId)
        .Select(c => c.Pizza.Price * c.Quantity).Sum();

        return total;
    }
}