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
    public class New_SellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: New_Sells
        public ActionResult Index()
        {
            var new_Sells = db.New_Sells.Include(n => n.Automobile).Include(n => n.Salesman);
            return View(new_Sells.ToList());
        }

        // GET: New_Sells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Sells new_Sells = db.New_Sells.Find(id);
            if (new_Sells == null)
            {
                return HttpNotFound();
            }
            return View(new_Sells);
        }

        // GET: New_Sells/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name");
            return View();
        }

        // POST: New_Sells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_id,Vin")] New_Sells new_Sells)
        {
            if (ModelState.IsValid)
            {
                db.New_Sells.Add(new_Sells);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", new_Sells.Employee_id);
            return View(new_Sells);
        }

        // GET: New_Sells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Sells new_Sells = db.New_Sells.Find(id);
            if (new_Sells == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", new_Sells.Employee_id);
            return View(new_Sells);
        }

        // POST: New_Sells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_id,Vin")] New_Sells new_Sells)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new_Sells).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", new_Sells.Employee_id);
            return View(new_Sells);
        }

        // GET: New_Sells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Sells new_Sells = db.New_Sells.Find(id);
            if (new_Sells == null)
            {
                return HttpNotFound();
            }
            return View(new_Sells);
        }

        // POST: New_Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New_Sells new_Sells = db.New_Sells.Find(id);
            db.New_Sells.Remove(new_Sells);
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
