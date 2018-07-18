using BookeeShop.Areas.Admin.Data_Access;
using BookeeShop.Areas.Admin.Models;
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
            ViewBag.message = null;
            ViewBag.notification = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email, Password")] cast_RegisterCustomerModel user)
        {
            if (CustomerDAO.IsNullCutomer(user.Email))
            {
                ViewBag.notification = "Tài khoản chưa đăng kí";
                ModelState.Clear();
                return View();
            }
            else
            {
                int userId = new BookeeDb().Customers.FirstOrDefault(id => id.Email.Equals(user.Email)).CustomerID;
                user.Password = CustomerDAO.encryptPassword(user.Password);
                cast_RegisterCustomerModel getUserOnMock = CustomerDAO.GetUserOnMock(userId);
                if (user.Password.Equals(getUserOnMock.Password))
                {
                    return RedirectToAction("Index", "Bookee");
                }
                else
                {
                    ViewBag.notification = "Mật khẩu chưa đúng, vui lòng kiểm tra lại";
                    ModelState.Clear();
                    return View();
                }
            }
            
        }

        public ActionResult Register([Bind(Include = "FirstName, LastName, Email, Password")] cast_RegisterCustomerModel user)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (CustomerDAO.IsNullCutomer(user.Email))
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
                if (result)
                    ViewBag.message = "Đăng ký thành công";
                else
                    ViewBag.message = "Đăng ký thất bại";
            }
            else
                ViewBag.message = "Email đã đăng ký";
            ModelState.Clear();
            return View();
        }

        public ActionResult DetailBook()
        {
            return View();
        }

        public ActionResult CategoryBook()
        {
            return View();
        }
    }
}