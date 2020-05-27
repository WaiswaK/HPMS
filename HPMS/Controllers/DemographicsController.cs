using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class DemographicsController : Controller
    {
        private Models.HPMS db = new Models.HPMS();

        // GET: Demographics
        public ActionResult Index()
        {
            var demographics = db.Demographics.Include(d => d.AspNetUser);
            return View(demographics.ToList());
        }

        // GET: Demographics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // GET: Demographics/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        // POST: Demographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village,Id,ImagePath")] Demographic demographic, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Check the exisitence of user ID in other records
                if (DataModels.DataProcess.Exists(demographic.Id))
                {

                }
                else
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        try
                        {
                            string ext = Path.GetExtension(upload.FileName).ToLower();
                            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                            {
                                var uploadpath = Path.Combine(Server.MapPath("~/Images/People"),
                                   demographic.ImagePath + ".jpg");
                                var path = @"~/Images/People" + @"/" + demographic.Id + ".jpg";
                                demographic.ImagePath = path;
                                upload.SaveAs(uploadpath);
                            }
                        }
                        catch(System.Exception ex)
                        {
                            string x = ex.ToString();
                            int xy = 0;
                        }
                        
                    }
                    db.Demographics.Add(demographic);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
            return View(demographic);
        }

        // GET: Demographics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
            return View(demographic);
        }

        // POST: Demographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIN,Given_Name,Midle_Name,Family_Name,Gender,Date_of_Birth,Address,Phone_Number,District,Division,Parish,Village,Id,ImagePath")] Demographic demographic, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    try
                    {
                        string ext = Path.GetExtension(upload.FileName).ToLower();
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                        {
                            var uploadpath = Path.Combine(Server.MapPath("~/Images/People"),
                               demographic.ImagePath + ".jpg");
                            var path = @"~/Images/People" + @"/" + demographic.Id + ".jpg";
                            demographic.ImagePath = path;
                            upload.SaveAs(uploadpath);
                        }
                    }
                    catch(System.Exception ex)
                    {
                        string x = ex.ToString();
                        int xy = 0;
                    }
                    
                }
                db.Entry(demographic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "UserName", demographic.Id);
            return View(demographic);
        }

        // GET: Demographics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demographic demographic = db.Demographics.Find(id);
            if (demographic == null)
            {
                return HttpNotFound();
            }
            return View(demographic);
        }

        // POST: Demographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Demographic demographic = db.Demographics.Find(id);
            db.Demographics.Remove(demographic);
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
