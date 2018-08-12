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
    public class YeniUrunYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: YeniUrunYonetim
        public ActionResult Index()
        {
            return View(db.YeniUrun.ToList());
        }

        // GET: YeniUrunYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YeniUrunYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunID,UrunAdi,Tanitim,ResimYolu, VideoYolu")] YeniUrun yeniUrun, HttpPostedFileBase file, HttpPostedFileBase video)
        {
            if (file != null && file.ContentLength > 0 && video!=null && video.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));

                    string vPath = Path.Combine(Server.MapPath("/Video"),
                                                Path.GetFileName(video.FileName));
                    file.SaveAs(path);
                    video.SaveAs(vPath);
                    ViewBag.Message = "File uploaded successfully";

                    yeniUrun.ResimYolu = $"/Images/{Path.GetFileName(file.FileName)}";
                    yeniUrun.VideoYolu = $"/Video/{ Path.GetFileName(video.FileName)}";
                    String dosyaadi = file.FileName;

                    if (ModelState.IsValid)
                    {
                        db.YeniUrun.Add(yeniUrun);
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
                db.YeniUrun.Add(yeniUrun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yeniUrun);
        }

        // GET: YeniUrunYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeniUrun yeniUrun = db.YeniUrun.Find(id);
            if (yeniUrun == null)
            {
                return HttpNotFound();
            }
            return View(yeniUrun);
        }

        // POST: YeniUrunYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunID,UrunAdi,Tanitim,ResimYolu, VideoYolu")] YeniUrun yeniUrun, HttpPostedFileBase file, HttpPostedFileBase video)
        {
            if (file != null && file.ContentLength > 0 && video != null && video.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Images"),
                                               Path.GetFileName(file.FileName));

                    string vPath = Path.Combine(Server.MapPath("/Video"),
                                               Path.GetFileName(video.FileName));
                    file.SaveAs(path);
                    video.SaveAs(vPath);
                    ViewBag.Message = "File uploaded successfully";
                    
                    yeniUrun.ResimYolu = $"/Images/{Path.GetFileName(file.FileName)}";
                    yeniUrun.VideoYolu = $"/Video/{ Path.GetFileName(video.FileName)}";

                    String dosyaadi = file.FileName;

                    if (ModelState.IsValid)
                    {
                        db.Entry(yeniUrun).State = EntityState.Modified;
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
           
            return View(yeniUrun);
        }

        // GET: YeniUrunYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeniUrun yeniUrun = db.YeniUrun.Find(id);
            if (yeniUrun == null)
            {
                return HttpNotFound();
            }
            return View(yeniUrun);
        }

        // POST: YeniUrunYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YeniUrun yeniUrun = db.YeniUrun.Find(id);
            db.YeniUrun.Remove(yeniUrun);
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
