using Microsoft.AspNetCore.Mvc;

namespace TaskStates.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit() 
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
