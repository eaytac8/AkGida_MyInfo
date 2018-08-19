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
    public class YayinlarYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: YayinlarYonetim
        public ActionResult Index()
        {
            return View(db.Yayinlar.OrderBy(y => y.YayinID).ToList());
        }


        // GET: YayinlarYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YayinlarYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YayinID,YayinBaslik,YayinURL")] Yayinlar yayinlar, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Documents"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";

                    yayinlar.YayinURL = $"/Documents/{Path.GetFileName(file.FileName)}";

                    String dosyaadi = file.FileName;

                    if (ModelState.IsValid)
                    {
                        db.Yayinlar.Add(yayinlar);
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
                db.Yayinlar.Add(yayinlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yayinlar);
        }

        // GET: YayinlarYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayinlar yayinlar = db.Yayinlar.Find(id);
            if (yayinlar == null)
            {
                return HttpNotFound();
            }
            return View(yayinlar);
        }

        // POST: YayinlarYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YayinID,YayinBaslik,YayinURL")] Yayinlar yayinlar, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("/Documents"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    Duyurular duyurum = new Duyurular();
                    yayinlar.YayinURL = $"/Documents/{Path.GetFileName(file.FileName)}";

                    String dosyaadi = file.FileName;

                    if (ModelState.IsValid)
                    {
                        db.Entry(yayinlar).State = EntityState.Modified;
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
           
            return View(yayinlar);
        }

        // GET: YayinlarYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayinlar yayinlar = db.Yayinlar.Find(id);
            if (yayinlar == null)
            {
                return HttpNotFound();
            }
            return View(yayinlar);
        }

        // POST: YayinlarYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yayinlar yayinlar = db.Yayinlar.Find(id);
            db.Yayinlar.Remove(yayinlar);
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
