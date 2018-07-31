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
    public class MenuYonetimController : Controller
    {
        private AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: MenuYonetim
        public ActionResult Index()
        {
            var menu = db.Menu.Include(m => m.Companies);
            return View(menu.OrderBy(x => x.CompanyID).ThenBy(x => x.Tarih).ToList());
        }


        // GET: MenuYonetim/Create
        public ActionResult Create()
        {
            //MenuCreate model = new MenuCreate();
            //List<Companies> companyList = db.Companies.OrderBy(x => x.CompanyID).ToList();
            //model.CompanyList = (from c in companyList
            //                     select new SelectListItem
            //                     {
            //                         Text = c.CompanyName,
            //                         Value = c.CompanyID.ToString()

            //                     }).ToList();

            //model.CompanyList.Insert(0, new SelectListItem { Text = "Seçiniz..", Value = "", Selected = true });

            //return View(model);

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();

        }

        //[HttpPost]
        //public ActionResult Create(int CompanyID)
        //{
        //    return RedirectToAction("Create", "MenuYonetim");
        //}

        //[HttpPost]
        //public JsonResult YemekSirketiList(int id)
        //{
        //    List<YemekSirketi> ySirList = db.YemekSirketi.Where(x => x.CompanyID==id).OrderBy(x => x.YemekSirketiAdi).ToList();

        //    List<SelectListItem> itemList = (from y in ySirList
        //                                    select new SelectListItem
        //                                    {
        //                                        Text = y.YemekSirketiAdi,
        //                                        Value = y.YemekSirketiID.ToString()
        //                                    }).ToList();

        //    return Json(itemList,JsonRequestBehavior.AllowGet);
        //}



        // POST: MenuYonetim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "MenuID,YemekSirketiID,Tarih,Corba1,Corba2,AnaYemek1,AnaYemek2,AnaYemek3,AnaYemek4,Ekstra,Pilav,Makarna,Meyve,Salata,Fiyat")]*/ Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menu.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", menu.CompanyID);
            return View(menu);
        }

        // GET: MenuYonetim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", menu.CompanyID);
            return View(menu);
        }

        // POST: MenuYonetim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "MenuID,YemekSirketiID,Tarih,Corba1,Corba2,AnaYemek1,AnaYemek2,AnaYemek3,AnaYemek4,Ekstra,Pilav,Makarna,Meyve,Salata,Fiyat")]*/ Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", menu.CompanyID);
            return View(menu);
        }

        // GET: MenuYonetim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: MenuYonetim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menu.Find(id);
            db.Menu.Remove(menu);
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
