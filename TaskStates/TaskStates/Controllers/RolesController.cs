using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TaskStates.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //list of roles
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole identity)
        {
            //avoid duplicacy
            if (!_roleManager.RoleExistsAsync(identity.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(identity.Name)).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");
        }
    }
}
