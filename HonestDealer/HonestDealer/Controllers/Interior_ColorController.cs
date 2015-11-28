using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HonestDealer.Models;

namespace HonestDealer.Controllers
{
    public class Interior_ColorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interior_Color
        public ActionResult Index()
        {
            var interior_Color = db.Interior_Color.Include(i => i.Automobile);
            return View(interior_Color.ToList());
        }

        // GET: Interior_Color/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior_Color interior_Color = db.Interior_Color.Find(id);
            if (interior_Color == null)
            {
                return HttpNotFound();
            }
            return View(interior_Color);
        }

        // GET: Interior_Color/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            return View();
        }

        // POST: Interior_Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Color")] Interior_Color interior_Color)
        {
            if (ModelState.IsValid)
            {
                db.Interior_Color.Add(interior_Color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", interior_Color.Vin);
            return View(interior_Color);
        }

        // GET: Interior_Color/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior_Color interior_Color = db.Interior_Color.Find(id);
            if (interior_Color == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", interior_Color.Vin);
            return View(interior_Color);
        }

        // POST: Interior_Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Color")] Interior_Color interior_Color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interior_Color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", interior_Color.Vin);
            return View(interior_Color);
        }

        // GET: Interior_Color/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior_Color interior_Color = db.Interior_Color.Find(id);
            if (interior_Color == null)
            {
                return HttpNotFound();
            }
            return View(interior_Color);
        }

        // POST: Interior_Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Interior_Color interior_Color = db.Interior_Color.Find(id);
            db.Interior_Color.Remove(interior_Color);
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
