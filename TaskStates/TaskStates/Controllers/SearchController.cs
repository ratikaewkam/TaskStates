using Microsoft.AspNetCore.Mvc;
using TaskStates.Data;

namespace TaskStates.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string title, string room)
        {
            var items = _db.Tasks.Where(x => x.TaskName.Contains(title) && x.Room.Contains(room)).ToList();
            return View(items);
        }
    }
}
