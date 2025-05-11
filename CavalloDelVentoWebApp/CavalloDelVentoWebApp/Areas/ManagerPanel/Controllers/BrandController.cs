using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavalloDelVentoWebApp.Areas.ManagerPanel.Filters;
using CavalloDelVentoWebApp.Models;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerRequiredFilter]
    public class BrandController : Controller
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();

        #region List Brand
        public ActionResult BrandIndex()
        {
            return View(cdvdb.brands.Where(x => x.isDeleted == false).ToList());
        }
        #endregion

        #region Add Brand

        [HttpGet]
        public ActionResult BrandCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BrandCreate(Brand model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValidImage = true;
                    if (image != null)
                    {
                        FileInfo fi = new FileInfo(image.FileName);
                        string extension = fi.Extension;
                        if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + extension;
                            model.image = name;
                            image.SaveAs(Server.MapPath("~/Assets/BrandImages/" + name));
                        }
                        else
                        {
                            isValidImage = false;
                            ViewBag.message = "Image extension must be '.jpg, .jpeg, .png' please choose true extension!";
                        }
                    }
                    else
                    {
                        model.image = "none.jpg";
                    }
                    if (isValidImage)
                    {
                        cdvdb.brands.Add(model);
                        cdvdb.SaveChanges();
                        TempData["message"] = "Brand added succesfully";
                        return RedirectToAction("BrandIndex", "Brand");
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while adding a brand!";
                }
            }
            return View(model);
        }
        #endregion

        #region Edit Brand

        [HttpGet]
        public ActionResult BrandEdit(int? id)
        {
            if (id != null)
            {
                Brand br = cdvdb.brands.Find(id);
                if (br != null)
                {
                    if (!br.isDeleted)
                    {
                        return View(br);
                    }
                    else
                    {
                        TempData["systemError"] = "Brand deleted!";
                        return RedirectToAction("Error", "System");
                    }
                }
                else
                {
                    TempData["systemError"] = "Brand is not found!";
                    return RedirectToAction("Error", "System");
                }
            }
            else
            {
                return RedirectToAction("BrandIndex", "Brand");
            }
        }

        [HttpPost]
        public ActionResult BrandEdit(Brand model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValidImage = true;
                    if (image != null)
                    {
                        FileInfo fi = new FileInfo(image.FileName);
                        string extension = fi.Extension;
                        if (extension == ".jpeg" || extension == ".jpg" || extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + extension;
                            model.image = name;
                            image.SaveAs(Server.MapPath("~/Assets/BrandImages/" + name));
                        }
                        else
                        {
                            isValidImage = false;
                            ViewBag.message = "Image extension must be '.jpg, .jpeg, .png' please choose true extension!";
                        }
                    }
                   
                    if (isValidImage)
                    {
                        cdvdb.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        cdvdb.SaveChanges();
                        TempData["message"] = "Brand update successfully";
                        return RedirectToAction("BrandIndex", "Brand");
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while editing a category!";
                }
            }
            return View(model);
        }
        #endregion

        #region Delete Brand
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Brand br = cdvdb.brands.Find(id);
                if (br != null)
                {
                    //db.Brands.Remove(c); // Hard Delete
                    br.isDeleted = true; // Soft Delete
                    br.isActive = false;
                    cdvdb.SaveChanges();
                    TempData["message"] = "Brand deleted successfully";
                    return RedirectToAction("BrandIndex", "Brand");
                }
                else
                {
                    TempData["systemError"] = "Brand can not find!";
                    return RedirectToAction("Error", "System");
                }
            }
            else
            {
                return RedirectToAction("BrandIndex", "Brand");
            }
        }

        #endregion
    }
}