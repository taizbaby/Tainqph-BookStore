using Microsoft.AspNetCore.Mvc;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ISupplierServices _Supplier;
        public SupplierController()
        {
            _Supplier = new SupplierServices();
        }
        public IActionResult Index()
        {
            List<Supplier> Supplier = _Supplier.GetAllSupplier();
            return View(Supplier);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier Supplier)
        {
            if (_Supplier.CreateSupplier(Supplier))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Supplier Supplier = _Supplier.GetSupplierById(id);
            return View(Supplier);
        }
        public IActionResult Edit(Supplier Supplier)
        {
            if (_Supplier.UpdateSupplier(Supplier))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Supplier.DeleteSupplier(id))
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
