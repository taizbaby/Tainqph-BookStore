﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;
using NQT_BookStore.Services;
using System.Diagnostics;

namespace NQT_BookStore.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _User;
        private readonly ICartServices _CartServices;
        private readonly ICartDetailsServices _CartDetailsServices;
        private readonly IRoleServices _RoleServices;
        private ShoppingDbContext context;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _User = new UserServices();
            _CartServices = new CartServices();
            _CartDetailsServices = new CartDetailsServices();
            _RoleServices = new RoleServices();
            context = new ShoppingDbContext();
        }
        //---------------User------------
        public IActionResult Indexl()
        {
            var User = context.Users.Include("Role").ToList();
            return View(User);
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("acc");
            return RedirectToAction("Login");
        }
        public ActionResult Login(string username, string password)
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");

            if (ModelState.IsValid)
            {
                var data = context.Users.Include("Role").FirstOrDefault(s => s.UserName.Equals(username) && s.Password.Equals(password));
                if (data != null)
                {
                    //add Session
                    HttpContext.Session.SetString("acc", data.UserName);
                    HttpContext.Session.SetString("role", data.Role.Name);
                    var acc = HttpContext.Session.GetString("acc");
                    TempData["Message"] = "Xin chào " + acc + " đã đến với MixiShop";

                    var x = _User.GetAllUser().FirstOrDefault(x => x.UserName == username);
                    var lstCart = _CartServices.GetAllCart();
                    var cartDetails = _CartDetailsServices.GetAllCartDetails().Where(c => c.UserID == x.ID).ToList();
                    HttpContext.Session.SetString("CartDetailsUser", cartDetails.Count().ToString());
                    if (lstCart.FirstOrDefault(c => c.ID == x.ID) == null)
                    {
                        Cart cart = new Cart()
                        {
                            ID = x.ID,
                            Describe = null,
                        };
                        _CartServices.CreateCart(cart);
                    }
                    HttpContext.Session.Remove("Cart");
                    return RedirectToAction("Index", "Home");

                }
                else
                {

                    TempData["AlertMessage"] = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(User User)
        {

            if (_User.CreateUser(User))
            {
                Cart cart = new Cart()
                {
                    ID = User.ID,
                    Describe = null
                };
                _CartServices.CreateCart(cart);
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
            User User = _User.GetUserById(id);
            return View(User);
        }
        public IActionResult Edit(User User)
        {
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
            if (_User.UpdateUser(User))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_User.DeleteUser(id))
            {
                return RedirectToAction("ShowAll");
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
