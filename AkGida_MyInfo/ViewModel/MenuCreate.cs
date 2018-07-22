using AkGida_MyInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkGida_MyInfo.ViewModel
{
    public class MenuCreate
    {
        // Menu ekleme sayfasında Companies-YemekSirketi arasında Cascading DropdownList için;

        public MenuCreate()
        {
            this.YemekSirketiList = new List<SelectListItem>();
            YemekSirketiList.Add(new SelectListItem { Text = "Seçiniz..", Value = "" });
        }

        public Companies company { get; set; }
        public YemekSirketi yemekSirketi { get; set; }

        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> YemekSirketiList { get; set; }


        
        public Nullable<int> YemekSirketiID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
     
        public string Corba1 { get; set; }
        
        public string Corba2 { get; set; }
      
        public string AnaYemek1 { get; set; }
        
        public string AnaYemek2 { get; set; }
   
        public string AnaYemek3 { get; set; }
       
        public string AnaYemek4 { get; set; }
        public string Ekstra { get; set; }
        public string Pilav { get; set; }
        public string Makarna { get; set; }
        public string Meyve { get; set; }
        public string Salata { get; set; }
        public Nullable<decimal> Fiyat { get; set; }

    }
}