using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskStates.Data;
using TaskStates.Models;

namespace TaskStates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.Tasks.ToList();
            return View(items);
        }

        public IActionResult Incomplete()
        {
            var items = _db.Tasks.Where(x => x.State == "Incomplete").ToList();
            return View(items);
        }

        public IActionResult InProgress()
        {
            var items = _db.Tasks.Where(x => x.State == "In progress").ToList();
            return View(items);
        }

        public IActionResult Complete()
        {
            var items = _db.Tasks.Where(x => x.State == "Complete").ToList();
            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
