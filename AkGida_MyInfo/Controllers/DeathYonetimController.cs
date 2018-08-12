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
    public class DeathYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: DeathYonetim
        public ActionResult Index()
        {
            return View(db.Death.OrderByDescending(d => d.StartDate).ThenByDescending(d => d.EndDate).ToList());
        }


        // GET: DeathYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeathYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeathID,Name,Surname,ImagePath,StartDate,EndDate")] Death death, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    //Death vefat = new Death();
                    death.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";

                    if (ModelState.IsValid)
                    {
                        db.Death.Add(death);
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
                db.Death.Add(death);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(death);
        }

        // GET: DeathYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Death death = db.Death.Find(id);
            if (death == null)
            {
                return HttpNotFound();
            }
            return View(death);
        }

        // POST: DeathYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeathID,Name,Surname,ImagePath,StartDate,EndDate")] Death death, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    
                    death.ImagePath = $"/Images/{Path.GetFileName(file.FileName)}";


                    if (ModelState.IsValid)
                    {
                        db.Entry(death).State = EntityState.Modified;
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
           
            return View(death);
        }

        // GET: DeathYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Death death = db.Death.Find(id);
            if (death == null)
            {
                return HttpNotFound();
            }
            return View(death);
        }

        // POST: DeathYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Death death = db.Death.Find(id);
            db.Death.Remove(death);
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
