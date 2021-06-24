using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ShowChat()
        {
            return View();
        }
    }
}