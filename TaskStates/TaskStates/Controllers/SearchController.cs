using Microsoft.AspNetCore.Mvc;

namespace TaskStates.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
