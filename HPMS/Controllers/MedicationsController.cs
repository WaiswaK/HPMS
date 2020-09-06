using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Medications
        //[Authorize(Roles = "Medical Practitioner")]
        public ActionResult Index()
        {
            return View(db.Medications.ToList());
        }

        // GET: Medications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            return View(medication);
        }

        // GET: Medications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medication_ID,Medicine")] Medication medication)
        {
            var query = db.Medications.Count() + 1;
            string temp = "MED-" + query;
            bool exist = false;
            try
            {
                var search = db.Medications.Where(c => c.Medical_ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Medications.ToList();
                var med = all.Last();
                medication.Medical_ID = "MED-" + DataModels.DataProcess.NextNumber(med.Medical_ID);
            }
            else
            {
                medication.Medical_ID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Medications.Add(medication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medication);
        }

        // GET: Medications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            return View(medication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medication_ID,Medicine")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medication);
        }

        // GET: Medications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Medication medication = db.Medications.Find(id);
            db.Medications.Remove(medication);
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
