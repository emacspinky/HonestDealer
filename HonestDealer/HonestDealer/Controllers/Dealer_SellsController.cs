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
    public class Dealer_SellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dealer_Sells
        public ActionResult Index()
        {
            var dealer_Sells = db.Dealer_Sells.Include(d => d.Automobile).Include(d => d.Dealership);
            return View(dealer_Sells.ToList());
        }

        // GET: Dealer_Sells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer_Sells dealer_Sells = db.Dealer_Sells.Find(id);
            if (dealer_Sells == null)
            {
                return HttpNotFound();
            }
            return View(dealer_Sells);
        }

        // GET: Dealer_Sells/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name");
            return View();
        }

        // POST: Dealer_Sells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dealer_id,Vin")] Dealer_Sells dealer_Sells)
        {
            if (ModelState.IsValid)
            {
                db.Dealer_Sells.Add(dealer_Sells);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", dealer_Sells.Vin);
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealer_Sells.Dealer_id);
            return View(dealer_Sells);
        }

        // GET: Dealer_Sells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer_Sells dealer_Sells = db.Dealer_Sells.Find(id);
            if (dealer_Sells == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", dealer_Sells.Vin);
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealer_Sells.Dealer_id);
            return View(dealer_Sells);
        }

        // POST: Dealer_Sells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dealer_id,Vin")] Dealer_Sells dealer_Sells)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealer_Sells).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", dealer_Sells.Vin);
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", dealer_Sells.Dealer_id);
            return View(dealer_Sells);
        }

        // GET: Dealer_Sells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer_Sells dealer_Sells = db.Dealer_Sells.Find(id);
            if (dealer_Sells == null)
            {
                return HttpNotFound();
            }
            return View(dealer_Sells);
        }

        // POST: Dealer_Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dealer_Sells dealer_Sells = db.Dealer_Sells.Find(id);
            db.Dealer_Sells.Remove(dealer_Sells);
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
