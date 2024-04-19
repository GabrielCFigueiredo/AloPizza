using System.ComponentModel.DataAnnotations.Schema;
using AloPizza.Models;

namespace Name
{
    public class OrderDetail
    {
       public int OrderDetailId { get; set; }

       public int OrderId { get; set; }

       public int PizzaId { get; set; }

       public int Amount { get; set; }

       [Column(TypeName = "decimal(18,2)")]

       public decimal Price { get; set; }

       public virtual Pizza pizza { get; set; }

       public virtual Order order { get; set; }
    }
}