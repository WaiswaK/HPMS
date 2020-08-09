using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class Forum_CommentController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Forum_Comment
        public ActionResult Index()
        {
            var forum_Comments = db.Forum_Comments.Include(f => f.Demographic).Include(f => f.Forum_Header);
            return View(forum_Comments.ToList());
        }

        // GET: Forum_Comment/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Comment forum_Comment = db.Forum_Comments.Find(id);
            if (forum_Comment == null)
            {
                return HttpNotFound();
            }
            return View(forum_Comment);
        }

        // GET: Forum_Comment/Create
        public ActionResult Create()
        {
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath");
            ViewBag.Forum_ID = new SelectList(db.Forum_Headers, "ID", "Topic");
            return View();
        }

        // POST: Forum_Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Forum_ID,NIN,Comment")] Forum_Comment forum_Comment)
        {
            var query = db.Forum_Comments.Count() + 1;
            string temp = "FC-" + query;
            bool exist = false;
            try
            {
                var search = db.Forum_Comments.Where(c => c.ID == temp).Single();
                exist = true;
            }
            catch
            {
                exist = false;

            }
            if (exist)
            {
                var all = db.Forum_Comments.ToList();
                var fcomment = all.Last();
                fcomment.ID = "DIET-" + DataModels.DataProcess.NextNumber(fcomment.ID);
            }
            else
            {
                forum_Comment.ID = temp;
            }
            if (ModelState.IsValid)
            {
                db.Forum_Comments.Add(forum_Comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Comment.NIN);
            ViewBag.Forum_ID = new SelectList(db.Forum_Headers, "ID", "Topic", forum_Comment.Forum_ID);
            return View(forum_Comment);
        }

        // GET: Forum_Comment/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Comment forum_Comment = db.Forum_Comments.Find(id);
            if (forum_Comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Comment.NIN);
            ViewBag.Forum_ID = new SelectList(db.Forum_Headers, "ID", "Topic", forum_Comment.Forum_ID);
            return View(forum_Comment);
        }

        // POST: Forum_Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Forum_ID,NIN,Comment")] Forum_Comment forum_Comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_Comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NIN = new SelectList(db.Demographics, "NIN", "ImagePath", forum_Comment.NIN);
            ViewBag.Forum_ID = new SelectList(db.Forum_Headers, "ID", "Topic", forum_Comment.Forum_ID);
            return View(forum_Comment);
        }

        // GET: Forum_Comment/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_Comment forum_Comment = db.Forum_Comments.Find(id);
            if (forum_Comment == null)
            {
                return HttpNotFound();
            }
            return View(forum_Comment);
        }

        // POST: Forum_Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Forum_Comment forum_Comment = db.Forum_Comments.Find(id);
            db.Forum_Comments.Remove(forum_Comment);
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
