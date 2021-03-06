﻿using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class DemographicsController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Demographics
        [Authorize(Roles = "Medical Practitioner,Administrator")]
        public ActionResult Index()
        {
            var demographics = db.Demographics.Include(d => d.AspNetUser);
            return View(demographics.ToList());
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
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: Demographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village,Id,ImagePath,Full_Name,Marital_status")] Demographic demographic, HttpPostedFileBase upload)
        {
            demographic.Marital_status = DataModels.DataProcess.Replace_(demographic.Marital_status);
            if (ModelState.IsValid)
            {
                //Check the exisitence of user ID in other records
                if (DataModels.DataProcess.Exists(demographic.Id))
                {
                    ModelState.AddModelError("", "Email already exists");
                }
                else
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(upload.FileName).ToLower();
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                        {
                            var uploadpath = Path.Combine(Server.MapPath("~/Images/People"),
                               demographic.Id + ".jpg");
                            var path = @"~/Images/People" + @"/" + demographic.Id + ".jpg";
                            demographic.ImagePath = path;
                            upload.SaveAs(uploadpath);
                        }
                    }
                    demographic.Full_Name = DataModels.DataProcess.RemoveSpace(demographic.Given_Name + " " + demographic.Midle_Name + " " + demographic.Family_Name);
                    db.Demographics.Add(demographic);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }             
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
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
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
            return View(demographic);
        }

        // POST: Demographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village,Id,ImagePath,Full_Name,Marital_status")] Demographic demographic, HttpPostedFileBase upload)
        {
            demographic.Marital_status = DataModels.DataProcess.Replace_(demographic.Marital_status);
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.Exists(demographic.Id))
                {
                    ModelState.AddModelError("", "Email already exists");
                }
                else
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(upload.FileName).ToLower();
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                        {
                            var uploadpath = Path.Combine(Server.MapPath("~/Images/People"),
                               demographic.Id + ".jpg");
                            var path = @"~/Images/People" + @"/" + demographic.Id + ".jpg";
                            demographic.ImagePath = path;
                            upload.SaveAs(uploadpath);
                        }
                    }
                    demographic.Full_Name = DataModels.DataProcess.RemoveSpace(demographic.Given_Name + " " + demographic.Midle_Name + " " + demographic.Family_Name);
                    db.Entry(demographic).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
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
