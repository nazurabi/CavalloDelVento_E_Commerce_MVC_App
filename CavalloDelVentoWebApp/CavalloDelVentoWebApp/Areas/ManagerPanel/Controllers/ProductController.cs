using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CavalloDelVentoWebApp.Areas.ManagerPanel.Filters;
using CavalloDelVentoWebApp.Models;

namespace CavalloDelVentoWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerRequiredFilter]
    public class ProductController : Controller
    {
        CavalloDelVentoWebAppModel cdvdb = new CavalloDelVentoWebAppModel();

        #region List Product
        public ActionResult ProductIndex()
        {
            return View(cdvdb.products.Where(x => x.isDeleted == false));
        }

        #endregion

        #region Add Product

        [HttpGet]
        public ActionResult ProductCreate()
        {
            ViewBag.category_ID = new SelectList(cdvdb.categories.Where(x => x.isDeleted == false), "ID", "categoryName");
            ViewBag.brand_ID = new SelectList(cdvdb.brands.Where(x => x.isDeleted == false), "ID", "brandName");
            return View();
        }

        [HttpPost]
        public ActionResult ProductCreate(Product model, HttpPostedFileBase image)
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
                            image.SaveAs(Server.MapPath("~/Assets/ProductImages/" + name));
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
                        cdvdb.products.Add(model);
                        cdvdb.SaveChanges();
                        TempData["message"] = "Product added succesfully";
                        return RedirectToAction("ProductIndex", "Product");
                    }
                    else
                    {
                        ViewBag.message = "Please write digit character for Unit Price or Units In Stock!";
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while adding a product!";
                }
            }
            ViewBag.category_ID = new SelectList(cdvdb.categories.Where(x => x.isDeleted == false), "ID", "categoryName");
            ViewBag.brand_ID = new SelectList(cdvdb.brands.Where(x => x.isDeleted == false), "ID", "brandName");
            return View(model);
        }
        #endregion

        #region Edit Product
        [HttpGet]
        public ActionResult ProductEdit(int? id)
        {
            if (id != null)
            {
                Product p = cdvdb.products.Find(id);
                if (p != null)
                {
                    if (!p.isDeleted)
                    {
                        ViewBag.category_ID = new SelectList(cdvdb.categories.Where(x => x.isDeleted == false), "ID", "categoryName", p.category_ID);
                        ViewBag.brand_ID = new SelectList(cdvdb.brands.Where(x => x.isDeleted == false), "ID", "brandName", p.brand_ID);
                        return View(p);
                    }
                    else
                    {
                        TempData["systemError"] = "Product deleted!";
                        return RedirectToAction("Error", "System");
                    }
                }
                else
                {
                    TempData["systemError"] = "Product is not found!";
                    return RedirectToAction("Error", "System");
                }
            }
            else
            {
                return RedirectToAction("ProductIndex", "Product");
            }
        }

        [HttpPost]
        public ActionResult ProductEdit(Product model, HttpPostedFileBase image)
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
                            image.SaveAs(Server.MapPath("~/Assets/ProductImages/" + name));
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
                        TempData["message"] = "Product update successfully";
                        return RedirectToAction("ProductIndex", "Product");
                    }
                }
                catch
                {
                    ViewBag.message = "An error occurred while editing a product!";
                }
            }
            return View(model);
        }
        #endregion

        #region Delete Product

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product p = cdvdb.products.Find(id);
                if (p != null)
                {
                    p.isDeleted = true;
                    p.isActive = false;
                    p.isRecent = false;
                    cdvdb.SaveChanges();
                    TempData["message"] = "Product deleted successfully";
                    return RedirectToAction("ProductIndex", "Product");
                }
                else
                {
                    TempData["systemError"] = "Product can not find!";
                    return RedirectToAction("Error", "System");
                }
            }
            else
            {
                return RedirectToAction("ProductIndex", "Product");
            }
        }
        #endregion

        [HttpGet]
        public ActionResult AcceptXML()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AcceptXML(HttpPostedFileBase xmlFile)
        {
            XDocument xdoc;
            List<XMLDeserialize> xmlProductList = new List<XMLDeserialize>();
            using (StreamReader reader = new StreamReader(xmlFile.InputStream))
            {
                xdoc = XDocument.Load(reader);
            }
            XElement rootElement = xdoc.Root;
            DataTable dt = new DataTable();
            dt.Columns.Add("sendID");
            dt.Columns.Add("brandName");
            dt.Columns.Add("categoryName");
            dt.Columns.Add("productItemNumber");
            dt.Columns.Add("productName");
            dt.Columns.Add("productDescription");
            dt.Columns.Add("sendQuantity");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("subTotalPrice");
            dt.Columns.Add("tax");
            dt.Columns.Add("totalPrice");
            dt.Columns.Add("discountedPrice");
            dt.Columns.Add("productImageName");
            foreach (XElement item in rootElement.Elements())
            {
                XMLDeserialize xmlProduct = new XMLDeserialize();
                xmlProduct.sendID = Convert.ToInt32(item.Element("sendID").Value);
                xmlProduct.brandName = item.Element("brandName").Value;
                xmlProduct.categoryName = item.Element("categoryName").Value;
                xmlProduct.productItemNumber = item.Element("productItemNumber").Value;
                xmlProduct.productName =item.Element("productName").Value;
                xmlProduct.description = item.Element("productDescription").Value;
                xmlProduct.sendQuantity = Convert.ToInt16(item.Element("sendQuantity").Value);
                xmlProduct.unitPrice = Convert.ToDecimal(item.Element("unitPrice").Value);
                xmlProduct.subTotalPrice = Convert.ToDecimal(item.Element("subTotalPrice").Value);
                xmlProduct.tax = Convert.ToDecimal(item.Element("tax").Value);
                xmlProduct.totalPrice = Convert.ToDecimal(item.Element("totalPrice").Value);
                xmlProduct.discountedPrice = Convert.ToDecimal(item.Element("discountedPrice").Value);
                xmlProduct.imageName =item.Element("productImageName").Value;
                xmlProductList.Add(xmlProduct);
            }
            return View(xmlProductList);
        }

        public ActionResult XMLToProduct()
        {
            return View();
        }

        public ActionResult XMLToProductCopyImages()
        {
            return View();
        }
    }
}
