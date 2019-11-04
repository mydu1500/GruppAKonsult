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
    public class JobbanksController : Controller
    {
        private GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();

        // GET: Jobbanks
        public ActionResult Index()
        {
            var jobbank = db.Jobbank.Include(j => j.Employer).Include(j => j.Freelancer);
            return View(jobbank.ToList());
        }

        // GET: Jobbanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobbank jobbank = db.Jobbank.Find(id);
            if (jobbank == null)
            {
                return HttpNotFound();
            }
            return View(jobbank);
        }

        // GET: Jobbanks/Create
        public ActionResult Create()
        {
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname");
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname");
            return View();
        }

        // POST: Jobbanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Profile_Id,Employer_Id,Candidate_Id")] Jobbank jobbank)
        {
            if (ModelState.IsValid)
            {
                db.Jobbank.Add(jobbank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", jobbank.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", jobbank.Candidate_Id);
            return View(jobbank);
        }

        // GET: Jobbanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobbank jobbank = db.Jobbank.Find(id);
            if (jobbank == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", jobbank.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", jobbank.Candidate_Id);
            return View(jobbank);
        }

        // POST: Jobbanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile_Id,Employer_Id,Candidate_Id")] Jobbank jobbank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobbank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", jobbank.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", jobbank.Candidate_Id);
            return View(jobbank);
        }

        // GET: Jobbanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobbank jobbank = db.Jobbank.Find(id);
            if (jobbank == null)
            {
                return HttpNotFound();
            }
            return View(jobbank);
        }

        // POST: Jobbanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobbank jobbank = db.Jobbank.Find(id);
            db.Jobbank.Remove(jobbank);
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
