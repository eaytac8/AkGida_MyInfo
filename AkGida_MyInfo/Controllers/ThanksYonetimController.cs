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
    public class ThanksYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: ThanksYonetim
        public ActionResult Index()
        {
            return View(db.Thanks.OrderByDescending(t => t.StartDate).ThenByDescending(t => t.EndDate).ToList());
        }

 

        // GET: ThanksYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanksYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThanksID,Name,Surname,ImagePath,StartDate,EndDate")] Thanks thanks, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                   
                    thanks.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";

                    if (ModelState.IsValid)
                    {
                        db.Thanks.Add(thanks);
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
                db.Thanks.Add(thanks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanks);
        }

        // GET: ThanksYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thanks thanks = db.Thanks.Find(id);
            if (thanks == null)
            {
                return HttpNotFound();
            }
            return View(thanks);
        }

        // POST: ThanksYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThanksID,Name,Surname,ImagePath,StartDate,EndDate")] Thanks thanks, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    thanks.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";


                    if (ModelState.IsValid)
                    {
                        db.Entry(thanks).State = EntityState.Modified;
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

            return View(thanks);
        }

        // GET: ThanksYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thanks thanks = db.Thanks.Find(id);
            if (thanks == null)
            {
                return HttpNotFound();
            }
            return View(thanks);
        }

        // POST: ThanksYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thanks thanks = db.Thanks.Find(id);
            db.Thanks.Remove(thanks);
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
