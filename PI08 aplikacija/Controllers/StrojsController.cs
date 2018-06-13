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
    public class StrojsController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Strojs
        public ActionResult Index()
        {
            var strojs = db.Strojs.Include(s => s.Farma).Include(s => s.Kupnja);
            return View(strojs.ToList());
        }

        // GET: Strojs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stroj stroj = db.Strojs.Find(id);
            if (stroj == null)
            {
                return HttpNotFound();
            }
            return View(stroj);
        }

        // GET: Strojs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1");
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda");
            return View();
        }

        // POST: Strojs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Stroj,Ime,Vlasnik,Nabavna_vrijednost,Trenutna_vrijednost,Dodatna_oprema,Korištenje_od,Korištenje_do,Lokacija_korištenja,Zarada_od_rada_korištenja,ID_Farma,ID_Kupnja")] Stroj stroj)
        {
            if (ModelState.IsValid)
            {
                db.Strojs.Add(stroj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", stroj.ID_Farma);
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", stroj.ID_Kupnja);
            return View(stroj);
        }

        // GET: Strojs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stroj stroj = db.Strojs.Find(id);
            if (stroj == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", stroj.ID_Farma);
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", stroj.ID_Kupnja);
            return View(stroj);
        }

        // POST: Strojs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Stroj,Ime,Vlasnik,Nabavna_vrijednost,Trenutna_vrijednost,Dodatna_oprema,Korištenje_od,Korištenje_do,Lokacija_korištenja,Zarada_od_rada_korištenja,ID_Farma,ID_Kupnja")] Stroj stroj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stroj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", stroj.ID_Farma);
            ViewBag.ID_Kupnja = new SelectList(db.Kupnjas, "ID_Kupnja", "Vrsta_proizvoda", stroj.ID_Kupnja);
            return View(stroj);
        }

        // GET: Strojs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stroj stroj = db.Strojs.Find(id);
            if (stroj == null)
            {
                return HttpNotFound();
            }
            return View(stroj);
        }

        // POST: Strojs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stroj stroj = db.Strojs.Find(id);
            db.Strojs.Remove(stroj);
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
