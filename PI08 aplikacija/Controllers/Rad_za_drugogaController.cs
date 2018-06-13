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
    public class Rad_za_drugogaController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Rad_za_drugoga
        public ActionResult Index()
        {
            var rad_za_drugogas = db.Rad_za_drugogas.Include(r => r.Stroj);
            return View(rad_za_drugogas.ToList());
        }

        // GET: Rad_za_drugoga/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rad_za_drugoga rad_za_drugoga = db.Rad_za_drugogas.Find(id);
            if (rad_za_drugoga == null)
            {
                return HttpNotFound();
            }
            return View(rad_za_drugoga);
        }

        // GET: Rad_za_drugoga/Create
        public ActionResult Create()
        {
            ViewBag.id_stroj = new SelectList(db.Strojs, "ID_Stroj", "Ime");
            return View();
        }

        // POST: Rad_za_drugoga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,datum_vrijeme,zarada,trajanje,id_stroj")] Rad_za_drugoga rad_za_drugoga)
        {
            if (ModelState.IsValid)
            {
                db.Rad_za_drugogas.Add(rad_za_drugoga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_stroj = new SelectList(db.Strojs, "ID_Stroj", "Ime", rad_za_drugoga.id_stroj);
            return View(rad_za_drugoga);
        }

        // GET: Rad_za_drugoga/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rad_za_drugoga rad_za_drugoga = db.Rad_za_drugogas.Find(id);
            if (rad_za_drugoga == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_stroj = new SelectList(db.Strojs, "ID_Stroj", "Ime", rad_za_drugoga.id_stroj);
            return View(rad_za_drugoga);
        }

        // POST: Rad_za_drugoga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,datum_vrijeme,zarada,trajanje,id_stroj")] Rad_za_drugoga rad_za_drugoga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rad_za_drugoga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_stroj = new SelectList(db.Strojs, "ID_Stroj", "Ime", rad_za_drugoga.id_stroj);
            return View(rad_za_drugoga);
        }

        // GET: Rad_za_drugoga/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rad_za_drugoga rad_za_drugoga = db.Rad_za_drugogas.Find(id);
            if (rad_za_drugoga == null)
            {
                return HttpNotFound();
            }
            return View(rad_za_drugoga);
        }

        // POST: Rad_za_drugoga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Rad_za_drugoga rad_za_drugoga = db.Rad_za_drugogas.Find(id);
            db.Rad_za_drugogas.Remove(rad_za_drugoga);
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
