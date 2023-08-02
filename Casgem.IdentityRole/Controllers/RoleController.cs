using Casgem.IdentityRole.DAL;
using Casgem.IdentityRole.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Casgem.IdentityRole.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult UsersList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult RolesList()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddViewModel model)
        {
            AppRole appRole = new AppRole
            {
                Name = model.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("RolesList");
            }
            ViewBag.error = "Hata: rol atanamadı!";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("RolesList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = value.Id,
                Name = value.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            value.Name = model.Name;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("RolesList");
        }
    }
}