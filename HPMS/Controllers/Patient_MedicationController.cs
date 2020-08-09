using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Patient_MedicationController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Patient_Medication
        public ActionResult Index()
        {
            var patient_Medications = db.Patient_Medications.Include(p => p.Medication).Include(p => p.Patient);
            return View(patient_Medications.ToList());
        }

        // GET: Patient_Medication/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medication patient_Medication = db.Patient_Medications.Find(id);
            if (patient_Medication == null)
            {
                return HttpNotFound();
            }
            return View(patient_Medication);
        }

        // GET: Patient_Medication/Create
        public ActionResult Create()
        {
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine");
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            return View();
        }

        // POST: Patient_Medication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PMedID,Medication_ID,PID,Time_for__Medication")] Patient_Medication patient_Medication)
        {
            var query = db.Patient_Medications.Count() + 1;
            string temp = "DIET-" + query;
            bool exist = false;
            try
            {
                var search = db.Patient_Medications.Where(c => c.Medication_ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Patient_Medications.ToList();
                var medication = all.Last();
                medication.Medication_ID = "DIET-" + DataModels.DataProcess.NextNumber(medication.Medication_ID);
            }
            else
            {
                patient_Medication.Medication_ID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Patient_Medications.Add(patient_Medication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", patient_Medication.Medication_ID);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Medication.PID);
            return View(patient_Medication);
        }

        // GET: Patient_Medication/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medication patient_Medication = db.Patient_Medications.Find(id);
            if (patient_Medication == null)
            {
                return HttpNotFound();
            }
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", patient_Medication.Medication_ID);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Medication.PID);
            return View(patient_Medication);
        }

        // POST: Patient_Medication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PMedID,Medication_ID,PID,Time_for__Medication")] Patient_Medication patient_Medication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Medication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Medication_ID = new SelectList(db.Medications, "Medical_ID", "Medicine", patient_Medication.Medication_ID);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Medication.PID);
            return View(patient_Medication);
        }

        // GET: Patient_Medication/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Medication patient_Medication = db.Patient_Medications.Find(id);
            if (patient_Medication == null)
            {
                return HttpNotFound();
            }
            return View(patient_Medication);
        }

        // POST: Patient_Medication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient_Medication patient_Medication = db.Patient_Medications.Find(id);
            db.Patient_Medications.Remove(patient_Medication);
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
