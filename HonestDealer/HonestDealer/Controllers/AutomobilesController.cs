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
    public class AutomobilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Automobiles
        public ActionResult Index(string searchString)
        {
            var automobiles = from a in db.Automobiles
                              select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                automobiles = automobiles.Where(a => a.Make.ToUpper().Contains(searchString.ToUpper())
                || a.Vin.ToUpper().Contains(searchString.ToUpper())
                || a.Model.ToUpper().Contains(searchString.ToUpper())
                || a.Dealership.Name.ToUpper().Contains(searchString.ToUpper())
                || a.Year.ToString() == searchString);
            }

            automobiles = automobiles.Include(a => a.Dealership);
            
            return View(automobiles);
        }

        // GET: Automobiles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // GET: Automobiles/Create
        public ActionResult Create()
        {
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name");
            return View();
        }

        // POST: Automobiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Dealer_id,Year,Transmission,Mpg,Make,Model,Body_type,Price,Damaged_flag")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Automobiles.Add(automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", automobile.Dealer_id);
            return View(automobile);
        }

        // GET: Automobiles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", automobile.Dealer_id);
            return View(automobile);
        }

        // POST: Automobiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Dealer_id,Year,Transmission,Mpg,Make,Model,Body_type,Price,Damaged_flag")] Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", automobile.Dealer_id);
            return View(automobile);
        }

        // GET: Automobiles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobile automobile = db.Automobiles.Find(id);
            if (automobile == null)
            {
                return HttpNotFound();
            }
            return View(automobile);
        }

        // POST: Automobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Automobile automobile = db.Automobiles.Find(id);
            db.Automobiles.Remove(automobile);
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
