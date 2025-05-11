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
    public class CategoryController : Controller
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();
        #region List Category

        public ActionResult CategoryIndex()
        {
            return View(cdvdb.categories.Where(x => x.isDeleted == false).ToList());
        }

        #endregion

        #region Add Category

        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryCreate(Category model, HttpPostedFileBase image)
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
                            image.SaveAs(Server.MapPath("~/Assets/CategoryImages/" + name));
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

                        cdvdb.categories.Add(model);
                        cdvdb.SaveChanges();
                        TempData["message"] = "Category added succesfully";
                        return RedirectToAction("CategoryIndex", "Category");
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while adding a category!";
                }

            }

            return View(model);
        }
        #endregion

        #region Edit Category

        [HttpGet]
        public ActionResult CategoryEdit(int? id)
        {
            if (id != null)
            {
                Category c = cdvdb.categories.Find(id);
                if (c != null)
                {
                    if (!c.isDeleted)
                    {
                        return View(c);
                    }
                    else
                    {
                        TempData["systemError"] = "Category deleted!";
                        return RedirectToAction("Error", "System");
                    }
                }
                else
                {
                    TempData["systemError"] = "Category is not found!";
                    return RedirectToAction("Error", "System");

                }
            }
            else
            {
                return RedirectToAction("CategoryIndex", "Category");
            }
        }

        [HttpPost]
        public ActionResult CategoryEdit(Category model, HttpPostedFileBase image)
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
                            image.SaveAs(Server.MapPath("~/Assets/CategoryImages/" + name));
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
                        TempData["message"] = "Category update successfully";
                        return RedirectToAction("CategoryIndex", "Category");
                    }
                }
                catch
                {
                    ViewBag.mesaj = "An error occurred while editing a category!";
                }
            }
            return View(model);
        }
        #endregion

        #region Category Delete
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Category c = cdvdb.categories.Find(id);
                if (c != null)
                {
                    c.isDeleted = true;
                    c.isActive = false;
                    cdvdb.SaveChanges();
                    TempData["message"] = "Category deleted successfully";
                    return RedirectToAction("CategoryIndex", "Category");
                }
                else
                {
                    TempData["systemError"] = "Category can not find!";
                    return RedirectToAction("Error", "System");
                }
            }
            else
            {
                return RedirectToAction("CategoryIndex", "Category");
            }
        }
        #endregion

    }
}