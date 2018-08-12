using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;
using AkGida_MyInfo.ViewModel;

namespace AkGida_MyInfo.Controllers
{
    public class PersonelYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: PersonelYonetim
        public ActionResult Index()
        {
            var personel1 = db.Personels.Include(p => p.Departments).OrderBy(x => x.Departments.CompanyID).ThenBy(x => x.DepartmentID).ThenBy(x => x.PersonelName);
            return View(personel1.ToList());
        }
        
        // GET: PersonelYonetim/Create
        public ActionResult Create()
        {
            PersonelCreate model = new PersonelCreate();
            List<Companies> companyList = db.Companies.OrderBy(x => x.CompanyID).ToList();
            model.CompanyList = (from c in companyList
                                 select new SelectListItem
                                 {
                                     Text = c.CompanyName,
                                     Value = c.CompanyID.ToString()

                                 }).ToList();

            model.CompanyList.Insert(0, new SelectListItem { Text = "Seçiniz..", Value = "", Selected = true });

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "PersonelID,PersonelName,PersonelSurname,PersonelTel,PersonelDahiliNo,PersonelEposta,DepartmentID,Yetki")]*/ PersonelCreate personels)
        {
            if (ModelState.IsValid)
            {
                db.Personels.Add(personels.personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Company = new SelectList(db.Companies, "CompanyID", "CompanyName");
            PersonelCreate model = new PersonelCreate();
            List<Companies> companyList = db.Companies.OrderBy(x => x.CompanyID).ToList();
            model.CompanyList = (from c in companyList
                                 select new SelectListItem
                                 {
                                     Text = c.CompanyName,
                                     Value = c.CompanyID.ToString()

                                 }).ToList();

            model.CompanyList.Insert(0, new SelectListItem { Text = "Seçiniz..", Value = "", Selected = true });

            return View(model);
            
        }






        [HttpPost]
        public JsonResult DepartmentList(int id)
        {
            List<Departments> dprtmnList = db.Departments.Where(x => x.CompanyID == id).OrderBy(x => x.DepartmentName).ToList();

            List<SelectListItem> itemList = (from d in dprtmnList
                                             select new SelectListItem
                                             {
                                                 Text = d.DepartmentName,
                                                 Value = d.DepartmentID.ToString()
                                             }).ToList();

            return Json(itemList, JsonRequestBehavior.AllowGet);
        }



        // POST: PersonelYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

       






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
        public ActionResult Edit( /*[Bind(Include = "PersonelID,PersonelName,PersonelSurname,PersonelTel,PersonelDahiliNo,PersonelEposta,DepartmentID,Yetki")]*/ Personels personels)
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
