using Microsoft.AspNetCore.Mvc;

namespace LootHub.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
