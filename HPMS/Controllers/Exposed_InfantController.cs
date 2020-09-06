using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Exposed_InfantController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Exposed_Infant
        [Authorize(Roles = "Medical Practitioner")]
        public ActionResult Index()
        {
            var exposed_Infants = db.Exposed_Infants.Include(e => e.Demographic).Include(e => e.Patient);
            return View(exposed_Infants.ToList());
        }

        // GET: Exposed_Infant/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exposed_Infant exposed_Infant = db.Exposed_Infants.Find(id);
            if (exposed_Infant == null)
            {
                return HttpNotFound();
            }
            return View(exposed_Infant);
        }

        // GET: Exposed_Infant/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name");
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name");
            return View();
        }

        // POST: Exposed_Infant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EEID,NIN,PID,Infant_Feeding_Practices,HIV_Test,Results_Attempts")] Exposed_Infant exposed_Infant)
        {
            var query = db.Exposed_Infants.Count() + 1;
            string temp = "EXP-" + query;
            bool exist = false;
            try
            {
                var search = db.Exposed_Infants.Where(c => c.EEID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;
            }
            if (exist)
            {
                var all = db.Exposed_Infants.ToList();
                var exp = all.Last();
                exposed_Infant.EEID = "EXP-" + +DataModels.DataProcess.NextNumber(exp.EEID);
            }
            else
            {
                exposed_Infant.EEID = temp;
            }

           
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(exposed_Infant.NIN, exposed_Infant.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Infant can't be the same person"); 
                }
                else
                {
                    db.Exposed_Infants.Add(exposed_Infant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }              
            }

            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", exposed_Infant.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", exposed_Infant.PID);
            return View(exposed_Infant);
        }

        // GET: Exposed_Infant/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exposed_Infant exposed_Infant = db.Exposed_Infants.Find(id);
            if (exposed_Infant == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", exposed_Infant.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", exposed_Infant.PID);
            return View(exposed_Infant);
        }

        // POST: Exposed_Infant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EEID,NIN,PID,Infant_Feeding_Practices,HIV_Test,Results_Attempts")] Exposed_Infant exposed_Infant)
        {
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(exposed_Infant.NIN, exposed_Infant.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Infant can't be the same person");
                }
                else
                {
                    db.Entry(exposed_Infant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", exposed_Infant.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", exposed_Infant.PID);
            return View(exposed_Infant);
        }

        // GET: Exposed_Infant/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exposed_Infant exposed_Infant = db.Exposed_Infants.Find(id);
            if (exposed_Infant == null)
            {
                return HttpNotFound();
            }
            return View(exposed_Infant);
        }

        // POST: Exposed_Infant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Exposed_Infant exposed_Infant = db.Exposed_Infants.Find(id);
            db.Exposed_Infants.Remove(exposed_Infant);
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
