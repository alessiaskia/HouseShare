using HouseShare.Models;
using HouseShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            InscriptionViewModel ivm = new InscriptionViewModel();
            return View(ivm);
        }

        //envoyer le formulaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription(MembreModel form)
        {
            if (ModelState.IsValid) //validation coté serveur vs. annotations
            {
                DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
                if (ctx.CreateMember(form))
                {
                    ViewBag.SuccessMessage = "Votre demande d'inscription a bien été envoyée";
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
                else
                {
                    ViewBag.ErrorMessage = "Message non enregistré";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Formulaire error : vérifiez les données insérées et réessayez";
                InscriptionViewModel ivm = new InscriptionViewModel();
                return View(ivm);
            }
        }
    }
}