﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using GoerTekLover.Models;
using WebMatrix.WebData;

namespace GoerTekLover
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //WebMail.SmtpServer = "mailserver.example.com";
            //WebMail.EnableSsl = true;
            //WebMail.UserName = "username@example.com";
            //WebMail.Password = "your-password";
            //WebMail.From = "your-name-here@example.com";

            HaisaBaseLibrary.LogLib.Logger.Instance.Info("test");

            

        }
    }
}