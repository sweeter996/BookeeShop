using BookeeShop.Areas.Admin.Data_Access;
using BookeeShop.Areas.Admin.Models;
using BookeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            ViewBag.resultMessage = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(castCustomerModel user)
        {
            if(CustomerDAO.isNullCutomer(user.Email))
            {
                using (var db = new BookeeDb())
                {
                    CustomerModel customer = new CustomerModel();
                    customer.Email = user.Email;
                    customer.isActive = true;
                    customer.CreatedDate = DateTime.Now;
                    customer.LastDateModified = null;
                    db.Customers.Add(entity: customer);
                    db.SaveChanges();
                }
                user.Password = CustomerDAO.encryptPassword(user.Password);
                Boolean result = CustomerDAO.InsertOnMock(user);
                if(result)
                    ViewBag.resultMessage = "Đăng ký thành công";
                else
                    ViewBag.resultMessage = "Đăng ký thất bại";
            }
            else
                ViewBag.resultMessage = "Email đã đăng ký";
            ModelState.Clear();
            return View();
        }
        
    }
}