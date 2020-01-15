using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class VisitsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Visits
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Patient);
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visits/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Visit_ID,PID,Visit_Date,Date_Next_Visit,Date_of_Birth,Nutrition_Assessment,Pregnancy_Status,Gestation,FP,FP_Method,CaCx_Screening,TB_Status,TPT,TPT_Effects,Diagnosis,ART_Effects,Hep_Test,Hep_Result,Syphilis_Status,CTX,Other_Meds,ARV_Drugs,Fluconazole,Tests_and_Investigations,DSD_Model,SID,MUAC_SCORE,Weight,Height,Weight_Score,Height_Score,BMI_Score,Blood_pressure___Systolic,Blood_pressure___Diastolic,Blood_Sugar,Temperature,Tobacco_Use,CD4_Count,Clinical_Stage,Viral_Load")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", visit.PID);
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", visit.PID);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Visit_ID,PID,Visit_Date,Date_Next_Visit,Date_of_Birth,Nutrition_Assessment,Pregnancy_Status,Gestation,FP,FP_Method,CaCx_Screening,TB_Status,TPT,TPT_Effects,Diagnosis,ART_Effects,Hep_Test,Hep_Result,Syphilis_Status,CTX,Other_Meds,ARV_Drugs,Fluconazole,Tests_and_Investigations,DSD_Model,SID,MUAC_SCORE,Weight,Height,Weight_Score,Height_Score,BMI_Score,Blood_pressure___Systolic,Blood_pressure___Diastolic,Blood_Sugar,Temperature,Tobacco_Use,CD4_Count,Clinical_Stage,Viral_Load")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", visit.PID);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
