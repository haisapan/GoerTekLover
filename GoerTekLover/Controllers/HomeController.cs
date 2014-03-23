using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoerTekLover.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            string about =Haisa.Resource.Resource.Home;
            ViewBag.Message = about;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            string about = Haisa.Resource.Resource.Home;
            
            ViewBag.Message = about;
            return View();
        }

        public ActionResult GetJson()
        {
            var name=Request["name"];
            return Json(name + " pan",JsonRequestBehavior.AllowGet);
        }
    }
}
