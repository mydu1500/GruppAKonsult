using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models;

namespace GruppAKonsult.Controllers
{
    public class ProfessionsController : Controller
    {
        private GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();

        // GET: Professions
        public ActionResult Index()
        {
            var profession = db.Profession.Include(p => p.CV);
            return View(profession.ToList());
        }

        // GET: Professions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Profession.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            ViewBag.CV_Id = new SelectList(db.CV, "CV_Id", "Drivinglicense");
            return View();
        }

        // POST: Professions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Candidate_Id,CV_Id,Webbdeveloper,Systemdeveloper,Programmer,Softwareengineer,Frontenddeveloper,Backenddeveloper,Javadeveloper,Scrummaster")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Profession.Add(profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CV_Id = new SelectList(db.CV, "CV_Id", "Drivinglicense", profession.CV_Id);
            return View(profession);
        }

        // GET: Professions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Profession.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            ViewBag.CV_Id = new SelectList(db.CV, "CV_Id", "Drivinglicense", profession.CV_Id);
            return View(profession);
        }

        // POST: Professions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Candidate_Id,CV_Id,Webbdeveloper,Systemdeveloper,Programmer,Softwareengineer,Frontenddeveloper,Backenddeveloper,Javadeveloper,Scrummaster")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CV_Id = new SelectList(db.CV, "CV_Id", "Drivinglicense", profession.CV_Id);
            return View(profession);
        }

        // GET: Professions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Profession.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profession profession = db.Profession.Find(id);
            db.Profession.Remove(profession);
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
