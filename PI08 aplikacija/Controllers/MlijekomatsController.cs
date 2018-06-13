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
    public class MlijekomatsController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Mlijekomats
        public ActionResult Index()
        {
            var mlijekomats = db.Mlijekomats.Include(m => m.Farma);
            return View(mlijekomats.ToList());
        }

        // GET: Mlijekomats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mlijekomat mlijekomat = db.Mlijekomats.Find(id);
            if (mlijekomat == null)
            {
                return HttpNotFound();
            }
            return View(mlijekomat);
        }

        // GET: Mlijekomats/Create
        public ActionResult Create()
        {
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1");
            return View();
        }

        // POST: Mlijekomats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Mlijekomat,Lokacija,Punjenje,Pražnjenje,Troškovi_održavanja,Zarada,Kapacitet,ID_Farma")] Mlijekomat mlijekomat)
        {
            if (ModelState.IsValid)
            {
                db.Mlijekomats.Add(mlijekomat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", mlijekomat.ID_Farma);
            return View(mlijekomat);
        }

        // GET: Mlijekomats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mlijekomat mlijekomat = db.Mlijekomats.Find(id);
            if (mlijekomat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", mlijekomat.ID_Farma);
            return View(mlijekomat);
        }

        // POST: Mlijekomats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Mlijekomat,Lokacija,Punjenje,Pražnjenje,Troškovi_održavanja,Zarada,Kapacitet,ID_Farma")] Mlijekomat mlijekomat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mlijekomat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Farma = new SelectList(db.Farmas, "ID_Farma", "Farma1", mlijekomat.ID_Farma);
            return View(mlijekomat);
        }

        // GET: Mlijekomats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mlijekomat mlijekomat = db.Mlijekomats.Find(id);
            if (mlijekomat == null)
            {
                return HttpNotFound();
            }
            return View(mlijekomat);
        }

        // POST: Mlijekomats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mlijekomat mlijekomat = db.Mlijekomats.Find(id);
            db.Mlijekomats.Remove(mlijekomat);
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
