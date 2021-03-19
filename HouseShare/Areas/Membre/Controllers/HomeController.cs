using HouseShare.Infra;
using HouseShare.Models;
using HouseShare.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseShare.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        // GET: Member/Home
        public ActionResult Index()
        {
            if (!SessionUtils.IsLogged) return RedirectToAction("Login", "Account", new { area = "" });
            return View(SessionUtils.ConnectedUser);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //afficher info du membre
        [HttpGet]
        public ActionResult Profil()
        {
            return View(SessionUtils.ConnectedUser);
        }

        //envoyer le formulaire de modification
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profil(MembreModel form)
        {
            
            form.IdMembre = SessionUtils.ConnectedUser.IdMembre;

            if (ModelState.IsValid) 
            {
                DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
                if (ctx.UpdateMemberInfo(form))
                {
                    ViewBag.SuccessMessage = "Votre profil a été mis à jour";
                    return View(SessionUtils.ConnectedUser);
                }
                else
                {
                    ViewBag.ErrorMessage = "Modification non enregistrée";
                    return View(SessionUtils.ConnectedUser);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Formulaire error : vérifiez les données insérées et réessayez";
                return View(SessionUtils.ConnectedUser);
            }
        }
    }
}