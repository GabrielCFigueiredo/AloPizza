using AloPizza.Models;

namespace AloPizza.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart {get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}