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
    public class RadnjasController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Radnjas
        public ActionResult Index()
        {
            var radnjas = db.Radnjas.Include(r => r.Zemljište);
            return View(radnjas.ToList());
        }

        // GET: Radnjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnja radnja = db.Radnjas.Find(id);
            if (radnja == null)
            {
                return HttpNotFound();
            }
            return View(radnja);
        }

        // GET: Radnjas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv");
            return View();
        }

        // POST: Radnjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_radnje,naziv,trosak,dobit,pocetak_radnje,kraj_radnje,ID_Zemljište")] Radnja radnja)
        {
            if (ModelState.IsValid)
            {
                db.Radnjas.Add(radnja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", radnja.ID_Zemljište);
            return View(radnja);
        }

        // GET: Radnjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnja radnja = db.Radnjas.Find(id);
            if (radnja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", radnja.ID_Zemljište);
            return View(radnja);
        }

        // POST: Radnjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_radnje,naziv,trosak,dobit,pocetak_radnje,kraj_radnje,ID_Zemljište")] Radnja radnja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Zemljište = new SelectList(db.Zemljište, "ID_Zemljište", "Naziv", radnja.ID_Zemljište);
            return View(radnja);
        }

        // GET: Radnjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radnja radnja = db.Radnjas.Find(id);
            if (radnja == null)
            {
                return HttpNotFound();
            }
            return View(radnja);
        }

        // POST: Radnjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radnja radnja = db.Radnjas.Find(id);
            db.Radnjas.Remove(radnja);
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
