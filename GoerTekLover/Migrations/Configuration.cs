using System.Web.Security;
using GoerTekLover.Models;

namespace GoerTekLover.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoerTekLover.Models.DbContextFactory>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GoerTekLover.Models.DbContextFactory contextFactory)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    contextFactory.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //foreach (Role role in Enum.GetValues(typeof(Role)).Cast<Role>())
            //{
            //    if (!Roles.RoleExists(role.ToString()))
            //    {
            //        Roles.CreateRole(role.ToString());
            //    }
            //}

            ////create roles
            //if (!Roles.RoleExists("Admin"))
            //    Roles.CreateRole("Admin");

        }
    }
}
