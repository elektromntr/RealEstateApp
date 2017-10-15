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
    public class DomyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // markowy partial
        public ActionResult DomyZInwestycji(int? id, string niedostepne)
        {
            var domy = db.Domy.Where(p => p.InwestycjaId > 0);
            //if (mieszkania == null) RedirectToAction("Index", "Home");

            if (id == null)
            {
                domy = db.Domy.Where(p => p.InwestycjaId > 0);
            }
            else
            {
                domy = db.Domy.Where(p => p.InwestycjaId == id);
            }

            ViewBag.UkryjPokaz = niedostepne == "ukryj" ? "pokaz" : "ukryj";
            switch (niedostepne)
            {
                case "ukryj":
                    domy = domy.Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    break;
                default:
                    domy = domy.Where(m => m.StatusId > 0); // StatusId > 0 powoduje wyświetlanie mieszkań wszystkich
                    break;
            }

            return PartialView("_DomyInwestycja", domy.ToList());
        }

        // GET: Domy
        public ActionResult Index(string niedostepne)
        {
            ViewBag.UkryjPokaz = niedostepne == "ukryj" ? "pokaz" : "ukryj";
            var domy = db.Domy.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId <= 4); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie

            switch (niedostepne)
            {
                case "ukryj":
                    domy = db.Domy.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId == 1); // StatusId == 1 powoduje wyświetlanie mieszkań tylko wolnych
                    break;
                default:
                    domy = db.Domy.Include(m => m.Inwestycja).Include(m => m.Status).Where(m => m.StatusId <= 4); // StatusId <= 4 powoduje wyświetlanie mieszkań ze statusem tylko mniejszym lub równym 4, czyli wszystkie
                    break;
            }

            return View(domy.ToList());
        }

        // GET: Domy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dom dom = db.Domy.Find(id);
            if (dom == null)
            {
                return HttpNotFound();
            }
            return View(dom);
        }

        [Authorize(Roles = "Operator, Admin")]
        // GET: Domy/Create
        public ActionResult Create()
        {
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa");
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa");
            return View();
        }

        // POST: Domy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DomId,SymbolDomu,InwestycjaId,StatusId,Cena,Powerzchnia,Pokoje,Garaz,MiejscePostojowe,KomorkaLokatorska,TerminRealizacji,ImageData,ImageMimeType,DodatkoweInfo")] Dom dom)
        {
            if (ModelState.IsValid)
            {
                db.Domy.Add(dom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", dom.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusyId", "Nazwa", dom.StatusId);
            return View(dom);
        }

        [Authorize(Roles = "Operator, Admin")]
        // GET: Domy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dom dom = db.Domy.Find(id);
            if (dom == null)
            {
                return HttpNotFound();
            }
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", dom.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa", dom.StatusId);
            return View(dom);
        }

        // POST: Domy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DomId,SymbolDomu,InwestycjaId,StatusId,Cena,Powerzchnia,Pokoje,Garaz,MiejscePostojowe,KomorkaLokatorska,TerminRealizacji,ImageData,ImageMimeType,DodatkoweInfo")] Dom dom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InwestycjaId = new SelectList(db.Inwestycje, "InwestycjaId", "Nazwa", dom.InwestycjaId);
            ViewBag.StatusId = new SelectList(db.Statusy, "StatusId", "Nazwa", dom.StatusId);
            return View(dom);
        }

        [Authorize(Roles = "Operator, Admin")]
        // GET: Domy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dom dom = db.Domy.Find(id);
            if (dom == null)
            {
                return HttpNotFound();
            }
            return View(dom);
        }

        // POST: Domy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dom dom = db.Domy.Find(id);
            db.Domy.Remove(dom);
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
