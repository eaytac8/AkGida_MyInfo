﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkGida_MyInfo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Thanks
    {
        public int ThanksID { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [Display(Name = "Resin Yolu")]
        public string ImagePath { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
