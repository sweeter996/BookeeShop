using BookeeShop.Areas.Admin.Data_Access;
using BookeeShop.Areas.Admin.Models;
using BookeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookeeShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.notification = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(cast_LoginCustomerModel user)
        {
            if(CustomerDAO.IsNullCutomer(user.Email))
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
                if(user.Password.Equals(getUserOnMock.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.notification = "Mật khẩu chưa đúng, vui lòng kiểm tra lại";
                    ModelState.Clear();
                    return View();
                }
                
            }
        }
    }
}