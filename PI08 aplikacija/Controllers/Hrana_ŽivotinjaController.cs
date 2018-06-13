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
    public class Hrana_ŽivotinjaController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Hrana_Životinja
        public ActionResult Index()
        {
            var hrana_Životinja = db.Hrana_Životinja.Include(h => h.Hrana).Include(h => h.Životinja);
            return View(hrana_Životinja.ToList());
        }

        // GET: Hrana_Životinja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana_Životinja hrana_Životinja = db.Hrana_Životinja.Find(id);
            if (hrana_Životinja == null)
            {
                return HttpNotFound();
            }
            return View(hrana_Životinja);
        }

        // GET: Hrana_Životinja/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hrana = new SelectList(db.Hranas, "ID_Hrana", "Vrsta");
            ViewBag.ID_Životinja = new SelectList(db.Životinja, "ID_Životinje", "Ime");
            return View();
        }

        // POST: Hrana_Životinja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Životinja,ID_Hrana")] Hrana_Životinja hrana_Životinja)
        {
            if (ModelState.IsValid)
            {
                db.Hrana_Životinja.Add(hrana_Životinja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hrana = new SelectList(db.Hranas, "ID_Hrana", "Vrsta", hrana_Životinja.ID_Hrana);
            ViewBag.ID_Životinja = new SelectList(db.Životinja, "ID_Životinje", "Ime", hrana_Životinja.ID_Životinja);
            return View(hrana_Životinja);
        }

        // GET: Hrana_Životinja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana_Životinja hrana_Životinja = db.Hrana_Životinja.Find(id);
            if (hrana_Životinja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hrana = new SelectList(db.Hranas, "ID_Hrana", "Vrsta", hrana_Životinja.ID_Hrana);
            ViewBag.ID_Životinja = new SelectList(db.Životinja, "ID_Životinje", "Ime", hrana_Životinja.ID_Životinja);
            return View(hrana_Životinja);
        }

        // POST: Hrana_Životinja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Životinja,ID_Hrana")] Hrana_Životinja hrana_Životinja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hrana_Životinja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hrana = new SelectList(db.Hranas, "ID_Hrana", "Vrsta", hrana_Životinja.ID_Hrana);
            ViewBag.ID_Životinja = new SelectList(db.Životinja, "ID_Životinje", "Ime", hrana_Životinja.ID_Životinja);
            return View(hrana_Životinja);
        }

        // GET: Hrana_Životinja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana_Životinja hrana_Životinja = db.Hrana_Životinja.Find(id);
            if (hrana_Životinja == null)
            {
                return HttpNotFound();
            }
            return View(hrana_Životinja);
        }

        // POST: Hrana_Životinja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hrana_Životinja hrana_Životinja = db.Hrana_Životinja.Find(id);
            db.Hrana_Životinja.Remove(hrana_Životinja);
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
