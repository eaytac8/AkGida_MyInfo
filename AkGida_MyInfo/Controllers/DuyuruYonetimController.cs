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
    public class DuyuruYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: DuyuruYonetim
        public ActionResult Index()
        {
            return View(db.Duyurular.OrderBy(d => d.CompanyID).ThenByDescending(d => d.BaslangicTarihi).ThenByDescending(d => d.BitisTarihi).ToList());
        }

  

        // GET: DuyuruYonetim/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: DuyuruYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Duyurular duyurular, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    
                    duyurular.ResimYolu = $"~/Images/{Path.GetFileName(file.FileName)}";
                    
                    String dosyaadi = file.FileName;

                    if (ModelState.IsValid)
                    {
                        db.Duyurular.Add(duyurular);
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
                db.Duyurular.Add(duyurular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", duyurular.CompanyID);
            return View(duyurular);
        }

        // GET: DuyuruYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", duyurular.CompanyID);
            return View(duyurular);
        }

        // POST: DuyuruYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DuyuruID,Baslik,Icerik,BaslangicTarihi,BitisTarihi,ResimYolu, CompanyID")] Duyurular duyurular, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    Duyurular duyurum = new Duyurular();
                    duyurular.ResimYolu = $"~/Images/{Path.GetFileName(file.FileName)}";
                    
                    String dosyaadi = file.FileName;
                    
                    if (ModelState.IsValid)
                    {
                        db.Entry(duyurular).State = EntityState.Modified;
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

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", duyurular.CompanyID);

            return View(duyurular);
        }

        // GET: DuyuruYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyurular duyurular = db.Duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // POST: DuyuruYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duyurular duyurular = db.Duyurular.Find(id);
            db.Duyurular.Remove(duyurular);
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
