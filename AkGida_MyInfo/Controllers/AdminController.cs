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
            //if(SignInStatus.Success)
            //{

            //}
            return View();
        }

        //public ActionResult Login(LoginViewModel login)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        //        var authManager = HttpContext.GetOwinContext().Authentication;

        //        AppUser user = userManager.Find(login.UserName, login.Password);
        //        if(user!=null)
        //        {
        //            var ident = userManager.CreateIdentity(user,
        //                DefaultAuthenticationTypes.ApplicationCookie);
        //            authManager.SignIn(
        //                new Microsoft.Owin.Security.AuthenticationProperties { IsPersistent = false }, ident);
        //            return Redirect(login.ReturnUrl ?? Url.Action("Index", "Admin"));
        //        }
        //    }
        //    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");

        //    return View(login);
        //}

        //public ActionResult CreateRole(string roleName)
        //{
        //    var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

        //    if (!roleManager.RoleExists(roleName))
        //        roleManager.Create(new AppRole(roleName));
        //    return View();
        //}
    }
}