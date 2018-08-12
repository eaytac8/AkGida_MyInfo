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
    public class BabyYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: BabyYonetim
        public ActionResult Index()
        {
            return View(db.Baby.OrderByDescending(b => b.StartDate).ThenByDescending(b => b.EndDate).ToList());
        }


        // GET: BabyYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BabyYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BabyID,Name,Surname,ImagePath,StartDate,EndDate")] Baby baby, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    //Baby bebek = new Baby();
                    baby.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";
                    
                    if (ModelState.IsValid)
                    {
                        db.Baby.Add(baby);
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
                db.Baby.Add(baby);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(baby);
        }

        // GET: BabyYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baby baby = db.Baby.Find(id);
            if (baby == null)
            {
                return HttpNotFound();
            }
            return View(baby);
        }

        // POST: BabyYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BabyID,Name,Surname,ImagePath,StartDate,EndDate")] Baby baby, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    Baby bebek = new Baby();
                    baby.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";


                    if (ModelState.IsValid)
                    {
                        db.Entry(baby).State = EntityState.Modified;
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
           
            return View(baby);
        }

        // GET: BabyYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Baby baby = db.Baby.Find(id);
            if (baby == null)
            {
                return HttpNotFound();
            }
            return View(baby);
        }

        // POST: BabyYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Baby baby = db.Baby.Find(id);
            db.Baby.Remove(baby);
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
