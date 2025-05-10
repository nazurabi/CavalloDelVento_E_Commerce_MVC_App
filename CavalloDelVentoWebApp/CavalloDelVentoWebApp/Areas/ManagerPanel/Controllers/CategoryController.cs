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
        public ActionResult CategoryIndex()
        {
            return View(cdvdb.categories.Where(x => x.isDeleted == false).ToList());
        }

        #region Add Category

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model, HttpPostedFileBase image)
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
                        TempData["message"] = "Category added succesful";
                        return RedirectToAction("CategoryIndex", "Category");
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while adding a category!";
                }

            }
            ViewBag.brand_ID = new SelectList(cdvdb.brands.Where(x => x.isDeleted == false), "ID", "Brand Name");
            return View(model);
        }
        #endregion

        #region Edit Category

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Category c = cdvdb.categories.Find(id);
                if (c != null)
                {
                    return View(c);
                }
            }
            return RedirectToAction("CategoryIndex", "Category");
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cdvdb.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    cdvdb.SaveChanges();
                    TempData["message"] = "Category update successful";
                    return RedirectToAction("CategoryIndex", "Category");
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
                    //db.Categories.Remove(c); // Hard Delete
                    c.isDeleted = true; // Soft Delete
                    cdvdb.SaveChanges();
                    TempData["message"] = "Category deleted successful";
                }
            }
            return RedirectToAction("CategoryIndex", "Category");
        }
        #endregion

    }
}