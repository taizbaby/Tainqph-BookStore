using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _Product;
        private readonly ITypesServicese _TypeServices;
        private readonly ICategoryServices _CategoryService;
        private readonly ISupplierServices _SupplierService;
        private readonly IProducerServices _ProducerService;
        private ShoppingDbContext context;
        public ProductController()
        {
            _Product = new ProductServices();
            context = new ShoppingDbContext();
            _TypeServices = new TypesServices();
            _CategoryService = new CategoryServices();
            _SupplierService = new SupplierServices();
            _ProducerService = new ProducerServices();
        }
        public IActionResult Index()
        {
            var Product = context.Product.Include("Types").Include("Producer").Include("Category")
                .Include("Supplier").ToList();
            return View(Product);
        }

        public IActionResult Create()
        {
            
            ViewBag.Types = new SelectList(_TypeServices.GetAllTypes(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategory(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSupplier(), "ID", "Name");
            ViewBag.Producers = new SelectList(_ProducerService.GetAllProducer(), "ID", "Name");
            return View();
        }

        [HttpPost]

        public IActionResult Create(Product Product, [Bind] IFormFile imageFile)
        {
            //var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwwroot","img", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyToAsync(stream);
                }
                Product.Images = imageFile.FileName;
            }
            if (_Product.CreateProduct(Product))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Types = new SelectList(_TypeServices.GetAllTypes(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategory(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSupplier(), "ID", "Name");
            ViewBag.Producers = new SelectList(_ProducerService.GetAllProducer(), "ID", "Name");
            Product product = _Product.GetProductById(id);
            return View(product);
        }

        public IActionResult Edit(Product Product, [Bind] IFormFile imageFile)
        {
            ViewBag.Types = new SelectList(_TypeServices.GetAllTypes(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategory(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSupplier(), "ID", "Name");
            ViewBag.Producers = new SelectList(_ProducerService.GetAllProducer(), "ID", "Name");
            var update = _Product.GetProductById(Product.ID);
            var x = imageFile.FileName;
            if(imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", " images", imageFile.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                update.Images = imageFile.FileName;
            }
            else
            {
                update.Images = "";
            }
            if (_Product.UpdateProduct(update))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Fail");
            }
         }

        public IActionResult Delete(Guid id)
        {
            if (_Product.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            return Content("Fail");
        }


        public int MyProperty { get; set; }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
