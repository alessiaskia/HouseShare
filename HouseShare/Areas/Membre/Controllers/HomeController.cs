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

        //afficher biens du membre

        public ActionResult MesBiens(MembreModel user)
        {
            DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
            user.IdMembre = SessionUtils.ConnectedUser.IdMembre;
            List<BienModel> listeBM = ctx.GetBiensOfMember(user);
            return View(listeBM);
        }

        //afficher formulaire nouveau bien
        [HttpGet]
        public ActionResult AjouterBien()
        {
            return View();
        }

        //envoyer formulaire nouveau bien
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterBien(BienModel newBien)
        {
            if (ModelState.IsValid)
            {
                DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);
                if (ctx.CreateBien(newBien))
                {
                    ViewBag.SuccessMessage = "Votre bien a été correctement enregistré";
                    return View(SessionUtils.ConnectedUser);
                }
                else
                {
                    ViewBag.ErrorMessage = "Erreur : bien non enregistré";
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