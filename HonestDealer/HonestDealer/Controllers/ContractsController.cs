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
    public class ContractsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Dealership).Include(c => c.Mechanic);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name");
            ViewBag.Mech_name = new SelectList(db.Mechanics, "Name", "Phone_number");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mech_name,Dealer_id")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contracts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", contracts.Dealer_id);
            ViewBag.Mech_name = new SelectList(db.Mechanics, "Name", "Phone_number", contracts.Mech_name);
            return View(contracts);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", contracts.Dealer_id);
            ViewBag.Mech_name = new SelectList(db.Mechanics, "Name", "Phone_number", contracts.Mech_name);
            return View(contracts);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mech_name,Dealer_id")] Contracts contracts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contracts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", contracts.Dealer_id);
            ViewBag.Mech_name = new SelectList(db.Mechanics, "Name", "Phone_number", contracts.Mech_name);
            return View(contracts);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contracts contracts = db.Contracts.Find(id);
            if (contracts == null)
            {
                return HttpNotFound();
            }
            return View(contracts);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Contracts contracts = db.Contracts.Find(id);
            db.Contracts.Remove(contracts);
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
