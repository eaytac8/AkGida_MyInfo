using AkGida_MyInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkGida_MyInfo.ViewModel
{
    public class PersonelCreate
    {
        public Companies company { get; set; }
        public Departments departman { get; set; }
        public Personels personel { get; set; }
    }
}