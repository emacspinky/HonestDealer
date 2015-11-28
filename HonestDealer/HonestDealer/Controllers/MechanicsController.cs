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
    public class MechanicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mechanics
        public ActionResult Index()
        {
            return View(db.Mechanics.ToList());
        }

        // GET: Mechanics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // GET: Mechanics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mechanics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Rating,Phone_number,Salary")] Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                db.Mechanics.Add(mechanic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mechanic);
        }

        // GET: Mechanics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Mechanics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Rating,Phone_number,Salary")] Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mechanic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mechanic);
        }

        // GET: Mechanics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic mechanic = db.Mechanics.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mechanic mechanic = db.Mechanics.Find(id);
            db.Mechanics.Remove(mechanic);
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
