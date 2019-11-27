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
    public class DemographicsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Demographics
        public ActionResult Index()
        {
            return View(db.Demographics.ToList());
        }

        // GET: Demographics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // GET: Demographics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village")] Demographic demographic)
        {
            if (ModelState.IsValid)
            {
                db.Demographics.Add(demographic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demographic);
        }

        // GET: Demographics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // POST: Demographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village")] Demographic demographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demographic);
        }

        // GET: Demographics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // POST: Demographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Demographic demographic = db.Demographics.Find(id);
            db.Demographics.Remove(demographic);
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
