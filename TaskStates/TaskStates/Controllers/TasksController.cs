using Microsoft.AspNetCore.Mvc;

namespace TaskStates.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
