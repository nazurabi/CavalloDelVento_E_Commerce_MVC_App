using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavalloDelVentoWebApp.Areas.ManagerPanel.Data;
using CavalloDelVentoWebApp.Models;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Controllers
{
    public class LoginController : Controller
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();
        public ActionResult LoginIndex()
        {
            if (Request.Cookies["ManagerCookie"] != null)
            {
                HttpCookie savedCookie = Request.Cookies["ManagerCookie"];
                string mail = savedCookie.Values["mail"];
                string password = savedCookie.Values["password"];

                Manager mngr = cdvdb.managers.FirstOrDefault(x => x.mail == mail && x.password == password);
                if (mngr != null)
                {
                    if (mngr.isActive)
                    {
                        Session["ManagerSession"] = mngr;
                        return RedirectToAction("HomeIndex", "Home");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginIndex(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager mngr = cdvdb.managers.FirstOrDefault(x => x.mail == model.mail && x.password == model.password);
                if (mngr != null)
                {
                    if (mngr.isActive)
                    {
                        if (model.rememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("ManagerCookie");
                            cookie["mail"] = model.mail;
                            cookie["password"] = model.password;
                            cookie.Expires = DateTime.Now.AddDays(7);
                            Response.Cookies.Add(cookie);
                        }
                        Session["ManagerSession"] = mngr;
                        return RedirectToAction("HomeIndex", "Home");
                    }
                    else
                    {
                        ViewBag.message = "Your account has been suspended!";
                    }
                }
                else
                {
                    ViewBag.message = "User not found!";
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session["ManagerSession"] = null;
            if (Request.Cookies["ManagerCookie"] != null)
            {
                HttpCookie savedCookie = Request.Cookies["ManagerCookie"];
                savedCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(savedCookie);
            }
            return RedirectToAction("LoginIndex", "Login");
        }

    }
}