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
    public class GenelDuyuruYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: GenelDuyuruYonetim
        public ActionResult Index()
        {
            return View(db.Slider.OrderByDescending(s => s.BaslangicTarihi).ThenByDescending(s => s.BitisTarihi).ToList());
        }

        // GET: GenelDuyuruYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenelDuyuruYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "SliderID,SliderFoto,SliderText,BaslangicTarihi,BitisTarihi,ResimYolu")]*/ Slider slider,HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    Slider sliderim = new Slider();
                    slider.ResimYolu = $"~/Images/{Path.GetFileName(file.FileName)}";
                   

                    if (ModelState.IsValid)
                    {
                        db.Slider.Add(slider);
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
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: GenelDuyuruYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: GenelDuyuruYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderID,SliderFoto,SliderBaslik,SliderText,BaslangicTarihi,BitisTarihi,ResimYolu")] Slider slider, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    Slider sliderim = new Slider();
                    slider.ResimYolu = $"~/Images/{Path.GetFileName(file.FileName)}";
                    //slider.ResimYolu = $"~/Images/{file.FileName}";
                    String dosyaadi = file.FileName;

                    //sliderim.ResimYolu = path;
                    //sliderim.BitisTarihi = slider.BitisTarihi;
                    //sliderim.BaslangicTarihi = slider.BaslangicTarihi;
                    //sliderim.SliderText = slider.SliderText;


                    //if (ModelState.IsValid)
                    //{
                    //    db.Slider.Add(slider);
                    //    db.SaveChanges();
                    //    return RedirectToAction("Index");
                    //}

                    if (ModelState.IsValid)
                    {
                        db.Entry(slider).State = EntityState.Modified;
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

            //if (ModelState.IsValid)
            //{
            //    db.Entry(slider).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(slider);
        }

        // GET: GenelDuyuruYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: GenelDuyuruYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            db.Slider.Remove(slider);
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
