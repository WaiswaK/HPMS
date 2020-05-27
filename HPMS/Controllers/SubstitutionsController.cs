using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class SubstitutionsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Substitutions
        public ActionResult Index()
        {
            var substitutions = db.Substitutions.Include(s => s.Patient).Include(s => s.Substitution_Line);
            return View(substitutions.ToList());
        }

        // GET: Substitutions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            return View(substitution);
        }

        // GET: Substitutions/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID");
            return View();
        }

        // POST: Substitutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Substution_ID,Substitution_Date,PID,Reason,Line_ID,Regimen")] Substitution substitution)
        {
            var query = db.Substitutions.Count() + 1;
            string temp = "Sub-" + query;
            bool exist = false;

            try
            {
                var search = db.Substitutions.Where(c => c.Substution_ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Substitutions.ToList();
                var _substitution = all.Last();
                _substitution.Substution_ID = "Sub-" + DataModels.DataProcess.NextNumber(_substitution.Substution_ID);
            }
            else
            {
                substitution.Substution_ID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Substitutions.Add(substitution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", substitution.PID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // GET: Substitutions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", substitution.PID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // POST: Substitutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Substution_ID,Substitution_Date,PID,Reason,Line_ID,Regimen")] Substitution substitution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(substitution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", substitution.PID);
            ViewBag.Line_ID = new SelectList(db.Substitution_Lines, "Line_ID", "Line_ID", substitution.Line_ID);
            return View(substitution);
        }

        // GET: Substitutions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Substitution substitution = db.Substitutions.Find(id);
            if (substitution == null)
            {
                return HttpNotFound();
            }
            return View(substitution);
        }

        // POST: Substitutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Substitution substitution = db.Substitutions.Find(id);
            db.Substitutions.Remove(substitution);
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
