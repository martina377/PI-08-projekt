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
    public class ProdajasController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Prodajas
        public ActionResult Index()
        {
            return View(db.Prodajas.ToList());
        }

        // GET: Prodajas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja prodaja = db.Prodajas.Find(id);
            if (prodaja == null)
            {
                return HttpNotFound();
            }
            return View(prodaja);
        }

        // GET: Prodajas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prodajas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Prodaja,Lokacija,Količina,Zarada,Proizvod")] Prodaja prodaja)
        {
            if (ModelState.IsValid)
            {
                db.Prodajas.Add(prodaja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodaja);
        }

        // GET: Prodajas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja prodaja = db.Prodajas.Find(id);
            if (prodaja == null)
            {
                return HttpNotFound();
            }
            return View(prodaja);
        }

        // POST: Prodajas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Prodaja,Lokacija,Količina,Zarada,Proizvod")] Prodaja prodaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodaja);
        }

        // GET: Prodajas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodaja prodaja = db.Prodajas.Find(id);
            if (prodaja == null)
            {
                return HttpNotFound();
            }
            return View(prodaja);
        }

        // POST: Prodajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prodaja prodaja = db.Prodajas.Find(id);
            db.Prodajas.Remove(prodaja);
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
