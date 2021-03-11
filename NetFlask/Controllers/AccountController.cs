using hbehr.recaptcha;
using NetFlask.Infra;
using NetFlask.Models;
using NetFlask.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFlask.Controllers
{
    public class AccountController : Controller
    {
        DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        // GET: Account
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
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            //bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            //if (validCaptcha)
            //{
                if (ModelState.IsValid)
                {
                    UserModel um = ctx.UserAuth(lm);
                    if (um == null)
                    {
                        ViewBag.Error = "Erreur Login/Password";
                        return View();
                    }
                    else
                    {
                        SessionUtils.IsLogged = true;
                        SessionUtils.ConnectedUser = um;
                        return RedirectToAction("Index", "Home", new { area = "Membre" });
                    }
                }
                else
                {
                    return View();
                }
            
            
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel um)
        {
            if (ModelState.IsValid)
            {
                if(ctx.CreateUser(um))
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = um;
                    return RedirectToAction("Index", "Home", new { area = "Membre" });
                }
                else
                {
                    ViewBag.Error = "Erreur Login/Password";
                    return View(um);
                }
            }
            else
            {
                ViewBag.Error = "Erreur Login/Password";
                return View(um);
            }
        }
    }
}