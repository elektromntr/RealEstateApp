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
    public class InwestycjeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inwestycje
        public ActionResult Index()
        {
            return View(db.Inwestycje.ToList());
        }

        // GET: Inwestycje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inwestycja inwestycja = db.Inwestycje.Find(id);
            if (inwestycja == null)
            {
                return HttpNotFound();
            }
            return View(inwestycja);
        }

        // GET: Inwestycje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inwestycje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InwestycjaId,Nazwa,HeaderOne,DescOne,HeaderTwo,DescTwo,HeaderThree,DescThree,HeaderFour,DescFour")] Inwestycja inwestycja)
        {
            if (ModelState.IsValid)
            {
                db.Inwestycje.Add(inwestycja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inwestycja);
        }

        // GET: Inwestycje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inwestycja inwestycja = db.Inwestycje.Find(id);
            if (inwestycja == null)
            {
                return HttpNotFound();
            }
            return View(inwestycja);
        }

        // POST: Inwestycje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InwestycjaId,Nazwa,HeaderOne,DescOne,HeaderTwo,DescTwo,HeaderThree,DescThree,HeaderFour,DescFour")] Inwestycja inwestycja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inwestycja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inwestycja);
        }

        // GET: Inwestycje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inwestycja inwestycja = db.Inwestycje.Find(id);
            if (inwestycja == null)
            {
                return HttpNotFound();
            }
            return View(inwestycja);
        }

        // POST: Inwestycje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inwestycja inwestycja = db.Inwestycje.Find(id);
            db.Inwestycje.Remove(inwestycja);
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
