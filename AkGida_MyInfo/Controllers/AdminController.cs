using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkGida_MyInfo.Controllers
{
    public class AdminController : Controller
    {
        AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();

        // GET: Admin


        #region   // slider


        public ActionResult Slider()
        {
            
            return View();
        }

        public ActionResult SliderCreate()
        {
            return View();
        }

        public ActionResult SliderEdit()
        {
            return View();
        }

        public ActionResult SliderDelete()
        {
            return View();
        }

        #endregion    // slider




        #region //  Company


        public ActionResult CompanyCreate()
        {
            return View();
        }

        public ActionResult CompanyEdit()
        {
            return View();
        }

        public ActionResult CompanyDelete()
        {
            return View();
        }

        #endregion  // Company




        #region  // Department


        public ActionResult DepartmentCreate()
        {
            return View();
        }

        public ActionResult DepartmentEdit()
        {
            return View();
        }

        public ActionResult DepartmentDelete()
        {
            return View();
        }

        #endregion  // Department




        #region  // Duyuru


        public ActionResult DuyuruCreate()
        {
            return View();
        }

        public ActionResult DuyuruEdit()
        {
            return View();
        }

        public ActionResult DuyuruDelete()
        {
            return View();
        }

        #endregion  // Duyuru




        #region // Menu 


        public ActionResult MenuCreate()
        {
            return View();
        }

        public ActionResult MenuEdit()
        {
            return View();
        }

        public ActionResult MenuDelete()
        {
            return View();
        }

        #endregion  // Menu




        #region  // Personel


        public ActionResult PersonelCreate()
        {
            return View();
        }

        public ActionResult PersonelEdit()
        {
            return View();
        }

        public ActionResult PersonelDelete()
        {
            return View();
        }

        #endregion  // Personel




        #region  // Yemek Şirketi


        public ActionResult YemekSireketiCreate()
        {
            return View();
        }

        public ActionResult YemekSirketiEdit()
        {
            return View();
        }

        public ActionResult YemekSirketiDelete()
        {
            return View();
        }

        #endregion  // Yemek Şirketi

    }
}