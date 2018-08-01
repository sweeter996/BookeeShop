using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookeeShop.Models;

namespace BookeeShop.Controllers
{
    public class BookCategoriesModelsController : Controller
    {
        private BookeeDb db = new BookeeDb();

        // GET: BookCategoriesModels
        public ActionResult Index()
        {
            return View(db.BookCategories.ToList());
        }

        // GET: BookCategoriesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategoriesModel bookCategoriesModel = db.BookCategories.Find(id);
            if (bookCategoriesModel == null)
            {
                return HttpNotFound();
            }
            return View(bookCategoriesModel);
        }

        // GET: BookCategoriesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookCategoriesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] BookCategoriesModel bookCategoriesModel)
        {
            if (ModelState.IsValid)
            {
                db.BookCategories.Add(bookCategoriesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookCategoriesModel);
        }

        // GET: BookCategoriesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategoriesModel bookCategoriesModel = db.BookCategories.Find(id);
            if (bookCategoriesModel == null)
            {
                return HttpNotFound();
            }
            return View(bookCategoriesModel);
        }

        // POST: BookCategoriesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] BookCategoriesModel bookCategoriesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCategoriesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCategoriesModel);
        }

        // GET: BookCategoriesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCategoriesModel bookCategoriesModel = db.BookCategories.Find(id);
            if (bookCategoriesModel == null)
            {
                return HttpNotFound();
            }
            return View(bookCategoriesModel);
        }

        // POST: BookCategoriesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCategoriesModel bookCategoriesModel = db.BookCategories.Find(id);
            db.BookCategories.Remove(bookCategoriesModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
