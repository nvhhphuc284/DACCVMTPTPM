using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VSG.Models;

namespace VSG.Areas.Admin.Controllers
{
    public class ShoesController : Controller
    {
        // GET: Admin/Home
        private VSGModel db = new VSGModel();
        // GET: Home
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var shoe_services = db.Shoe_Services.Include(s => s.Category);
            return View(shoe_services.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe_Service shoe_service = db.Shoe_Services.Find(id);
            if (shoe_service == null)
            {
                return HttpNotFound();
            }
            return View(shoe_service);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Price,Description,Image,CategoryId")] Shoe_Service shoe_service)
        {
            if (ModelState.IsValid)
            {
                db.Shoe_Services.Add(shoe_service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", shoe_service.CategoryId);
            return View(shoe_service);
        }

        // GET: Admin/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe_Service shoe_service = db.Shoe_Services.Find(id);
            if (shoe_service == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", shoe_service.CategoryId);
            return View(shoe_service);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Price,Description,Image,CategoryId")] Shoe_Service shoe_service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoe_service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", shoe_service.CategoryId);
            return View(shoe_service);
        }

        // GET: Admin/Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe_Service shoe_service = db.Shoe_Services.Find(id);
            if (shoe_service == null)
            {
                return HttpNotFound();
            }
            return View(shoe_service);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoe_Service shoe_service = db.Shoe_Services.Find(id);
            db.Shoe_Services.Remove(shoe_service);
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
        [Authorize]
        public ActionResult AddToCard(int id)
        {
            return Content("them moi thanh cong");
        }
    }
}
