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
    public class Used_AutomobileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Used_Automobile
        public ActionResult Index()
        {
            var used_Automobile = db.Used_Automobile.Include(u => u.Automobile);
            return View(used_Automobile.ToList());
        }

        // GET: Used_Automobile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Automobile used_Automobile = db.Used_Automobile.Find(id);
            if (used_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(used_Automobile);
        }

        // GET: Used_Automobile/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Vin");
            return View();
        }

        // POST: Used_Automobile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Number_of_repairs,Dealer_warranty,Number_of_owners,Mileage")] Used_Automobile used_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.Used_Automobile.Add(used_Automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Automobile.Vin);
            return View(used_Automobile);
        }

        // GET: Used_Automobile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Automobile used_Automobile = db.Used_Automobile.Find(id);
            if (used_Automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Automobile.Vin);
            return View(used_Automobile);
        }

        // POST: Used_Automobile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Number_of_repairs,Dealer_warranty,Number_of_owners,Mileage")] Used_Automobile used_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(used_Automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Automobile.Vin);
            return View(used_Automobile);
        }

        // GET: Used_Automobile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Automobile used_Automobile = db.Used_Automobile.Find(id);
            if (used_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(used_Automobile);
        }

        // POST: Used_Automobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Used_Automobile used_Automobile = db.Used_Automobile.Find(id);
            db.Used_Automobile.Remove(used_Automobile);
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
