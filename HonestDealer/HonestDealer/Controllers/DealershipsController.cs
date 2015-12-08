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
    public class DealershipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dealerships
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CarCountSortParm = sortOrder == "Car_count" ? "count_desc" : "Car_count";
            ViewBag.RatingSortParm = sortOrder == "Dealer_rating" ? "rating_desc" : "Dealer_rating";
            ViewBag.OpenTimeSortParm = sortOrder == "Open_time" ? "open_desc" : "Open_time";
            ViewBag.CloseTimeSortParm = sortOrder == "Close_time" ? "close_desc" : "Close_time";            //IQueryable<Dealership>
            var dealerships = from d in db.Dealerships
                              select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                dealerships = dealerships.Where(d => d.Name.ToUpper().Contains(searchString.ToUpper())
                || d.Username.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    dealerships = dealerships.OrderByDescending(d => d.Name);
                    break;
                case "Car_count":
                    dealerships = dealerships.OrderBy(d => d.Car_count);
                    break;
                case "count_desc":
                    dealerships = dealerships.OrderByDescending(d => d.Car_count);
                    break;
                case "rating_desc":
                    dealerships = dealerships.OrderByDescending(d => d.Dealer_rating);
                    break;
                case "open_desc":
                    dealerships = dealerships.OrderByDescending(d => d.Open_time);
                    break;
                case "close_desc":
                    dealerships = dealerships.OrderByDescending(d => d.Close_time);
                    break;
                default:
                    dealerships = dealerships.OrderBy(d => d.Name);
                    break;
            }
            return View(dealerships.ToList());
        }

        // GET: Dealerships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership dealership = db.Dealerships.Find(id);
            if (dealership == null)
            {
                return HttpNotFound();
            }
            return View(dealership);
        }

        // GET: Dealerships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Web_address,Makes_sold,Username,Password,Open_time,Close_time")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                db.Dealerships.Add(dealership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dealership);
        }

        // GET: Dealerships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership dealership = db.Dealerships.Find(id);
            if (dealership == null)
            {
                return HttpNotFound();
            }
            return View(dealership);
        }

        // POST: Dealerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dealer_id,Name,Web_address,Makes_sold,Dealer_rating,Car_count,Username,Password,Open_time,Close_time")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dealership);
        }

        // GET: Dealerships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealership dealership = db.Dealerships.Find(id);
            if (dealership == null)
            {
                return HttpNotFound();
            }
            return View(dealership);
        }

        // POST: Dealerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dealership dealership = db.Dealerships.Find(id);
            db.Dealerships.Remove(dealership);
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
