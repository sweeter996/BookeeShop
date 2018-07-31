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
        [HttpGet]
        public ActionResult Index()
        {
            //using (var db = new BookeeDb())
            //{
            //    ICollection<BookCategoriesModel> categoryList = db.BookCategories.ToList();
            //    return View(categoryList.ToList());
            //}
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

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
                    Session["ID"] = userId;
                    Session["user"]= getUserOnMock.LastName + " " + getUserOnMock.FirstName;
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
                return RedirectToAction("Login");
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
                {
                    ViewBag.message = "Đăng ký thành công";
                    return RedirectToAction("Index");
                }
                    
                else
                    ViewBag.message = "Đăng ký thất bại";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.message = "Email đã đăng ký";
                ModelState.Clear();
                return RedirectToAction("Register");
            }
                
            
        }

        public ActionResult DetailBook(string bookID)
        {
            BookInformationModel detailBook = new BookeeDb().BookInformation.FirstOrDefault(book => book.BookID == bookID);
            return View(detailBook);
        }

        [HttpGet]
        public ActionResult CategoryBook(int category)
        {
            using (var db = new BookeeDb())
            {
                var temp = from book in db.BookInformation
                           where book.CategoryID.CategoryID == category
                           select new castBookModel
                           {
                               BookID = book.BookID,
                               BookName = book.BookName,
                               BookCover = book.BookCoverImage,
                               BookAuthor = book.Bookauthor,
                               BookPrice = book.BookPrice
                           };
                return View(temp.ToList());
            }
        }

        [HttpGet]
        public ActionResult InformationForBill(string id)
        {
            StaticVariable.Book_ID = id;
            if(Session["ID"]!= null)
            {
                cast_RegisterCustomerModel getUserOnMock = CustomerDAO.GetUserOnMock(Convert.ToInt32(Session["ID"].ToString()));
                castBillInfor user = new castBillInfor();
                user.HoTen = getUserOnMock.LastName + " " + getUserOnMock.FirstName;
                return View(user);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult InformationForBill(castBillInfor paymentInfor)
        {
            StaticVariable.HoTen = paymentInfor.HoTen;
            StaticVariable.Phone = paymentInfor.Phone;
            StaticVariable.City = paymentInfor.City;
            StaticVariable.District = paymentInfor.District;
            StaticVariable.State = paymentInfor.State;
            StaticVariable.Address = paymentInfor.Address;
            return RedirectToAction("checkout");
        }

        [HttpGet]
        public ActionResult Checkout()
        {

            BookInformationModel orderBook = new BookeeDb().BookInformation.FirstOrDefault(book => book.BookID == StaticVariable.Book_ID);
            return View(orderBook);
        }

        
        public ActionResult Order()
        {
            using (var db = new BookeeDb())
            {
                int userID = Convert.ToInt32(Session["ID"].ToString());
                OrdersModel order = new OrdersModel();
                order.OrderID = Guid.NewGuid().ToString();
                order.OrderDate = DateTime.Now;
                order.OrderStatus = "process";
                order.CustomerID = db.Customers.FirstOrDefault(user => user.CustomerID == userID);
                order.BookID = db.BookInformation.FirstOrDefault(book => book.BookID == StaticVariable.Book_ID);
                order.TotalPrice = db.BookInformation.FirstOrDefault(book => book.BookID == StaticVariable.Book_ID).BookPrice;
                db.Orders.Add(entity: order);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Bookee");
        }

        [HttpGet]
        public ActionResult getCategoryItem()
        {
            return View(new BookeeDb().BookCategories.ToList());
        }

        public ActionResult getBookPagination(int page = 1, int size = 3)
        {
            IEnumerable<castBookModel> listbook = CustomerDAO.pagingnationList(page, size);
            return View(listbook);
        }

        [HttpPost]
        public ActionResult searchBook(string searchKey)
        {
            IEnumerable<castBookModel> resultBook = new BookeeDb().BookInformation.
                Where(book => book.BookName.Contains(searchKey)).
                Select(item =>
               new castBookModel
               {
                   BookID = item.BookID,
                   BookName = item.BookName,
                   BookCover = item.BookCoverImage,
                   BookAuthor = item.Bookauthor,
                   BookPrice = item.BookPrice
               }
                );
                return View(resultBook.ToList());
        }
    }
}