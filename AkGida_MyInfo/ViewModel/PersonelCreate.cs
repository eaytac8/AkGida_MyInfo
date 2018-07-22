using AkGida_MyInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkGida_MyInfo.ViewModel
{
    public class PersonelCreate
    {
        //Personel ekleme sayfasında Companies-Departments arasında Cascading DropdownList için;

        public PersonelCreate()
        {
            this.DepartmanList = new List<SelectListItem>();
            DepartmanList.Add(new SelectListItem { Text = "Seçiniz..", Value = "" });
        }
        
        public Companies company { get; set; }
        public Departments departman { get; set; }

        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> DepartmanList { get; set; }
        public Personels personel { get; set; }

        //[Display(Name = "Adı")]
        //public string PersonelName { get; set; }
        //[Display(Name = "Soyadı")]
        //public string PersonelSurname { get; set; }
        //[Display(Name = "Telefon")]
        //public string PersonelTel { get; set; }
        //[Display(Name = "Dahili No")]
        //public string PersonelDahiliNo { get; set; }
        //[Display(Name = "E-Posta")]
        //public string PersonelEposta { get; set; }
        //[Display(Name = "Departman Adı")]
        //public Nullable<int> DepartmentID { get; set; }
        //public Nullable<int> Yetki { get; set; }

   
    }
}