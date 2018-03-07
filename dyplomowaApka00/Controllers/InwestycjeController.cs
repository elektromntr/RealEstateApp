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
        public ActionResult Details(int? id, string niedostepne)
        {
            ViewBag.UkryjPokaz = niedostepne == "ukryj" ? "pokaz" : "ukryj";
            var mieszkania = db.Mieszkania.Where(m => m.InwestycjaId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inwestycja inwestycja = db.Inwestycje.Find(id);
            if (inwestycja == null)
            {
                return HttpNotFound();
            }

            switch (niedostepne)
            {
                case "ukryj":
                    mieszkania = mieszkania.Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    //mieszkania = db.Mieszkania.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    break;
                default:
                    mieszkania = mieszkania.Where(m => m.StatusId > 0); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie
                    //mieszkania = db.Mieszkania.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId <= 4); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie
                    break;
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
