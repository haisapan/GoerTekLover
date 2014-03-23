using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoerTekLover.Models;

namespace GoerTekLover.Helper
{
    public class MenuHelper
    {
        public static List<MenuModel> GetMenuList()
        {
            using (DbContextFactory contextFactory = new DbContextFactory())
            {
                return contextFactory.Menus.Select(p=>p).ToList();
            }
            
        }
    }
}