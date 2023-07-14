using Microsoft.AspNetCore.Mvc;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryServices _category;
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _category = new CategoryServices();
        }
        //---------------Category------------
        public IActionResult Index()
        {
            List<Category> categories = _category.GetAllCategory();
            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_category.CreateCategory(category))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Category category = _category.GetCategoryById(id);
            return View(category);
        }
        public IActionResult Edit(Category category)
        {
            if (_category.UpdateCategory(category))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_category.DeleteCategory(id))
            {
                return RedirectToAction("Indexl");
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
