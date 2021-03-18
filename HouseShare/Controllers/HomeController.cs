using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Home = "active";
            return View();
        }

        public ActionResult Biens()
        {
            ViewBag.Biens = "active";
            return View();
        }

        public ActionResult Fiche()
        {
            return View();
        }

        //Afficher le formulaire
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Home = "active";
            return View();
        }

        //Afficher le formulaire
        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }
    }
}