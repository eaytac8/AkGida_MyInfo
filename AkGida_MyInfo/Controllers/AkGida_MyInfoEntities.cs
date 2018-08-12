
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
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Personels> Personels { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<Role> Role { get; set;}
        public DbSet<Users> Users { get; set; }
        public DbSet<Yetkiler> Yetkiler { get; set; }
        public DbSet<Baby> Baby { get; set; }
        public DbSet<Death> Death { get; set; }
        public DbSet<Congrats> Congrats { get; set; }
        public DbSet<Thanks> Thanks { get; set; }
        public DbSet<Weddings> Weddings { get; set; }
        public DbSet<YeniUrun> YeniUrun { get; set; }
        

    }
}