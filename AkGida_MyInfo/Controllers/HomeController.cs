using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkGida_MyInfo.Models;
using System.Data.SqlClient;


namespace AkGida_MyInfo.Controllers
{
    public class HomeController : Controller
    {
        AkGida_MyInfoEntities db = new AkGida_MyInfoEntities();


        public ActionResult Index()
        {
            List<Companies> company=new List<Companies>();
            Companies comp;

            using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                SqlCommand command = new SqlCommand(
             "Select * from Companies", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {//"Insert Into Users(name,username) Values("Ali","aliasdsa")"
                    while (reader.Read())
                    {
                        comp = new Companies();
                        comp.CompanyID = reader.GetInt32(0);
                        comp.CompanyName = reader.GetString(1);
                        comp.CompanyAddress = reader.GetString(2);
                        comp.CompanyType = reader.GetString(3);
                        comp.CompanyTel = reader.GetString(4);
                        company.Add(comp);
                        //Console.WriteLine("sdasdasda");
                        Console.WriteLine("Şirketin tipi:"+comp.CompanyType);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                connection.Close();
            }

            return View(company);
        }


        public ActionResult Departments(int? companyid)
        {
            List<Departments> department = new List<Departments>();
            Departments dprmnt;

            using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                SqlCommand command = new SqlCommand($"Select * from Departments Where CompanyId = {companyid}",connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while(reader.Read())
                    {
                        dprmnt = new Departments();
                        dprmnt.DepartmentName = reader.GetString(1);
                        department.Add(dprmnt);
                        Console.WriteLine("Department Adı:" + dprmnt.DepartmentName);
                    }
                }
                finally
                {
                    reader.Close();
                    
                }
                connection.Close();
            }
            
            return View(department);
        }



        public ActionResult Personels(int? departmentid)
        {
            List<Personels> personel = new List<Personels>();
            Personels prsnl;

            using (SqlConnection connection = new SqlConnection(@"Data Source=MININT-UL27J5C\SQLEXPRESS;Initial Catalog=AkGida_MyInfo;User ID=sa;Password=Ea123456;MultipleActiveResultSets=True;Application Name=EntityFramework"))
            {
                SqlCommand command = new SqlCommand(
                    $"Select * from Personels Where DepartmentID = {departmentid}", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        prsnl = new Personels();
                        prsnl.PersonelName = reader.GetString(1);
                        prsnl.PersonelSurname = reader.GetString(2);
                        prsnl.PersonelTel = reader.GetString(3);
                        prsnl.PersonelDahiliNo = reader.GetInt32(4).ToString();
                        prsnl.PersonelEposta = reader.GetString(5);
                        personel.Add(prsnl);
                        Console.WriteLine("Personel Adı:" + prsnl.PersonelName);
                    }
                }
                finally
                {
                    reader.Close();

                }

            }
            return View(personel);
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

    public class AnasayfaDTO
    {
        public List<Slider> slider { get; set; }
        public List<Duyurular> duyuru { get; set; }
        public List<Companies> company { get; set; }
        //public List<Slider> slider { get; set; }
        //public List<Slider> slider { get; set; }
        //public List<Slider> slider { get; set; }

    }
}