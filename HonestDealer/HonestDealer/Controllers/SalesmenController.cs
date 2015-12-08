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
    public class SalesmenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Salesmen
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SalarySortParm = sortOrder == "Salary" ? "salary_desc" : "Salary";
            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewBag.ApptsSortParm = sortOrder == "Available_appts" ? "appts_desc" : "Available_appts";    //IQueryable<Dealership>
            var salesmen = from s in db.Salesmen
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                salesmen = salesmen.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    salesmen = salesmen.OrderByDescending(s => s.Name);
                    break;
                case "salary_desc":
                    salesmen = salesmen.OrderByDescending(s => s.Salary);
                    break;
                case "Salary":
                    salesmen = salesmen.OrderBy(s => s.Salary);
                    break;
                case "appts_desc":
                    salesmen = salesmen.OrderByDescending(s => s.Available_appts);
                    break;
                case "Available_appts":
                    salesmen = salesmen.OrderBy(s => s.Available_appts);
                    break;
                case "rating_desc":
                    salesmen = salesmen.OrderByDescending(s => s.Rating);
                    break;
                case "Rating":
                    salesmen = salesmen.OrderBy(s => s.Rating);
                    break;
                default:
                    salesmen = salesmen.OrderBy(s => s.Name);
                    break;
            }
            return View(salesmen.ToList());
        }

        // GET: Salesmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // GET: Salesmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salesmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_id,Name,Rating,Salary,Phone_number,Available_appts,Used_flag,New_flag")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.Salesmen.Add(salesman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesman);
        }

        // GET: Salesmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // POST: Salesmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_id,Name,Rating,Salary,Phone_number,Available_appts,Used_flag,New_flag")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesman);
        }

        // GET: Salesmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesman salesman = db.Salesmen.Find(id);
            db.Salesmen.Remove(salesman);
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
