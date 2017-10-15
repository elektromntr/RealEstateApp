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
    public class MieszkaniaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // markowy partial
        //public ActionResult MieszkaniaZInwestycji(string niedostepne, int? id = 1)
        public ActionResult MieszkaniaZInwestycji(int? id, string niedostepne)
        {
            
            //var mieszkania = db.Mieszkania;
            var mieszkania = db.Mieszkania.Where(p => p.InwestycjaId > 0 );
            //if (mieszkania == null) RedirectToAction("Index", "Home");

            if (id == null)
            {
                mieszkania = db.Mieszkania.Where(p => p.InwestycjaId > 0);
            }
            else
            {
                mieszkania = db.Mieszkania.Where(p => p.InwestycjaId == id);
            }

            ViewBag.UkryjPokaz = niedostepne == "ukryj" ? "pokaz" : "ukryj";
            switch (niedostepne)
            {
                case "ukryj":
                    mieszkania = mieszkania.Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    break;
                default:
                    mieszkania = mieszkania.Where(m => m.StatusId > 0); // StatusId >0 powoduje wyświetlanie mieszkań ze statusem wszystkie
                    break;
            } 

            return PartialView("_MieszkaniaInwestycja", mieszkania.ToList());
        }

        // GET: Mieszkania
        public ActionResult Index(string niedostepne)
        {
            ViewBag.UkryjPokaz = niedostepne == "ukryj" ? "pokaz" : "ukryj";
            var mieszkania = db.Mieszkania.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId > 0); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie

            switch (niedostepne)
            {
                case "ukryj":
                    mieszkania = mieszkania.Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    break;
                default:
                    mieszkania = mieszkania.Where(m => m.StatusId > 0); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie
                    break;
            }

            return View(mieszkania.ToList());
        }

        // GET: Mieszkania/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mieszkanie mieszkanie = db.Mieszkania.Find(id);
            if (mieszkanie == null)
            {
                return HttpNotFound();
            }
            return View(mieszkanie);
        }

        [Authorize(Roles = "Operator, Admin")]
        // GET: Mieszkania/Create
        public ActionResult Create()
        {
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa");
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa");
            return View();
        }

        // POST: Mieszkania/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MieszkanieId,SymbolMieszkania,InwestycjaId,StatusId,Cena,Poziom,Powierzchnia,Pokoje,Antresola,Garaz,MiejscePostojowe,KomorkaLokatorska,TerminRealizacji,ImageData,ImageMimeType,DodatkoweInfo")] Mieszkanie mieszkanie)
        {
            if (ModelState.IsValid)
            {
                db.Mieszkania.Add(mieszkanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", mieszkanie.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa", mieszkanie.StatusId);
            return View(mieszkanie);
        }

        [Authorize(Roles = "Operator, Admin, Obsluga")]
        // GET: Mieszkania/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mieszkanie mieszkanie = db.Mieszkania.Find(id);
            if (mieszkanie == null)
            {
                return HttpNotFound();
            }
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", mieszkanie.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa", mieszkanie.StatusId);
            return View(mieszkanie);
        }

        // POST: Mieszkania/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MieszkanieId,SymbolMieszkania,InwestycjaId,StatusId,Cena,Poziom,Powierzchnia,Pokoje,Antresola,Garaz,MiejscePostojowe,KomorkaLokatorska,TerminRealizacji,ImageData,ImageMimeType,DodatkoweInfo")] Mieszkanie mieszkanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mieszkanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", mieszkanie.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa", mieszkanie.StatusId);
            return View(mieszkanie);
        }

        [Authorize(Roles = "Operator, Admin")]
        // GET: Mieszkania/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mieszkanie mieszkanie = db.Mieszkania.Find(id);
            if (mieszkanie == null)
            {
                return HttpNotFound();
            }
            return View(mieszkanie);
        }

        // POST: Mieszkania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mieszkanie mieszkanie = db.Mieszkania.Find(id);
            db.Mieszkania.Remove(mieszkanie);
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
