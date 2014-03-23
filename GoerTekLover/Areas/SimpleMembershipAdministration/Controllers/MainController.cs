using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoerTekLover.Models;
using WebMatrix.WebData;
using System.Web.Security;
using GoerTekLover.Filters;


namespace GoerTekLover.Areas.SimpleMembershipAdministration.Controllers
{
    /// <summary>
    /// TODO 叠加两个是与的关系，即两种必须都存在，研究怎么变成或的关系
    /// </summary>
    [Authorize(Roles = "admin")]
    [Authorize(Roles = "test")]

    [Authorize(Roles = "test, admin")]
    public class MainController : Controller
    {
        //
        // GET: /SimpleMembershipAdministration/Main/

        public ActionResult Index()
        {

            return View();
        }

         
        [InitializeSimpleMembership]
        public ActionResult Users()
        {
            IEnumerable<UserProfile> users;
            using (DbContextFactory db = new DbContextFactory())
            {
                users = db.UserProfiles.ToList();
            }

            ViewBag.Roles = System.Web.Security.Roles.GetAllRoles();
            
            return View(users);
        }
        [InitializeSimpleMembership]
        public ActionResult Roles()
        {
            var roles = System.Web.Security.Roles.GetAllRoles();

            return View(roles);
        }

        [HttpPost]
        public ActionResult AddRole(string rolename)
        {
            System.Web.Security.Roles.CreateRole(rolename);
            var roles = System.Web.Security.Roles.GetAllRoles();

            return View("Roles", roles);
        }
        [HttpPost]
        public ActionResult UserToRole(string rolename, string username, bool? ischecked)
        {
            if (ischecked.HasValue && ischecked.Value)
            {
                System.Web.Security.Roles.AddUserToRole(username, rolename);
            }
            else
            {
                System.Web.Security.Roles.RemoveUserFromRole(username, rolename);
            }
            
            return RedirectToAction("Users");
        }
    }
}
