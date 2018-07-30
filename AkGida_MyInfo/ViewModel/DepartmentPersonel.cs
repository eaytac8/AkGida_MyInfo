using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AkGida_MyInfo.Models;

namespace AkGida_MyInfo.ViewModel
{
    public class DepartmentPersonel
    {
        public List<Personels> Personellerim { get; set; }
        public List<Departments> Departmanlarim { get; set; }
    }
}