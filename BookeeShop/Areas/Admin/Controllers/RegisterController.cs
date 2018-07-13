using BookeeShop.Areas.Admin.Models;
using BookeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookeeShop.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(castCustomerModel user)
        {
            CustomerModel existUser = new BookeeDb().Customers.FirstOrDefault(search => search.Emmail == user.Emmail);
            if(existUser == null)
            {

            }
            return View();
        }
    }
}