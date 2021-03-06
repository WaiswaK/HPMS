﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class PatientsController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Patients
        [Authorize(Roles = "Medical Practitioner")]
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Demographic).Include(p => p.Health_Center);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(DataModels.DataProcess.NotSet("Patient"), "NIN", "Full_Name");
            ViewBag.Care_Entry_Point = new SelectList(db.Health_Centers, "HCID", "Center");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,NIN,Next_of_Kin,Special_Category,Care_Entry_Point,Mode_of_Transmission,Average_Monthly_Income,Occupation,Dependents,Drug_Allergies,Relevant_Medical_Conditions,Any_Other_Information,TB,TB_Date,TB_Treatment,TB_Status,Cryptococcal_Meningitis,CM_Date,CM_Treatment,CM_Status,Bacterial_Meningitis,BM_Date,BM_Treatment,BM_Status,Oral_Candidiasis,OC_Date,OC_Treatment,OC_Status,Osephageal__Candidiasis,Candidiasis_Date,Candidiasis_Treatment,Candidiasis_Status,Syphilis,Syphilis_Date,Syphilis_Treatment,Syphilis_Status,Chlamydia,Chlamydia_Date,Chlamydia_Treatment,Chlamydia_Status,Gonorrhea,Gonorrhea_Date,Gonorrhea_Treatment,Gonorrhea_Status")] Patient patient)
        {
            var query = db.Patients.Count() + 1;
            string temp = "P-" + query;
            bool exist = false;

            try
            {
                var search = db.Patients.Where(c => c.PID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;
            }
            if (exist)
            {
                var all = db.Patients.ToList();
                var _patient = all.Last();
                _patient.PID = "P-" + DataModels.DataProcess.NextNumber(_patient.PID);
            }
            else
            {
                patient.PID = temp;
            }

            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.Exists(patient.NIN, "Patient"))
                {
                    ModelState.AddModelError("", "Patient NIN already exists");
                }
                else
                {
                    patient.Full_Name = DataModels.DataProcess.ImageOrName(patient.NIN, "Name");
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", patient.NIN);
            ViewBag.Care_Entry_Point = new SelectList(db.Health_Centers, "HCID", "Center", patient.Care_Entry_Point);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", patient.NIN);
            ViewBag.Care_Entry_Point = new SelectList(db.Health_Centers, "HCID", "Center", patient.Care_Entry_Point); 
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,NIN,Next_of_Kin,Special_Category,Care_Entry_Point,Mode_of_Transmission,Average_Monthly_Income,Occupation,Dependents,Drug_Allergies,Relevant_Medical_Conditions,Any_Other_Information,TB,TB_Date,TB_Treatment,TB_Status,Cryptococcal_Meningitis,CM_Date,CM_Treatment,CM_Status,Bacterial_Meningitis,BM_Date,BM_Treatment,BM_Status,Oral_Candidiasis,OC_Date,OC_Treatment,OC_Status,Osephageal__Candidiasis,Candidiasis_Date,Candidiasis_Treatment,Candidiasis_Status,Syphilis,Syphilis_Date,Syphilis_Treatment,Syphilis_Status,Chlamydia,Chlamydia_Date,Chlamydia_Treatment,Chlamydia_Status,Gonorrhea,Gonorrhea_Date,Gonorrhea_Treatment,Gonorrhea_Status")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.Exists(patient.NIN, "Patient"))
                {
                    ModelState.AddModelError("", "Patient NIN already exists");
                }
                else
                {
                    patient.Full_Name = DataModels.DataProcess.ImageOrName(patient.NIN, "Name");
                    db.Entry(patient).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }          
            } 
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", patient.NIN);
            ViewBag.Care_Entry_Point = new SelectList(db.Health_Centers, "HCID", "Center", patient.Care_Entry_Point);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
