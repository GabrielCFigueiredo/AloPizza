using AloPizza.Models;

namespace AloPizza.Repositories.Interface
{
  public interface IPizzaRepository
  {
    IEnumerable<Pizza> Pizzas { get; }

    IEnumerable<Pizza> FavoritePizza { get; }

    Pizza GetPizzaById(int pizzaId);
  }  
}