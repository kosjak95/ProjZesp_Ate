using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjZesp_Ate.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Server is running...";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        internal static bool TryCreateUserAccount(string userAccountCreateData)
        {
            int a = 0;
            throw new NotImplementedException();
        }
    }
}