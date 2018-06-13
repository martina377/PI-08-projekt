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
    public class Prodaja_ŽivotinjeController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Prodaja_Životinje
        public ActionResult Index()
        {
            var prodaja_Životinje = db.Prodaja_Životinje.Include(p => p.Prodaja).Include(p => p.Životinja);
            return View(prodaja_Životinje.ToList());
        }

        // GET: Prodaja_Životinje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja_Životinje prodaja_Životinje = db.Prodaja_Životinje.Find(id);
            if (prodaja_Životinje == null)
            {
                return HttpNotFound();
            }
            return View(prodaja_Životinje);
        }

        // GET: Prodaja_Životinje/Create
        public ActionResult Create()
        {
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija");
            ViewBag.ID_Životinje = new SelectList(db.Životinja, "ID_Životinje", "Ime");
            return View();
        }

        // POST: Prodaja_Životinje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Prodaja,ID_Životinje")] Prodaja_Životinje prodaja_Životinje)
        {
            if (ModelState.IsValid)
            {
                db.Prodaja_Životinje.Add(prodaja_Životinje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prodaja_Životinje.ID_Prodaja);
            ViewBag.ID_Životinje = new SelectList(db.Životinja, "ID_Životinje", "Ime", prodaja_Životinje.ID_Životinje);
            return View(prodaja_Životinje);
        }

        // GET: Prodaja_Životinje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja_Životinje prodaja_Životinje = db.Prodaja_Životinje.Find(id);
            if (prodaja_Životinje == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prodaja_Životinje.ID_Prodaja);
            ViewBag.ID_Životinje = new SelectList(db.Životinja, "ID_Životinje", "Ime", prodaja_Životinje.ID_Životinje);
            return View(prodaja_Životinje);
        }

        // POST: Prodaja_Životinje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Prodaja,ID_Životinje")] Prodaja_Životinje prodaja_Životinje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodaja_Životinje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prodaja_Životinje.ID_Prodaja);
            ViewBag.ID_Životinje = new SelectList(db.Životinja, "ID_Životinje", "Ime", prodaja_Životinje.ID_Životinje);
            return View(prodaja_Životinje);
        }

        // GET: Prodaja_Životinje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja_Životinje prodaja_Životinje = db.Prodaja_Životinje.Find(id);
            if (prodaja_Životinje == null)
            {
                return HttpNotFound();
            }
            return View(prodaja_Životinje);
        }

        // POST: Prodaja_Životinje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodaja_Životinje prodaja_Životinje = db.Prodaja_Životinje.Find(id);
            db.Prodaja_Životinje.Remove(prodaja_Životinje);
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
