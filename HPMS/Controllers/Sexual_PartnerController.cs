using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Sexual_PartnerController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Sexual_Partner
        public ActionResult Index()
        {
            var sexual_Partners = db.Sexual_Partners.Include(s => s.Demographic).Include(s => s.Patient);
            return View(sexual_Partners.ToList());
        }

        // GET: Sexual_Partner/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexual_Partner sexual_Partner = db.Sexual_Partners.Find(id);
            if (sexual_Partner == null)
            {
                return HttpNotFound();
            }
            return View(sexual_Partner);
        }

        // GET: Sexual_Partner/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name");
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name");
            return View();
        }

        // POST: Sexual_Partner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPID,NIN,PID,Relationship,HIV_Care,Contraceptives_Used")] Sexual_Partner sexual_Partner)
        {
            var query = db.Sexual_Partners.Count() + 1;
            string temp = "SPID-" + query;
            bool exist = false;
            try
            {
                var search = db.Sexual_Partners.Where(c => c.SPID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;
            }
            if (exist)
            {
                var all = db.Sexual_Partners.ToList();
                var SP = all.Last();
                sexual_Partner.SPID = "SPID-" + DataModels.DataProcess.NextNumber(SP.SPID);
            }
            else
            {
                sexual_Partner.SPID = temp;
            }
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(sexual_Partner.NIN, sexual_Partner.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Sexual Partner can't be the same person");
                }
                else
                {
                    db.Sexual_Partners.Add(sexual_Partner);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }

            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", sexual_Partner.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID","Full_Name", sexual_Partner.PID);
            return View(sexual_Partner);
        }

        // GET: Sexual_Partner/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexual_Partner sexual_Partner = db.Sexual_Partners.Find(id);
            if (sexual_Partner == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", sexual_Partner.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", sexual_Partner.PID);
            return View(sexual_Partner);
        }

        // POST: Sexual_Partner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPID,NIN,PID,Relationship,HIV_Care,Contraceptives_Used")] Sexual_Partner sexual_Partner)
        {
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(sexual_Partner.NIN, sexual_Partner.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Sexual Partner can't be the same person");
                }
                else
                {
                    db.Entry(sexual_Partner).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }              
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", sexual_Partner.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", sexual_Partner.PID);
            return View(sexual_Partner);
        }

        // GET: Sexual_Partner/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sexual_Partner sexual_Partner = db.Sexual_Partners.Find(id);
            if (sexual_Partner == null)
            {
                return HttpNotFound();
            }
            return View(sexual_Partner);
        }

        // POST: Sexual_Partner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sexual_Partner sexual_Partner = db.Sexual_Partners.Find(id);
            db.Sexual_Partners.Remove(sexual_Partner);
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
