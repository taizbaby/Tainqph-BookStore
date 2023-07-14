using Microsoft.AspNetCore.Mvc;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleServices _Role;

        public RoleController()
        {
            _Role = new RoleServices();
        }
        public IActionResult Index()
        {
            List<Role> Role = _Role.GetAllRoles();
            return View(Role);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role Role)
        {
            if (_Role.CreateRole(Role))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Role Role = _Role.GetRoleById(id);
            return View(Role);
        }
        public IActionResult Edit(Role Role)
        {
            if (_Role.UpdateRole(Role))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Role.DeleteRole(id))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
