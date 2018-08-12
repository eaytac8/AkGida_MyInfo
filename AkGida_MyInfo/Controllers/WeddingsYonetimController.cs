using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;

namespace AkGida_MyInfo.Controllers
{
    public class WeddingsYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: WeddingsYonetim
        public ActionResult Index()
        {
            return View(db.Weddings.OrderByDescending(w => w.StartDate).ThenByDescending(w => w.EndDate).ToList());
        }

        // GET: WeddingsYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeddingsYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeddingID,Name,Surname,ImagePath,StartDate,EndDate")] Weddings weddings, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    weddings.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";

                    if (ModelState.IsValid)
                    {
                        db.Weddings.Add(weddings);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            if (ModelState.IsValid)
            {
                db.Weddings.Add(weddings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weddings);
        }

        // GET: WeddingsYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weddings weddings = db.Weddings.Find(id);
            if (weddings == null)
            {
                return HttpNotFound();
            }
            return View(weddings);
        }

        // POST: WeddingsYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeddingID,Name,Surname,ImagePath,StartDate,EndDate")] Weddings weddings, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    weddings.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";


                    if (ModelState.IsValid)
                    {
                        db.Entry(weddings).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

          
            return View(weddings);
        }

        // GET: WeddingsYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weddings weddings = db.Weddings.Find(id);
            if (weddings == null)
            {
                return HttpNotFound();
            }
            return View(weddings);
        }

        // POST: WeddingsYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weddings weddings = db.Weddings.Find(id);
            db.Weddings.Remove(weddings);
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
