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
    public class ProfilesController : Controller
    {
        private GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();

        // GET: Profiles
        public ActionResult Index()
        {
            var profile = db.Profile.Include(p => p.Employer).Include(p => p.Freelancer);
            return View(profile.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname");
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Profile_Id,Employer_Id,Candidate_Id")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", profile.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", profile.Candidate_Id);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", profile.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", profile.Candidate_Id);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile_Id,Employer_Id,Candidate_Id")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employer_Id = new SelectList(db.Employer, "Employer_Id", "Companyname", profile.Employer_Id);
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", profile.Candidate_Id);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profile.Find(id);
            db.Profile.Remove(profile);
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
