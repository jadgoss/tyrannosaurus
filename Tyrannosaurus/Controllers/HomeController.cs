using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tyrannosaurus.UI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Observation logging tool for people with Tyrosinemia.";

            return View();
        }

        public ViewResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ViewResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
