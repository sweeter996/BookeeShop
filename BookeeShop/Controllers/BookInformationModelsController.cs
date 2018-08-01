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
    public class BookInformationModelsController : Controller
    {
        private BookeeDb db = new BookeeDb();

        // GET: BookInformationModels
        public ActionResult Index()
        {
            return View(db.BookInformation.ToList());
        }

        // GET: BookInformationModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInformationModel bookInformationModel = db.BookInformation.Find(id);
            if (bookInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInformationModel);
        }

        // GET: BookInformationModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookInformationModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,BookName,BookIntroduction,BookPrice,BookCoverImage,Bookauthor,BookPublisher,YearReleased,BookForm,BookLanguage,BookAddedDate,BookModifiedDate")] BookInformationModel bookInformationModel)
        {
            if (ModelState.IsValid)
            {
                db.BookInformation.Add(bookInformationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookInformationModel);
        }

        // GET: BookInformationModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInformationModel bookInformationModel = db.BookInformation.Find(id);
            if (bookInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInformationModel);
        }

        // POST: BookInformationModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookName,BookIntroduction,BookPrice,BookCoverImage,Bookauthor,BookPublisher,YearReleased,BookForm,BookLanguage,BookAddedDate,BookModifiedDate")] BookInformationModel bookInformationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookInformationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookInformationModel);
        }

        // GET: BookInformationModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookInformationModel bookInformationModel = db.BookInformation.Find(id);
            if (bookInformationModel == null)
            {
                return HttpNotFound();
            }
            return View(bookInformationModel);
        }

        // POST: BookInformationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BookInformationModel bookInformationModel = db.BookInformation.Find(id);
            db.BookInformation.Remove(bookInformationModel);
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