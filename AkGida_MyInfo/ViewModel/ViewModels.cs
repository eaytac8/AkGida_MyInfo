using AkGida_MyInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkGida_MyInfo.ViewModel
{
    public class ViewModels
    {
        public List<Departments> Departmanlarim { get; set; } 
        public List<YemekSirketi> YemekSirketlerim { get; set; }
        public List<Duyurular> Duyurularim { get; set; }

    }
}