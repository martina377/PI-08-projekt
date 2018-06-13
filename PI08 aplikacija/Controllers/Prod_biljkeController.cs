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
    public class Prod_biljkeController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Prod_biljke
        public ActionResult Index()
        {
            var prod_biljke = db.Prod_biljke.Include(p => p.Biljke).Include(p => p.Biljke1).Include(p => p.Prodaja);
            return View(prod_biljke.ToList());
        }

        // GET: Prod_biljke/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prod_biljke prod_biljke = db.Prod_biljke.Find(id);
            if (prod_biljke == null)
            {
                return HttpNotFound();
            }
            return View(prod_biljke);
        }

        // GET: Prod_biljke/Create
        public ActionResult Create()
        {
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv");
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv");
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija");
            return View();
        }

        // POST: Prod_biljke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Biljke,ID_Prodaja")] Prod_biljke prod_biljke)
        {
            if (ModelState.IsValid)
            {
                db.Prod_biljke.Add(prod_biljke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prod_biljke.ID_Prodaja);
            return View(prod_biljke);
        }

        // GET: Prod_biljke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prod_biljke prod_biljke = db.Prod_biljke.Find(id);
            if (prod_biljke == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prod_biljke.ID_Prodaja);
            return View(prod_biljke);
        }

        // POST: Prod_biljke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Biljke,ID_Prodaja")] Prod_biljke prod_biljke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prod_biljke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Biljke = new SelectList(db.Biljkes, "ID_Biljke", "Naziv", prod_biljke.ID_Biljke);
            ViewBag.ID_Prodaja = new SelectList(db.Prodajas, "ID_Prodaja", "Lokacija", prod_biljke.ID_Prodaja);
            return View(prod_biljke);
        }

        // GET: Prod_biljke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prod_biljke prod_biljke = db.Prod_biljke.Find(id);
            if (prod_biljke == null)
            {
                return HttpNotFound();
            }
            return View(prod_biljke);
        }

        // POST: Prod_biljke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prod_biljke prod_biljke = db.Prod_biljke.Find(id);
            db.Prod_biljke.Remove(prod_biljke);
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
