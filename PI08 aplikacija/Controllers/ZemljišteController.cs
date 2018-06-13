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
    public class ZemljišteController : Controller
    {
        private PI08Model db = new PI08Model();

        // GET: Zemljište
        public ActionResult Index()
        {
            return View(db.Zemljište.ToList());
        }

        // GET: Zemljište/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zemljište zemljište = db.Zemljište.Find(id);
            if (zemljište == null)
            {
                return HttpNotFound();
            }
            return View(zemljište);
        }

        // GET: Zemljište/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zemljište/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Zemljište,Naziv,Lokacija,Korišteno_od,Korišteno_do,Pogodnost,ID_Farma,Vlasnik")] Zemljište zemljište)
        {
            if (ModelState.IsValid)
            {
                db.Zemljište.Add(zemljište);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zemljište);
        }

        // GET: Zemljište/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zemljište zemljište = db.Zemljište.Find(id);
            if (zemljište == null)
            {
                return HttpNotFound();
            }
            return View(zemljište);
        }

        // POST: Zemljište/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Zemljište,Naziv,Lokacija,Korišteno_od,Korišteno_do,Pogodnost,ID_Farma,Vlasnik")] Zemljište zemljište)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zemljište).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zemljište);
        }

        // GET: Zemljište/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zemljište zemljište = db.Zemljište.Find(id);
            if (zemljište == null)
            {
                return HttpNotFound();
            }
            return View(zemljište);
        }

        // POST: Zemljište/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zemljište zemljište = db.Zemljište.Find(id);
            db.Zemljište.Remove(zemljište);
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
