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
    public class PersonelYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: PersonelYonetim
        public ActionResult Index()
        {
            //düşünüyorum da bi dk.tamam
            var personels = db.Personels.Include(p => p.Departments).OrderBy(x => x.Departments.CompanyID).ThenBy(x => x.DepartmentID).ThenBy(x => x.PersonelName);
            return View(personels.ToList());
        }

        // GET: PersonelYonetim/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.Companies, "CompanyID", "CompanyName");
            //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        // POST: PersonelYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelID,PersonelName,PersonelSurname,PersonelTel,PersonelDahiliNo,PersonelEposta,DepartmentID,Yetki")] Personels personels)
        {
            if (ModelState.IsValid)
            {
                db.Personels.Add(personels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personels.DepartmentID);
            return View(personels);
        }

        // GET: PersonelYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personels personels = db.Personels.Find(id);
            if (personels == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personels.DepartmentID);
            return View(personels);
        }

        // POST: PersonelYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelID,PersonelName,PersonelSurname,PersonelTel,PersonelDahiliNo,PersonelEposta,DepartmentID,Yetki")] Personels personels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", personels.DepartmentID);
            return View(personels);
        }

        // GET: PersonelYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personels personels = db.Personels.Find(id);
            if (personels == null)
            {
                return HttpNotFound();
            }
            return View(personels);
        }

        public JsonResult DepartmanGetir(string CompName)
        {
            List<Departments> departmanlar = new List<Departments>();
            Companies companyObj = db.Companies.Where(x => x.CompanyName == CompName).FirstOrDefault();
            int compid = companyObj.CompanyID;
            departmanlar = db.Departments.Where(x => x.CompanyID == compid).ToList();

            return Json(departmanlar, JsonRequestBehavior.AllowGet);
        }

        // POST: PersonelYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personels personels = db.Personels.Find(id);
            db.Personels.Remove(personels);
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
