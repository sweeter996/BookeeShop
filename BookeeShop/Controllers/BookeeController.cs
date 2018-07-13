using BookeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookeeShop.Controllers
{
    public class BookeeController : Controller
    {
        // GET: Bookee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Class1 class1)
        {
            return RedirectToAction("Index","Bookee");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}