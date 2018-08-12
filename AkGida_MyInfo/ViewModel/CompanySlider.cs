using AkGida_MyInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkGida_MyInfo.ViewModel
{
    public class CompanySlider
    {
        public List<Slider> Sliderlerim { get; set; }
        public List<Companies> Companylerim { get; set; }
        public List<YeniUrun> YeniUrunlerim { get; set; }
    }
}