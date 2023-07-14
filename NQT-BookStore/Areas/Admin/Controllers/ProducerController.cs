using Microsoft.AspNetCore.Mvc;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProducerController : Controller
    {
        private readonly IProducerServices _Producer;
        public ProducerController()
        {
            _Producer = new ProducerServices();
        }
        public IActionResult Index()
        {
            List<Producer> Producer = _Producer.GetAllProducer();
            return View(Producer);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producer Producer)
        {
            if (_Producer.CreateProducer(Producer))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Producer Producer = _Producer.GetProducerById(id);
            return View(Producer);
        }
        public IActionResult Edit(Producer Producer)
        {
            if (_Producer.UpdateProducer(Producer))
            {
                return RedirectToAction("Index");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Producer.DeleteProducer(id))
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
