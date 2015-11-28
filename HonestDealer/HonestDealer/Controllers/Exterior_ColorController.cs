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
    public class Exterior_ColorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exterior_Color
        public ActionResult Index()
        {
            var exterior_Color = db.Exterior_Color.Include(e => e.Automobile);
            return View(exterior_Color.ToList());
        }

        // GET: Exterior_Color/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior_Color exterior_Color = db.Exterior_Color.Find(id);
            if (exterior_Color == null)
            {
                return HttpNotFound();
            }
            return View(exterior_Color);
        }

        // GET: Exterior_Color/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            return View();
        }

        // POST: Exterior_Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Color")] Exterior_Color exterior_Color)
        {
            if (ModelState.IsValid)
            {
                db.Exterior_Color.Add(exterior_Color);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", exterior_Color.Vin);
            return View(exterior_Color);
        }

        // GET: Exterior_Color/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior_Color exterior_Color = db.Exterior_Color.Find(id);
            if (exterior_Color == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", exterior_Color.Vin);
            return View(exterior_Color);
        }

        // POST: Exterior_Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Color")] Exterior_Color exterior_Color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exterior_Color).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", exterior_Color.Vin);
            return View(exterior_Color);
        }

        // GET: Exterior_Color/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior_Color exterior_Color = db.Exterior_Color.Find(id);
            if (exterior_Color == null)
            {
                return HttpNotFound();
            }
            return View(exterior_Color);
        }

        // POST: Exterior_Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exterior_Color exterior_Color = db.Exterior_Color.Find(id);
            db.Exterior_Color.Remove(exterior_Color);
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
