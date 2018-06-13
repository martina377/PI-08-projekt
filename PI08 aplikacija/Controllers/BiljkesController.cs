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
    public class BiljkesController : Controller
    {
        private PI08Model db = new PI08Model();

     


        // GET: Biljkes
        public ActionResult Index()
                {
                    var biljkes = db.Biljkes.Include(b => b.Radnja).Include(b => b.Zemljište);
                    return View(biljkes.ToList());
                }

        // GET: Biljkes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biljke biljke = db.Biljkes.Find(id);
            if (biljke == null)
            {
                return HttpNotFound();
            }
            return View(biljke);
        }

        // GET: Biljkes/Create
        public ActionResult Create()
        {
            ViewBag.id_Radnja = new SelectList(db.Radnjas, "id_radnje", "naziv");
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv");
            return View();
        }

        // POST: Biljkes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Biljke,Naziv,Vrsta,Lokacija,Sadnja,Količina_zasađene,Berba,Količina_dobivenih_plodova,ID_Zemljište,id_Radnja")] Biljke biljke)
        {
            if (ModelState.IsValid)
            {
                db.Biljkes.Add(biljke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Radnja = new SelectList(db.Radnjas, "id_radnje", "naziv", biljke.id_Radnja);
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", biljke.ID_Zemljište);
            return View(biljke);
        }

        // GET: Biljkes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biljke biljke = db.Biljkes.Find(id);
            if (biljke == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Radnja = new SelectList(db.Radnjas, "id_radnje", "naziv", biljke.id_Radnja);
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", biljke.ID_Zemljište);
            return View(biljke);
        }

        // POST: Biljkes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Biljke,Naziv,Vrsta,Lokacija,Sadnja,Količina_zasađene,Berba,Količina_dobivenih_plodova,ID_Zemljište,id_Radnja")] Biljke biljke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biljke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Radnja = new SelectList(db.Radnjas, "id_radnje", "naziv", biljke.id_Radnja);
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", biljke.ID_Zemljište);
            return View(biljke);
        }

        // GET: Biljkes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biljke biljke = db.Biljkes.Find(id);
            if (biljke == null)
            {
                return HttpNotFound();
            }
            return View(biljke);
        }

        // POST: Biljkes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biljke biljke = db.Biljkes.Find(id);
            db.Biljkes.Remove(biljke);
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
