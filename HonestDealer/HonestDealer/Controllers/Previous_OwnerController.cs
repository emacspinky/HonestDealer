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
    public class Previous_OwnerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Previous_Owner
        public ActionResult Index()
        {
            var previous_Owner = db.Previous_Owner.Include(p => p.Automobile);
            return View(previous_Owner.ToList());
        }

        // GET: Previous_Owner/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previous_Owner previous_Owner = db.Previous_Owner.Find(id);
            if (previous_Owner == null)
            {
                return HttpNotFound();
            }
            return View(previous_Owner);
        }

        // GET: Previous_Owner/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            return View();
        }

        // POST: Previous_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Phone_number,Name")] Previous_Owner previous_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Previous_Owner.Add(previous_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", previous_Owner.Vin);
            return View(previous_Owner);
        }

        // GET: Previous_Owner/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previous_Owner previous_Owner = db.Previous_Owner.Find(id);
            if (previous_Owner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", previous_Owner.Vin);
            return View(previous_Owner);
        }

        // POST: Previous_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Phone_number,Name")] Previous_Owner previous_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previous_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", previous_Owner.Vin);
            return View(previous_Owner);
        }

        // GET: Previous_Owner/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Previous_Owner previous_Owner = db.Previous_Owner.Find(id);
            if (previous_Owner == null)
            {
                return HttpNotFound();
            }
            return View(previous_Owner);
        }

        // POST: Previous_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Previous_Owner previous_Owner = db.Previous_Owner.Find(id);
            db.Previous_Owner.Remove(previous_Owner);
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
