
using AkGida_MyInfo.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkGida_MyInfo.Controllers
{
    internal class AkGida_MyInfoEntities:DbContext
    {
        public DbSet<Companies> Companies { get; set; }
        public DbSet<CompanyDuyuru> CompanyDuyuru { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Personels> Personels { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<YemekSirketi> YemekSirketi { get; set; }
        public DbSet<Role> Role { get; set;}
        public DbSet<Users> Users { get; set; }
        public DbSet<Yetkiler> Yetkiler { get; set; }
       
    }
}