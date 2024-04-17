using AloPizza.Models;

namespace AloPizza.ViewModels
{
   public class PizzaListViewModels
   {
    public IEnumerable<Pizza> Pizzas { get; set; }
    public string CurrentCategory { get; set; }
   } 
}