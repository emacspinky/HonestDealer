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
    public class EmploysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employs
        public ActionResult Index()
        {
            var employs = db.Employs.Include(e => e.Dealership).Include(e => e.Salesman);
            return View(employs.ToList());
        }

        // GET: Employs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employs employs = db.Employs.Find(id);
            if (employs == null)
            {
                return HttpNotFound();
            }
            return View(employs);
        }

        // GET: Employs/Create
        public ActionResult Create()
        {
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name");
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name");
            return View();
        }

        // POST: Employs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dealer_id,Employee_id")] Employs employs)
        {
            if (ModelState.IsValid)
            {
                db.Employs.Add(employs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", employs.Dealer_id);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", employs.Employee_id);
            return View(employs);
        }

        // GET: Employs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employs employs = db.Employs.Find(id);
            if (employs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", employs.Dealer_id);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", employs.Employee_id);
            return View(employs);
        }

        // POST: Employs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dealer_id,Employee_id")] Employs employs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dealer_id = new SelectList(db.Dealerships, "Dealer_id", "Name", employs.Dealer_id);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", employs.Employee_id);
            return View(employs);
        }

        // GET: Employs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employs employs = db.Employs.Find(id);
            if (employs == null)
            {
                return HttpNotFound();
            }
            return View(employs);
        }

        // POST: Employs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employs employs = db.Employs.Find(id);
            db.Employs.Remove(employs);
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
