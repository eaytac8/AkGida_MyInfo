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

        //public MenuCreate()
        //{
        //    this.YemekSirketiList = new List<SelectListItem>();
        //    YemekSirketiList.Add(new SelectListItem { Text = "Seçiniz..", Value = "" });
        //}

        public Companies company { get; set; }
        public Menu menu { get; set; }

        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> MenuList { get; set; }



        public Nullable<int> MenuID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
     
        public string Corba { get; set; }

        public string AnaYemek { get; set; }

        public string Diyet { get; set; }

        public string PilavMakarna { get; set; }

        public string Tatli { get; set; }

        public string Meyve { get; set; }

        public string Salata { get; set; }

        public virtual Companies Companies { get; set; }

    }
}