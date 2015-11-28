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
    public class Dealership_PhoneController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dealership_Phone
        public ActionResult Index()
        {
            var dealership_Phone = db.Dealership_Phone.Include(d => d.Dealership);
            return View(dealership_Phone.ToList());
        }

        // GET: Dealership_Phone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership_Phone dealership_Phone = db.Dealership_Phone.Find(id);
            if (dealership_Phone == null)
            {
                return HttpNotFound();
            }
            return View(dealership_Phone);
        }

        // GET: Dealership_Phone/Create
        public ActionResult Create()
        {
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name");
            return View();
        }

        // POST: Dealership_Phone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dealer_id,Phone_number")] Dealership_Phone dealership_Phone)
        {
            if (ModelState.IsValid)
            {
                db.Dealership_Phone.Add(dealership_Phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealership_Phone.Dealer_id);
            return View(dealership_Phone);
        }

        // GET: Dealership_Phone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership_Phone dealership_Phone = db.Dealership_Phone.Find(id);
            if (dealership_Phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealership_Phone.Dealer_id);
            return View(dealership_Phone);
        }

        // POST: Dealership_Phone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dealer_id,Phone_number")] Dealership_Phone dealership_Phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealership_Phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealership_Phone.Dealer_id);
            return View(dealership_Phone);
        }

        // GET: Dealership_Phone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership_Phone dealership_Phone = db.Dealership_Phone.Find(id);
            if (dealership_Phone == null)
            {
                return HttpNotFound();
            }
            return View(dealership_Phone);
        }

        // POST: Dealership_Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dealership_Phone dealership_Phone = db.Dealership_Phone.Find(id);
            db.Dealership_Phone.Remove(dealership_Phone);
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
