using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class VisitsController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Visits
        [Authorize(Roles = "Medical Practitioner")]
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Diet_Chart).Include(v => v.Health_Tip).Include(v => v.Medication).Include(v => v.Patient);
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
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content");
            ViewBag.HT = new SelectList(db.Health_Tips, "HT", "Tip");
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine");
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Visit_ID,PID,Visit_Date,Date_Next_Visit,Nutrition_Assessment,Pregnancy_Status,Gestation,FP,FP_Method,CaCx_Screening,TB_Status,TPT,TPT_Effects,Diagnosis,ART_Effects,Hep_Test,Hep_Result,Syphilis_Status,CTX,Other_Meds,ARV_Drugs,Fluconazole,Tests_and_Investigations,DSD_Model,SID,MUAC_SCORE,Weight,Height,Weight_Score,Height_Score,BMI_Score,Blood_pressure___Systolic,Blood_pressure___Diastolic,Blood_Sugar,Temperature,Tobacco_Use,CD4_Count,Clinical_Stage,Viral_Load,Medical_Report,Second_Report,Third_Report,Fourth_Report,DC,HT,Medication_ID,Time_for__Medication")] Visit visit, HttpPostedFileBase upload,
            HttpPostedFileBase upload_two, HttpPostedFileBase upload_three, HttpPostedFileBase upload_four)
        {
            var query = db.Visits.Count() + 1;
            string temp = "V-" + query;
            bool exist = false;

            try
            {
                var search = db.Visits.Where(c => c.Visit_ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Visits.ToList();
                var dis = all.Last();
                visit.Visit_ID = "V-" + DataModels.DataProcess.NextNumber(dis.Visit_ID);
            }
            else
            {
                visit.Visit_ID = temp;
            }
            //Replacing _ here
            visit.Pregnancy_Status = DataModels.DataProcess.Replace_(visit.Pregnancy_Status);



            if (ModelState.IsValid)
            {
                //Upload one
                if (upload != null && upload.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "1" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Medical_Report = path;
                    upload.SaveAs(uploadpath);
                }
                //Upload two
                if (upload_two != null && upload_two.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_two.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "2" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Second_Report = path;
                    upload_two.SaveAs(uploadpath);
                }
                //Upload three
                if (upload_three != null && upload_three.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_three.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "3" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Third_Report = path;
                    upload_three.SaveAs(uploadpath);
                }
                //Upload four
                if (upload_four != null && upload_four.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_four.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "4" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Fourth_Report = path;
                    upload_four.SaveAs(uploadpath);
                }

                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", visit.DC);
            ViewBag.HT = new SelectList(db.Health_Tips, "HT", "Tip", visit.HT);
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", visit.Medication_ID);
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
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", visit.DC);
            ViewBag.HT = new SelectList(db.Health_Tips, "HT", "Tip", visit.HT);
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", visit.Medication_ID);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", visit.PID);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Visit_ID,PID,Visit_Date,Date_Next_Visit,Nutrition_Assessment,Pregnancy_Status,Gestation,FP,FP_Method,CaCx_Screening,TB_Status,TPT,TPT_Effects,Diagnosis,ART_Effects,Hep_Test,Hep_Result,Syphilis_Status,CTX,Other_Meds,ARV_Drugs,Fluconazole,Tests_and_Investigations,DSD_Model,SID,MUAC_SCORE,Weight,Height,Weight_Score,Height_Score,BMI_Score,Blood_pressure___Systolic,Blood_pressure___Diastolic,Blood_Sugar,Temperature,Tobacco_Use,CD4_Count,Clinical_Stage,Viral_Load,Medical_Report,Second_Report,Third_Report,Fourth_Report,DC,HT,Medication_ID,Time_for__Medication")] Visit visit, HttpPostedFileBase upload,
            HttpPostedFileBase upload_two, HttpPostedFileBase upload_three, HttpPostedFileBase upload_four)
        {
            //Replacing _ here
            visit.Pregnancy_Status = DataModels.DataProcess.Replace_(visit.Pregnancy_Status);
            if (ModelState.IsValid)
            {
                //Upload one
                if (upload != null && upload.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "1" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Medical_Report = path;
                    upload.SaveAs(uploadpath);
                }
                //Upload two
                if (upload_two != null && upload_two.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_two.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "2" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Second_Report = path;
                    upload_two.SaveAs(uploadpath);
                }
                //Upload three
                if (upload_three != null && upload_three.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_three.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "3" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Third_Report = path;
                    upload_three.SaveAs(uploadpath);
                }
                //Upload four
                if (upload_four != null && upload_four.ContentLength > 0)
                {
                    string ext = Path.GetExtension(upload_four.FileName).ToLower();

                    var uploadpath = Path.Combine(Server.MapPath("~/Documents/"),
                           "4" + visit.Visit_ID + "." + ext);
                    var path = @"~/Documents" + @"/" + visit.Visit_ID + ext;
                    visit.Fourth_Report = path;
                    upload_four.SaveAs(uploadpath);
                }
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", visit.DC);
            ViewBag.HT = new SelectList(db.Health_Tips, "HT", "Tip", visit.HT);
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", visit.Medication_ID);
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
