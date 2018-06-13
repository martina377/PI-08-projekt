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
    public class HranasController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Hranas
        public ActionResult Index()
        {
            var hranas = db.Hranas.Include(h => h.Kupnja);
            return View(hranas.ToList());
        }

        // GET: Hranas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana hrana = db.Hranas.Find(id);
            if (hrana == null)
            {
                return HttpNotFound();
            }
            return View(hrana);
        }

        // GET: Hranas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda");
            return View();
        }

        // POST: Hranas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Hrana,Vrsta,Količina,Troškovi,Vrijeme_kupovine,ID_Kupnja")] Hrana hrana)
        {
            if (ModelState.IsValid)
            {
                db.Hranas.Add(hrana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", hrana.ID_Kupnja);
            return View(hrana);
        }

        // GET: Hranas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana hrana = db.Hranas.Find(id);
            if (hrana == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", hrana.ID_Kupnja);
            return View(hrana);
        }

        // POST: Hranas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Hrana,Vrsta,Količina,Troškovi,Vrijeme_kupovine,ID_Kupnja")] Hrana hrana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hrana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", hrana.ID_Kupnja);
            return View(hrana);
        }

        // GET: Hranas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hrana hrana = db.Hranas.Find(id);
            if (hrana == null)
            {
                return HttpNotFound();
            }
            return View(hrana);
        }

        // POST: Hranas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hrana hrana = db.Hranas.Find(id);
            db.Hranas.Remove(hrana);
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
