using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppAKonsult.Models;
using GruppAKonsult.ViewModels;

namespace GruppAKonsult.Controllers
{
    public class CVsController : Controller
    {
        GruppAKonsult_dbEntities2 db = new GruppAKonsult_dbEntities2();
        // GET: CVs
        public ActionResult Index()
        {
           
            CVViewModel cvvm = new CVViewModel();
            List<CV> ListOfCv = new List<CV>();
            var freelancercv = db.CV.Include(c => c.Freelancer);

            //var listOfProfessions = ();
            return View(freelancercv.ToList());
        }


       // GET: CVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CV.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // GET: CVs/Create
        public ActionResult Create()
        {
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname");
            return View();
        }

        // POST: CVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CV_Id,Candidate_Id,Drivinglicense,Description,Education,Workexperience")] CV cV)
        {
            if (ModelState.IsValid)
            {
                db.CV.Add(cV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", cV.Candidate_Id);
            return View(cV);
        }

        public ActionResult Edit(int? Candidate_Id)
        {
            if (Candidate_Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cvvm = new CVViewModel
            {
                Cv = db.CV.Include(i => i.Profession).First(i => i.Candidate_Id == Candidate_Id),
            };
            if (cvvm.Cv == null)
                return HttpNotFound();
            var professionList = db.Profession.ToList();
            cvvm.AllProfessions = professionList.Select(o => new SelectListItem
            {
                Text = o.Backenddeveloper,
                Value = o.Candidate_Id.ToString()
            });
            ViewBag.EmployerID =
            new SelectList(db.CV, "Candidate_Id", "Profession",
            cvvm.Cv.Candidate_Id);
            return View(cvvm);
        }

        // GET: CVs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CV cV = db.CV.Find(id);
        //    if (cV == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", cV.Candidate_Id);
        //    return View(cV);
        //}

        // POST: CVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CV_Id,Candidate_Id,Drivinglicense,Description,Education,Workexperience")] CV cV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Candidate_Id = new SelectList(db.Freelancer, "Candidate_Id", "Firstname", cV.Candidate_Id);
            return View(cV);
        }

        // GET: CVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cV = db.CV.Find(id);
            if (cV == null)
            {
                return HttpNotFound();
            }
            return View(cV);
        }

        // POST: CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CV cV = db.CV.Find(id);
            db.CV.Remove(cV);
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
