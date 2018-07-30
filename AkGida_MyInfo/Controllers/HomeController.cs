using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;
using System.Data.SqlClient;
using AkGida_MyInfo.ViewModel;


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
            slider = db.Slider.Where(x => (x.BaslangicTarihi<=DateTime.Now && x.BitisTarihi>DateTime.Now)).ToList();

            companySlider.Companylerim = company;
            companySlider.Sliderlerim = slider;

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

            return View(companySlider);
        }


        public ActionResult Departments(int? companyid)
        {
            modeller = new ViewModels();

            List<Departments> department = new List<Departments>();
            department = db.Departments.Where(x => x.CompanyID == companyid).OrderBy(x => x.CompanyID).ThenBy(x => x.DepartmentName).ToList();

            

            List<Duyurular> duyurular = new List<Duyurular>();
            Duyurular duyuru;
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
                {
                    SqlCommand command = new SqlCommand($"SELECT D.DuyuruID,D.Baslik,D.DuyuruTarih,D.Icerik,CD.CompanyDuyuruID,C.CompanyID FROM Duyurular as D " +
                        "INNER JOIN CompanyDuyuru as CD ON  CD.CompanyDuyuruID= D.DuyuruID INNER JOIN Companies as C" +
     $"   ON C.CompanyID = CD.CompanyDuyuruID WHERE C.CompanyID = {companyid}", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            duyuru = new Duyurular();
                            duyuru.DuyuruID = reader.GetInt32(0);
                            duyuru.Baslik = reader.GetString(1);
                            duyuru.Icerik = reader.GetString(3);
                            duyuru.DuyuruTarih = reader.GetDateTime(2);
                            duyurular.Add(duyuru);
                        }
                    }
                    finally
                    {
                        reader.Close();

                    }
                    connection.Close();
                }

                List<YemekSirketi> yemekSirketi = new List<YemekSirketi>();
                yemekSirketi = db.YemekSirketi.Where(T => T.CompanyID == companyid).ToList();

                modeller.Duyurularim = duyurular;
                modeller.Departmanlarim = department;
                modeller.YemekSirketlerim = yemekSirketi;
                
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return View(modeller);
        }

        public JsonResult PartialPers(int? departmanid)
        {
            List<Personels> personeller = new List<Personels>();
            personeller = db.Personels.Where(x => x.DepartmentID == departmanid).ToList();

            List<Personels> Obj_personel = new List<Personels>();
            Personels personels;
            using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                SqlCommand command = new SqlCommand($"Select * from Personels Where [DepartmentID] = {departmanid} Order By PersonelName", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        personels = new Personels();
                        personels.PersonelName = reader.GetString(1);
                        personels.PersonelSurname = reader.GetString(2);
                        personels.PersonelTel = reader.GetString(3);
                        personels.PersonelDahiliNo = reader.GetString(4);
                        personels.PersonelEposta = reader.GetString(5);
                        Obj_personel.Add(personels);
                        Console.WriteLine("Personel Adı:" + personels.PersonelName);
                    }
                }
                finally
                {
                    reader.Close();

                }
                connection.Close();
            }

            return Json(Obj_personel, JsonRequestBehavior.AllowGet);

        }


        //public JsonResult PartialPers(int? departmanid)
        //{
        //    //modeller = new ViewModels();
        //    List<Personels> personeller = new List<Personels>();
        //    personeller = db.Personels.Where(x => x.DepartmentID == departmanid).ToList();
        //    //modeller.Personellerim = personeller;
        //    return Json(modeller, JsonRequestBehavior.AllowGet);

        //}


        public JsonResult YemekSirketi(int? companyidd)
        {
            List<YemekSirketi> yemeksirketi = new List<YemekSirketi>();
            yemeksirketi = db.YemekSirketi.Where(x => x.CompanyID == companyidd).ToList();

            return Json(yemeksirketi, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Menu(int? yemeksirketiid)
        {
            List<Menu> menu = new List<Menu>();
            menu = db.Menu.Where(x => x.YemekSirketiID == yemeksirketiid).ToList();
            return View(menu);
        }


        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Companies()
        //{
        //    //ViewBag.Message = "Your contact page.";

        //    return View();
        //}

    }

    //public class AnasayfaDTO
    //{
    //    public List<Companies> Companylerim{ get; set; }
    //    public List<Slider> Sliderlerim { get; set; }
    //    public List<Duyurular> duyuru { get; set; }
    //    public List<Companies> company { get; set; }
    //    //public List<Slider> slider { get; set; }
    //    //public List<Slider> slider { get; set; }
    //    //public List<Slider> slider { get; set; }
    //}
}

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