﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class AkGida_MyInfoEntities : DbContext
{
    public AkGida_MyInfoEntities()
        : base("name=AkGida_MyInfoEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Baby> Baby { get; set; }

    public virtual DbSet<Companies> Companies { get; set; }

    public virtual DbSet<Congrats> Congrats { get; set; }

    public virtual DbSet<Death> Death { get; set; }

    public virtual DbSet<Departments> Departments { get; set; }

    public virtual DbSet<Duyurular> Duyurular { get; set; }

    public virtual DbSet<Hakkimizda> Hakkimizda { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<Personels> Personels { get; set; }

    public virtual DbSet<Servis> Servis { get; set; }

    public virtual DbSet<Slider> Slider { get; set; }

    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

    public virtual DbSet<Thanks> Thanks { get; set; }

    public virtual DbSet<Weddings> Weddings { get; set; }

    public virtual DbSet<Yayinlar> Yayinlar { get; set; }

    public virtual DbSet<YeniUrun> YeniUrun { get; set; }

}

}

