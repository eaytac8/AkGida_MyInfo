using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;
using System.Data.SqlClient;
using AkGida_MyInfo.ViewModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AkGida_MyInfo.Controllers
{
    public class HomeController : Controller
    {
        AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();
        ViewModels modeller;

        public ActionResult Index()
        {
            CompanySlider companySlider = new CompanySlider();
            List<Companies> company = new List<Companies>();
            company = db.Companies.OrderBy(x => x.CompanyID).ToList();

            List<Slider> slider = new List<Slider>();
            slider = db.Slider.Where(x => (x.BaslangicTarihi <= DateTime.Today && x.BitisTarihi >= DateTime.Today)).ToList();

            List<YeniUrun> yeniurun = new List<YeniUrun>();
            yeniurun = db.YeniUrun.OrderBy(y => y.UrunID).ToList();
          
            companySlider.Companylerim = company;
            companySlider.Sliderlerim = slider;
            companySlider.YeniUrunlerim = yeniurun;

            return View(companySlider);
        }

        public ActionResult Departments(int? companyid)
        {
            modeller = new ViewModels();

            List<Departments> department = new List<Departments>();
            department = db.Departments.Where(x => x.CompanyID == companyid).OrderBy(x => x.CompanyID).ThenBy(x => x.DepartmentName).ToList();

            List<Duyurular> duyurular = new List<Duyurular>();
            duyurular = db.Duyurular.Where(T => T.CompanyID == companyid && T.BaslangicTarihi <= DateTime.Now && T.BitisTarihi >= DateTime.Now).ToList();


            List<Menu> menu = new List<Menu>();
            var dateAndTime = DateTime.Today;
            var date = dateAndTime.Date;
            menu = db.Menu.Where(T => T.CompanyID == companyid && T.Tarih == date).ToList();

            List<Personels> personel = new List<Personels>();
            personel = db.Personels.Where(T => T.Departments.CompanyID == companyid).ToList();

            List<Servis> servis = new List<Servis>();
            servis = db.Servis.Where(S => S.CompanyID == companyid).OrderBy(S => S.SoforAdi).ThenBy(S => S.SoforSoyadi).ToList();

            modeller.Duyurularim = duyurular;
            modeller.Departmanlarim = department;
            modeller.Menulerim = menu;
            modeller.Personellerim = personel;
            modeller.Servislerim = servis;

            return View(modeller);
        }

        public JsonResult Menu(int? companyidd)
        {
            List<Menu> menu = new List<Menu>();
            menu = db.Menu.Where(x => x.CompanyID == companyidd).ToList();

            return Json(menu, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Birthday()
        {
            List<Personels> personel = new List<Personels>();

            personel = db.Personels.Where(B => B.Birthday.Value.Day == DateTime.Now.Day && B.Birthday.Value.Month == DateTime.Now.Month).ToList();


            return PartialView("Birthday", personel);
        }

        public PartialViewResult BabyPartial()
        {
            List<Baby> baby = new List<Baby>();
            baby = db.Baby.Where(B => (B.StartDate <= DateTime.Today && B.EndDate >= DateTime.Today)).ToList();
            return PartialView(baby);
        }

        public PartialViewResult DeathPartial()
        {
            List<Death> death = new List<Death>();
            death = db.Death.Where(B => B.StartDate <= DateTime.Today && B.EndDate >= DateTime.Today).ToList();
            return PartialView(death);
        }

        public PartialViewResult CongratsPartial()
        {
            List<Congrats> congrats = new List<Congrats>();
            congrats = db.Congrats.Where(B => B.StartDate <= DateTime.Today && B.EndDate >= DateTime.Today).ToList();
            return PartialView(congrats);
        }

        public PartialViewResult ThanksPartial()
        {
            List<Thanks> thanks = new List<Thanks>();
            thanks = db.Thanks.Where(B => B.StartDate <= DateTime.Today && B.EndDate >= DateTime.Today).ToList();
            return PartialView(thanks);
        }

        public PartialViewResult WeddingsPartial()
        {
            List<Weddings> weddings = new List<Weddings>();
            weddings = db.Weddings.Where(B => B.StartDate <= DateTime.Today && B.EndDate >= DateTime.Today).ToList();
            return PartialView(weddings);
        }

        public ActionResult YeniUrun()
        {
            List<YeniUrun> yeniurun = new List<YeniUrun>();
            yeniurun = db.YeniUrun.OrderBy(y => y.UrunID).ToList();
            return View(yeniurun);
        }

        public ActionResult Search(string searchString)
        {
            var personel = from p in db.Personels
                         select p;
            if(!String.IsNullOrEmpty(searchString))
                {
                personel = personel.Where(x => x.PersonelName.Contains(searchString) || x.PersonelSurname.Contains(searchString));

                }
            else
            {
                ViewBag.personelYok = "Personel bulunamadı.";
            }

            return View(personel);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Deneme()
        {
            return View();
        }

    }

}





//public JsonResult PartialPers(int? departmanid)
//{
//    List<Personels> personeller = new List<Personels>();
//    personeller = db.Personels.Where(x => x.DepartmentID == departmanid).ToList();

//    List<Personels> Obj_personel = new List<Personels>();
//    Personels personels;
//    using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
//    {
//        SqlCommand command = new SqlCommand($"Select * from Personels Where [DepartmentID] = {departmanid} Order By PersonelName", connection);
//        connection.Open();
//        SqlDataReader reader = command.ExecuteReader();

//        try
//        {
//            while (reader.Read())
//            {
//                personels = new Personels();
//                personels.PersonelName = reader.GetString(1);
//                personels.PersonelSurname = reader.GetString(2);
//                personels.Corbus = reader.GetString(3);
//                personels.PersonelDahiliNo = reader.GetString(4);
//                personels.PersonelTel = reader.GetString(5);
//                personels.PersonelEposta = reader.GetString(6);
//                personels.Birthday = reader.GetDateTime(8);
//                Obj_personel.Add(personels);
//                Console.WriteLine("Personel Adı:" + personels.PersonelName);
//            }
//        }
//        finally
//        {
//            reader.Close();

//        }
//        connection.Close();
//    }

//    return Json(Obj_personel, JsonRequestBehavior.AllowGet);

//}



//List<Companies> company = new List<Companies>();
//Companies comp;
//using (connection)
//{
//    SqlCommand command = new SqlCommand(
// "Select * from Companies", connection);
//    connection.Open();
//    SqlDataReader reader = command.ExecuteReader();
//    try
//    {//"Insert Into Users(name,username) Values("Ali","aliasdsa")"
//        while (reader.Read())
//        {
//            comp = new Companies();
//            comp.CompanyID = reader.GetInt32(0);
//            comp.CompanyName = reader.GetString(1);
//            comp.CompanyAddress = reader.GetString(2);
//            comp.CompanyType = reader.GetString(3);
//            comp.CompanyTel = reader.GetString(4);
//            company.Add(comp);
//            //Console.WriteLine("sdasdasda");
//            Console.WriteLine("Şirketin tipi:"+comp.CompanyType);
//        }
//    }
//    finally
//    {
//        // Always call Close when done reading.
//        reader.Close();
//    }
//    connection.Close();
//}






//public JsonResult PartialPers(int? departmanid)
//{
//    //modeller = new ViewModels();
//    List<Personels> personeller = new List<Personels>();
//    personeller = db.Personels.Where(x => x.DepartmentID == departmanid).ToList();
//    //modeller.Personellerim = personeller;
//    return Json(modeller, JsonRequestBehavior.AllowGet);

//}



/* Personel Veri Tabanından veri çekme..*/

//List<Personels> Obj_personel = new List<Personels>();
//Personels personels;
//            using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
//            {
//                SqlCommand command = new SqlCommand($"Select * from Personels Where [DepartmentID] = {departmanid}", connection);
//connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                try
//                {
//                    while (reader.Read())
//                    {
//                        personels = new Personels();
//personels.PersonelName = reader.GetString(1);
//                        personels.PersonelSurname = reader.GetString(2);
//                        personels.PersonelTel = reader.GetString(3);
//                        personels.PersonelDahiliNo = reader.GetString(4);
//                        personels.PersonelEposta = reader.GetString(5);
//                        Obj_personel.Add(personels);
//                        Console.WriteLine("Personel Adı:" + personels.PersonelName);
//                    }
//                }
//                finally
//                {
//                    reader.Close();

//                }
//                connection.Close();
//            }
//            ViewBag.Durum = "Personel";
//            ViewBag.Pers = Obj_personel;

//            return PartialView("PersonelPatialView", Obj_personel);