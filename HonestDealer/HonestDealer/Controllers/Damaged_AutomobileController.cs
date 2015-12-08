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
    public class Damaged_AutomobileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Damaged_Automobile
        public ActionResult Index()
        {
            var damaged_Automobile = db.Damaged_Automobile.Include(d => d.Automobile);
            return View(damaged_Automobile.ToList());
        }

        // GET: Damaged_Automobile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damaged_Automobile damaged_Automobile = db.Damaged_Automobile.Find(id);
            if (damaged_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(damaged_Automobile);
        }

        // GET: Damaged_Automobile/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Vin");
            return View();
        }

        // POST: Damaged_Automobile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Part_name,Location")] Damaged_Automobile damaged_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.Damaged_Automobile.Add(damaged_Automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", damaged_Automobile.Vin);
            return View(damaged_Automobile);
        }

        // GET: Damaged_Automobile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damaged_Automobile damaged_Automobile = db.Damaged_Automobile.Find(id);
            if (damaged_Automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", damaged_Automobile.Vin);
            return View(damaged_Automobile);
        }

        // POST: Damaged_Automobile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Part_name,Location")] Damaged_Automobile damaged_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(damaged_Automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", damaged_Automobile.Vin);
            return View(damaged_Automobile);
        }

        // GET: Damaged_Automobile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Damaged_Automobile damaged_Automobile = db.Damaged_Automobile.Find(id);
            if (damaged_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(damaged_Automobile);
        }

        // POST: Damaged_Automobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Damaged_Automobile damaged_Automobile = db.Damaged_Automobile.Find(id);
            db.Damaged_Automobile.Remove(damaged_Automobile);
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
