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
        public List<Menu> Menulerim { get; set; }
        public List<Duyurular> Duyurularim { get; set; }
        public List<Personels> Personellerim { get; set; }
        public List<Servis> Servislerim { get; set; }
    }
}
