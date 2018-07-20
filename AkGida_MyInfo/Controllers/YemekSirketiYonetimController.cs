using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;

namespace AkGida_MyInfo.Controllers
{
    public class YemekSirketiYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: YemekSirketiYonetim
        public ActionResult Index()
        {
            var yemekSirketi = db.YemekSirketi.Include(y => y.Companies);
            return View(yemekSirketi.OrderBy(x => x.CompanyID).ThenBy(x => x.YemekSirketiAdi).ToList());
        }


        // GET: YemekSirketiYonetim/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: YemekSirketiYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YemekSirketiID,YemekSirketiAdi,CompanyID")] YemekSirketi yemekSirketi)
        {
            if (ModelState.IsValid)
            {
                db.YemekSirketi.Add(yemekSirketi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", yemekSirketi.CompanyID);
            return View(yemekSirketi);
        }

        // GET: YemekSirketiYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YemekSirketi yemekSirketi = db.YemekSirketi.Find(id);
            if (yemekSirketi == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", yemekSirketi.CompanyID);
            return View(yemekSirketi);
        }

        // POST: YemekSirketiYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YemekSirketiID,YemekSirketiAdi,CompanyID")] YemekSirketi yemekSirketi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yemekSirketi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", yemekSirketi.CompanyID);
            return View(yemekSirketi);
        }

        // GET: YemekSirketiYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YemekSirketi yemekSirketi = db.YemekSirketi.Find(id);
            if (yemekSirketi == null)
            {
                return HttpNotFound();
            }
            return View(yemekSirketi);
        }

        // POST: YemekSirketiYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YemekSirketi yemekSirketi = db.YemekSirketi.Find(id);
            db.YemekSirketi.Remove(yemekSirketi);
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
