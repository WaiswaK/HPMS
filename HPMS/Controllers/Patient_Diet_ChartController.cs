using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Patient_Diet_ChartController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Patient_Diet_Chart
        public ActionResult Index()
        {
            var patient_Diet_Charts = db.Patient_Diet_Charts.Include(p => p.Diet_Chart).Include(p => p.Patient);
            return View(patient_Diet_Charts.ToList());
        }

        // GET: Patient_Diet_Chart/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Diet_Chart patient_Diet_Chart = db.Patient_Diet_Charts.Find(id);
            if (patient_Diet_Chart == null)
            {
                return HttpNotFound();
            }
            return View(patient_Diet_Chart);
        }

        // GET: Patient_Diet_Chart/Create
        public ActionResult Create()
        {
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content");
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN");
            return View();
        }

        // POST: Patient_Diet_Chart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PDC,DC,PID")] Patient_Diet_Chart patient_Diet_Chart)
        {
            var query = db.Patient_Diet_Charts.Count() + 1;
            string temp = "PD-" + query;
            bool exist = false;
            try
            {
                var search = db.Patient_Diet_Charts.Where(c => c.PDC == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Patient_Diet_Charts.ToList();
                var PD = all.Last();
                PD.PDC = "PD-" + DataModels.DataProcess.NextNumber(PD.PDC);
            }
            else
            {
               patient_Diet_Chart.PDC= temp;
            }
            if (ModelState.IsValid)
            {
                db.Patient_Diet_Charts.Add(patient_Diet_Chart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", patient_Diet_Chart.DC);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Diet_Chart.PID);
            return View(patient_Diet_Chart);
        }

        // GET: Patient_Diet_Chart/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Diet_Chart patient_Diet_Chart = db.Patient_Diet_Charts.Find(id);
            if (patient_Diet_Chart == null)
            {
                return HttpNotFound();
            }
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", patient_Diet_Chart.DC);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Diet_Chart.PID);
            return View(patient_Diet_Chart);
        }

        // POST: Patient_Diet_Chart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PDC,DC,PID")] Patient_Diet_Chart patient_Diet_Chart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Diet_Chart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DC = new SelectList(db.Diet_Charts, "DC", "Content", patient_Diet_Chart.DC);
            ViewBag.PID = new SelectList(db.Patients, "PID", "NIN", patient_Diet_Chart.PID);
            return View(patient_Diet_Chart);
        }

        // GET: Patient_Diet_Chart/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Diet_Chart patient_Diet_Chart = db.Patient_Diet_Charts.Find(id);
            if (patient_Diet_Chart == null)
            {
                return HttpNotFound();
            }
            return View(patient_Diet_Chart);
        }

        // POST: Patient_Diet_Chart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient_Diet_Chart patient_Diet_Chart = db.Patient_Diet_Charts.Find(id);
            db.Patient_Diet_Charts.Remove(patient_Diet_Chart);
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
