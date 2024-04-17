using Microsoft.AspNetCore.Mvc;

namespace AloPizza.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}