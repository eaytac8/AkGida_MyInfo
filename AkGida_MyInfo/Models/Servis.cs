
//------------------------------------------------------------------------------
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
    
public partial class Servis
{

    public int ServisID { get; set; }

    public Nullable<int> CompanyID { get; set; }

    public string SoforAdi { get; set; }

    public string SoforSoyadi { get; set; }

    public string Telefon { get; set; }

    public string Plaka { get; set; }

    public string Guzergah { get; set; }



    public virtual Companies Companies { get; set; }

}

}
