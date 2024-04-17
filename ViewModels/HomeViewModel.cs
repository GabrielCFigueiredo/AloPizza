using AloPizza.Models;

namespace AloPizza.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pizza> FavoritePizza { get; set; }
    }
}