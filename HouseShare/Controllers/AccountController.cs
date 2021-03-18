using HouseShare.Infra;
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
    public class AccountController : Controller
    {
        DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                MembreModel cm = ctx.MemberAuth(lm);
                if (cm == null)
                {
                    ViewBag.ErrorNotExistent = "Erreur Login/Password : compte pas enregistré";
                    return View();
                }
                else
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = cm;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
            }
            else
            {
                ViewBag.ErrorNotValid = "Formulaire error : vérifiez les données insérées et réessayez";
                return View();
            }

        }
    }
}