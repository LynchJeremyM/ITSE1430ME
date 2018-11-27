using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.MVC.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}