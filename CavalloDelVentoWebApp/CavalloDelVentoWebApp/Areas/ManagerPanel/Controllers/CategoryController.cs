using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavalloDelVentoWebApp.Models;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Controllers
{
    public class CategoryController : Controller
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();
        public ActionResult CategoryIndex()
        {
            return View(cdvdb.categories.Where(x=>x.isDeleted==false).ToList());
        }
    }
}