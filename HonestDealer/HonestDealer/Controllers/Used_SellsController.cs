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
    public class Used_SellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Used_Sells
        public ActionResult Index()
        {
            var used_Sells = db.Used_Sells.Include(u => u.Automobile).Include(u => u.Salesman);
            return View(used_Sells.ToList());
        }

        // GET: Used_Sells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Sells used_Sells = db.Used_Sells.Find(id);
            if (used_Sells == null)
            {
                return HttpNotFound();
            }
            return View(used_Sells);
        }

        // GET: Used_Sells/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name");
            return View();
        }

        // POST: Used_Sells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_id,Vin")] Used_Sells used_Sells)
        {
            if (ModelState.IsValid)
            {
                db.Used_Sells.Add(used_Sells);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", used_Sells.Employee_id);
            return View(used_Sells);
        }

        // GET: Used_Sells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Sells used_Sells = db.Used_Sells.Find(id);
            if (used_Sells == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", used_Sells.Employee_id);
            return View(used_Sells);
        }

        // POST: Used_Sells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_id,Vin")] Used_Sells used_Sells)
        {
            if (ModelState.IsValid)
            {
                db.Entry(used_Sells).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", used_Sells.Vin);
            ViewBag.Employee_id = new SelectList(db.Salesmen, "Employee_id", "Name", used_Sells.Employee_id);
            return View(used_Sells);
        }

        // GET: Used_Sells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Used_Sells used_Sells = db.Used_Sells.Find(id);
            if (used_Sells == null)
            {
                return HttpNotFound();
            }
            return View(used_Sells);
        }

        // POST: Used_Sells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Used_Sells used_Sells = db.Used_Sells.Find(id);
            db.Used_Sells.Remove(used_Sells);
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
