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
    public class CongratsYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: CongratsYonetim
        public ActionResult Index()
        {
            return View(db.Congrats.OrderByDescending(c => c.StartDate).ThenByDescending(s => s.EndDate).ToList());
        }


        // GET: CongratsYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongratsYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CongratsID,Name,Surname,ImagePath,StartDate,EndDate")] Congrats congrats, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    //Death vefat = new Death();
                    congrats.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";

                    if (ModelState.IsValid)
                    {
                        db.Congrats.Add(congrats);
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
                db.Congrats.Add(congrats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congrats);
        }

        // GET: CongratsYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congrats congrats = db.Congrats.Find(id);
            if (congrats == null)
            {
                return HttpNotFound();
            }
            return View(congrats);
        }

        // POST: CongratsYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CongratsID,Name,Surname,ImagePath,StartDate,EndDate")] Congrats congrats, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    congrats.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";


                    if (ModelState.IsValid)
                    {
                        db.Entry(congrats).State = EntityState.Modified;
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
            
            return View(congrats);
        }

        // GET: CongratsYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congrats congrats = db.Congrats.Find(id);
            if (congrats == null)
            {
                return HttpNotFound();
            }
            return View(congrats);
        }

        // POST: CongratsYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Congrats congrats = db.Congrats.Find(id);
            db.Congrats.Remove(congrats);
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
