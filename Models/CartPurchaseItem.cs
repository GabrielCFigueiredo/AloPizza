using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AloPizza.Models
{
    [Table("CartShoppingItems")]
    public class CartPurchaseItem
    {
        public int CartPurchaseItemId { get; set; }
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}