using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Family_MemberController : Controller
    {
        private readonly Models.HPMS db = new Models.HPMS();

        // GET: Family_Member
       [Authorize(Roles = "Medical Practitioner")]
        public ActionResult Index()
        {
            var family_Members = db.Family_Members.Include(f => f.Demographic).Include(f => f.Patient);
            return View(family_Members.ToList());
        }

        // GET: Family_Member/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family_Member family_Member = db.Family_Members.Find(id);
            if (family_Member == null)
            {
                return HttpNotFound();
            }
            return View(family_Member);
        }

        // GET: Family_Member/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name");
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name");
            return View();
        }

        // POST: Family_Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FMID,PID,Relationship,HIV_Care,NIN")] Family_Member family_Member)
        {
            var query = db.Family_Members.Count() + 1;
            string temp = "FM-" + query;
            bool exist = false;
            try
            {
                var search = db.Family_Members.Where(c => c.FMID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;
            }
            if (exist)
            {
                var all = db.Family_Members.ToList();
                var fm = all.Last();
                family_Member.FMID = "FM-" + +DataModels.DataProcess.NextNumber(fm.FMID);
            }
            else
            {
                family_Member.FMID = temp;
            }
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(family_Member.NIN, family_Member.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Family Member can't be the same person");
                }
                else
                {
                    db.Family_Members.Add(family_Member);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               
            }

            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", family_Member.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", family_Member.PID);
            return View(family_Member);
        }

        // GET: Family_Member/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family_Member family_Member = db.Family_Members.Find(id);
            if (family_Member == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", family_Member.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", family_Member.PID);
            return View(family_Member);
        }

        // POST: Family_Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FMID,PID,Relationship,HIV_Care,NIN")] Family_Member family_Member)
        {
            if (ModelState.IsValid)
            {
                if (DataModels.DataProcess.ComparePatientWithNIN(family_Member.NIN, family_Member.PID) == true)
                {
                    ModelState.AddModelError("", "Patient and Family Member can't be the same person");
                }
                else
                {
                    db.Entry(family_Member).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }               
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "Full_Name", family_Member.NIN);
            ViewBag.PID = new SelectList(db.Patients, "PID", "Full_Name", family_Member.PID);
            return View(family_Member);
        }

        // GET: Family_Member/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family_Member family_Member = db.Family_Members.Find(id);
            if (family_Member == null)
            {
                return HttpNotFound();
            }
            return View(family_Member);
        }

        // POST: Family_Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Family_Member family_Member = db.Family_Members.Find(id);
            db.Family_Members.Remove(family_Member);
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
