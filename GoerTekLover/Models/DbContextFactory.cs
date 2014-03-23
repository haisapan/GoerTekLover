using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HaisaBaseLibrary.Uitity;

namespace GoerTekLover.Models
{
    public class DbContextFactory : DbContext
    {

        public DbContextFactory(): base("GoerDataBase")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<DbDictionary> Dictionaries { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<NavigationImage> NavigationImages { get; set; } 

    }
}