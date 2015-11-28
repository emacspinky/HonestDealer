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
    public class New_AutomobileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: New_Automobile
        public ActionResult Index()
        {
            var new_Automobile = db.New_Automobile.Include(n => n.Automobile);
            return View(new_Automobile.ToList());
        }

        // GET: New_Automobile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Automobile new_Automobile = db.New_Automobile.Find(id);
            if (new_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(new_Automobile);
        }

        // GET: New_Automobile/Create
        public ActionResult Create()
        {
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission");
            return View();
        }

        // POST: New_Automobile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vin,Manuf_warranty")] New_Automobile new_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.New_Automobile.Add(new_Automobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Automobile.Vin);
            return View(new_Automobile);
        }

        // GET: New_Automobile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Automobile new_Automobile = db.New_Automobile.Find(id);
            if (new_Automobile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Automobile.Vin);
            return View(new_Automobile);
        }

        // POST: New_Automobile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vin,Manuf_warranty")] New_Automobile new_Automobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new_Automobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vin = new SelectList(db.Automobiles, "Vin", "Transmission", new_Automobile.Vin);
            return View(new_Automobile);
        }

        // GET: New_Automobile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Automobile new_Automobile = db.New_Automobile.Find(id);
            if (new_Automobile == null)
            {
                return HttpNotFound();
            }
            return View(new_Automobile);
        }

        // POST: New_Automobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            New_Automobile new_Automobile = db.New_Automobile.Find(id);
            db.New_Automobile.Remove(new_Automobile);
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
