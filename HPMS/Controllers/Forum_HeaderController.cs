using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Forum_HeaderController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Forum_Header
        public ActionResult Index()
        {
            var forum_Headers = db.Forum_Headers.Include(f => f.Demographic);
            return View(forum_Headers.ToList());
        }

        // GET: Forum_Header/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Header forum_Header = db.Forum_Headers.Find(id);
            if (forum_Header == null)
            {
                return HttpNotFound();
            }
            return View(forum_Header);
        }

        // GET: Forum_Header/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath");
            return View();
        }

        // POST: Forum_Header/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Topic,NIN")] Forum_Header forum_Header)
        {
            var query = db.Forum_Headers.Count() + 1;
            string temp = "FH-" + query;
            bool exist = false;
            try
            {
                var search = db.Forum_Headers.Where(c => c.ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Forum_Headers.ToList();
                var forum = all.Last();
                forum.ID = "FH-" + DataModels.DataProcess.NextNumber(forum.ID);
            }
            else
            {
                forum_Header.ID= temp;
            }
            if (ModelState.IsValid)
            {
                db.Forum_Headers.Add(forum_Header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Header.NIN);
            return View(forum_Header);
        }

        // GET: Forum_Header/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Header forum_Header = db.Forum_Headers.Find(id);
            if (forum_Header == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Header.NIN);
            return View(forum_Header);
        }

        // POST: Forum_Header/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Topic,NIN")] Forum_Header forum_Header)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_Header).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Header.NIN);
            return View(forum_Header);
        }

        // GET: Forum_Header/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Header forum_Header = db.Forum_Headers.Find(id);
            if (forum_Header == null)
            {
                return HttpNotFound();
            }
            return View(forum_Header);
        }

        // POST: Forum_Header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Forum_Header forum_Header = db.Forum_Headers.Find(id);
            db.Forum_Headers.Remove(forum_Header);
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
