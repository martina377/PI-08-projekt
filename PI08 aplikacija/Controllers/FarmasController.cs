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
    public class FarmasController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Farmas
        public ActionResult Index()
        {
            return View(db.Farmas.ToList());
        }

        // GET: Farmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farma farma = db.Farmas.Find(id);
            if (farma == null)
            {
                return HttpNotFound();
            }
            return View(farma);
        }

        // GET: Farmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Farma,Farma1,Lokacija,Vlasnik")] Farma farma)
        {
            if (ModelState.IsValid)
            {
                db.Farmas.Add(farma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farma);
        }

        // GET: Farmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farma farma = db.Farmas.Find(id);
            if (farma == null)
            {
                return HttpNotFound();
            }
            return View(farma);
        }

        // POST: Farmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Farma,Farma1,Lokacija,Vlasnik")] Farma farma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farma);
        }

        // GET: Farmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farma farma = db.Farmas.Find(id);
            if (farma == null)
            {
                return HttpNotFound();
            }
            return View(farma);
        }

        // POST: Farmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farma farma = db.Farmas.Find(id);
            db.Farmas.Remove(farma);
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
