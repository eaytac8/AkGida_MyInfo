
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
    
public partial class Menu
{

    public int MenuID { get; set; }

    public Nullable<int> CompanyID { get; set; }

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
