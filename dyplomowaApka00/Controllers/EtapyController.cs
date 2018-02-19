using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dyplomowaApka00.Models;

namespace dyplomowaApka00.Controllers
{
    public class EtapyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Etapy
        public ActionResult Index()
        {
            return View(db.Etaps.ToList());
        }

        // GET: Etapy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etap etap = db.Etaps.Find(id);
            if (etap == null)
            {
                return HttpNotFound();
            }
            return View(etap);
        }

        // GET: Etapy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etapy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EtapId,Nazwa")] Etap etap)
        {
            if (ModelState.IsValid)
            {
                db.Etaps.Add(etap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etap);
        }

        // GET: Etapy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etap etap = db.Etaps.Find(id);
            if (etap == null)
            {
                return HttpNotFound();
            }
            return View(etap);
        }

        // POST: Etapy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EtapId,Nazwa")] Etap etap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etap);
        }

        // GET: Etapy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etap etap = db.Etaps.Find(id);
            if (etap == null)
            {
                return HttpNotFound();
            }
            return View(etap);
        }

        // POST: Etapy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etap etap = db.Etaps.Find(id);
            db.Etaps.Remove(etap);
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
