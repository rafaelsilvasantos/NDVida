using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NDVida_Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("index.html");
        }


    }
}