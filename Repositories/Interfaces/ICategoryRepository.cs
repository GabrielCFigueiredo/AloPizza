using AloPizza.Models;

namespace AloPizza.Repositories.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get;}
    }
}