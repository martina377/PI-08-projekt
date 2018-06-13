using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI08_aplikacija.Models;

namespace PI08_aplikacija.Controllers
{
    public class ŽivotinjaController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Životinja
        public ActionResult Index()
        {
            return View(db.Životinja.ToList());
        }

        // GET: Životinja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Životinja životinja = db.Životinja.Find(id);
            if (životinja == null)
            {
                return HttpNotFound();
            }
            return View(životinja);
        }

        // GET: Životinja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Životinja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Životinje,Ime,Vrsta,Proizvodi,Označena")] Životinja životinja)
        {
            if (ModelState.IsValid)
            {
                db.Životinja.Add(životinja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(životinja);
        }

        // GET: Životinja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Životinja životinja = db.Životinja.Find(id);
            if (životinja == null)
            {
                return HttpNotFound();
            }
            return View(životinja);
        }

        // POST: Životinja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Životinje,Ime,Vrsta,Proizvodi,Označena")] Životinja životinja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(životinja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(životinja);
        }

        // GET: Životinja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Životinja životinja = db.Životinja.Find(id);
            if (životinja == null)
            {
                return HttpNotFound();
            }
            return View(životinja);
        }

        // POST: Životinja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Životinja životinja = db.Životinja.Find(id);
            db.Životinja.Remove(životinja);
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
