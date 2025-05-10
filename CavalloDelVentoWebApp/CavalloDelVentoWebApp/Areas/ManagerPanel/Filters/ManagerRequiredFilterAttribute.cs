using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavalloDelVentoWebApp.Models;
using System.Web.Mvc.Filters;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Filters
{
    public class ManagerRequiredFilterAttribute:ActionFilterAttribute,IAuthenticationFilter
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["ManagerSession"])))
            {
                if (filterContext.HttpContext.Request.Cookies["ManagerCookie"] != null) 
                {
                    HttpCookie savedCookie = filterContext.HttpContext.Request.Cookies["ManagerCookie"];
                    string mail = savedCookie.Values["mail"];
                    string password = savedCookie.Values["password"];

                    Manager mngr = cdvdb.managers.FirstOrDefault(x => x.mail == mail && x.password == password);
                    if (mngr != null)
                    {
                        if (mngr.isActive)
                        {
                            filterContext.HttpContext.Session["ManagerSession"] = mngr;
                        }
                    }
                }
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
         
            {
                filterContext.Result = new RedirectResult("~/ManagerPanel/Login/LoginIndex");
            }
        }


    }
}