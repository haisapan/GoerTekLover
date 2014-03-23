using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using GoerTekLover.Helper;
using GoerTekLover.Models;
using WebMatrix.WebData;

namespace GoerTekLover.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        public BaseController()
        {
            
        }

        
        public int GetCurrentUser()
        {
            //if (Session["userId"]!=null)
            //{
            //    int userId = Convert.ToInt32(Session["userId"]);
            //    return userId;
            //}
            //var idCookie = Request.Cookies["userId"];
            //if (idCookie!=null)
            //{
            //    var uid = Convert.ToInt32(idCookie);
            //    Session["userId"] = uid;
            //    int sessionTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeout"]);
            //    Session.Timeout = sessionTimeout;
            //    WebSecurity.IsAuthenticated = true;
            //}
            

            return WebSecurity.CurrentUserId;
        }

        public bool IsCurrentUserLocked()
        {
            var context = new DbContextFactory();
            var currentUser = context.UserProfiles.SingleOrDefault(p => p.UserId == GetCurrentUser());
            if (currentUser!=null)
            {
                if (currentUser.IsLocked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            throw new NullReferenceException("not found current user");
        }

        //public void GetResourceObject(string key)
        //{
            
        //}

        protected override void ExecuteCore()
        {
            string cultureName = null;
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie!=null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                if (Request.UserLanguages != null)
                {
                    cultureName = Request.UserLanguages[0];
                }
            }

            cultureName = CultureHelper.GetImplementedCulture(cultureName);
            Thread.CurrentThread.CurrentCulture=new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            base.ExecuteCore();
        }

    }
}
