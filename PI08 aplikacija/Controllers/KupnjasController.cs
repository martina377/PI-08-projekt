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
    public class KupnjasController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Kupnjas
        public ActionResult Index()
        {
            return View(db.Kupnjas.ToList());
        }

        // GET: Kupnjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupnja kupnja = db.Kupnjas.Find(id);
            if (kupnja == null)
            {
                return HttpNotFound();
            }
            return View(kupnja);
        }

        // GET: Kupnjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupnjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Kupnja,Vrsta_proizvoda,Količina,Cijena")] Kupnja kupnja)
        {
            if (ModelState.IsValid)
            {
                db.Kupnjas.Add(kupnja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kupnja);
        }

        // GET: Kupnjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupnja kupnja = db.Kupnjas.Find(id);
            if (kupnja == null)
            {
                return HttpNotFound();
            }
            return View(kupnja);
        }

        // POST: Kupnjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Kupnja,Vrsta_proizvoda,Količina,Cijena")] Kupnja kupnja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupnja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kupnja);
        }

        // GET: Kupnjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupnja kupnja = db.Kupnjas.Find(id);
            if (kupnja == null)
            {
                return HttpNotFound();
            }
            return View(kupnja);
        }

        // POST: Kupnjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kupnja kupnja = db.Kupnjas.Find(id);
            db.Kupnjas.Remove(kupnja);
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
