using Microsoft.AspNetCore.Mvc;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TypeController : Controller
    {
        private readonly ITypesServicese _Types;

        public TypeController()
        {
            _Types = new TypesServices();
        }
        public IActionResult Index()
        {
            List<Types> Types  = _Types.GetAllTypes();
            return View(Types);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Types Types)
        {
            if (_Types.CreateType(Types))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]

        public IActionResult Edit(Guid id)
        {
            Types Types = _Types.GetTypeById(id);
            return View(Types);
        }

        public IActionResult Edit(Types Types)
        {
            if (_Types.UpdateType(Types))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }

        public IActionResult Delete(Guid id)
        {
            if (_Types.DeleteType(id))
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
