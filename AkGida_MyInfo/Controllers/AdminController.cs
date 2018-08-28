using AkGida_MyInfo.Admin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkGida_MyInfo.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        //public ActionResult Index()
        //{
        //    return RedirectToAction("Login", "Account");
        //    //return View();
        //}

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}