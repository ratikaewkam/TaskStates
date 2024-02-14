using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskStates.Data;
using TaskStates.Models;
using TaskStates.ViewModels;

namespace TaskStates.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TasksController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment) 
        {  
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel vm)
        {
            string img = Upload(vm);
            var obj = new TaskModel
            {
                TaskName = vm.TaskName,
                Room = vm.Room,
                State = "Incomplete",
                Img = img
            };

            if (ModelState.IsValid) 
            { 
                _db.Tasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var taskFromDB = _db.Tasks.Find(id);

            if (taskFromDB == null)
            {
                return NotFound();
            }

            return View(taskFromDB);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var taskFromDB = _db.Tasks.Find(id);

            if (taskFromDB == null)
            {
                return NotFound();
            }

            return View(taskFromDB);
        }

        [HttpPost]
        public IActionResult DeleteTask(int? id)
        {
            var obj = _db.Tasks.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Tasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        private string Upload(CreateViewModel vm)
        {
            string fileName = null;
            if (vm.Img != null)
            {
                string dir = Path.Combine(_webHostEnvironment.WebRootPath, "temp");
                fileName = Guid.NewGuid().ToString() + "-" + vm.Img.FileName;
                string filePath = Path.Combine(dir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Img.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
