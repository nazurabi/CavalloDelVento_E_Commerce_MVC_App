using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;


namespace DataModelWithADO
{

    public class DataModel
    {
        SqlConnection con;
        SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionString.connection);
            cmd = con.CreateCommand();
        }
        public string FormTitle()
        {
            MainDealer md = new MainDealer();
            try
            {
                cmd.CommandText = "SELECT DealerName FROM MainDealerSettings WHERE SettingID=@sid ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sid", 1);
                con.Open();
                string formTitle = Convert.ToString(cmd.ExecuteScalar());
                return formTitle;
            }
            finally
            {
                con.Close();
            }
        }

        #region Brand Applications

        public DataTable brandDataBind()
        {
            #region With FileStream 

            //cmd.CommandText = "SELECT * FROM Brands";
            //SqlDataAdapter da = new SqlDataAdapter();
            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            //commandBuilder.DataAdapter = da;
            //da.SelectCommand = cmd;

            //DataTable temporaryDataTable = new DataTable();
            //da.Fill(temporaryDataTable);

            //DataTable returnToForm = new DataTable();
            //returnToForm.Columns.Add("BrandID", typeof(int));
            //returnToForm.Columns.Add("Brand Name", typeof(string));
            //returnToForm.Columns.Add("Is Brand Active For Sale", typeof(string));
            //returnToForm.Columns.Add("Is Deleted", typeof(string));
            //returnToForm.Columns.Add("Brand Image", typeof(string));

            //string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages");
            //imagePath = Path.GetFullPath(imagePath);

            //foreach (DataRow row in temporaryDataTable.Rows)
            //{
            //    string brandID = row["BrandID"].ToString();
            //    string brandName = row["BrandName"].ToString();
            //    bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
            //    bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);

            //    string fullPath = Path.Combine(imagePath, imageFile);
            //    System.Drawing.Image img = null;

            //    if (File.Exists(fullPath))
            //    {
            //        using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            //        {
            //            img = System.Drawing.Image.FromStream(fs);
            //        }
            //    }

            //    returnToForm.Rows.Add(brandID, brandName, isActiveForSale ? "Yes" : "No", img, isDeleted ? "Yes" : "No");
            //}
            //return returnToForm;

            #endregion

            #region With fullPath (Image pulls database by string)

            cmd.CommandText = "SELECT * FROM Brands";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("BrandID", typeof(int));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("Is Brand Active For Sale", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Brand Image Name", typeof(string));
            returnToForm.Columns.Add("Brand Image", typeof(System.Drawing.Image));
            short sequenceNumber = 0;

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                sequenceNumber++;
                string brandID = row["BrandID"].ToString();
                string brandName = row["BrandName"].ToString();
                bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                string imageFile = row["Image"].ToString();
                string fullPath = Path.Combine(imagePath, imageFile);
                System.Drawing.Image img = null;
                if (File.Exists(fullPath))
                {
                    img = System.Drawing.Image.FromFile(fullPath);
                }

                returnToForm.Rows.Add(sequenceNumber, brandID, brandName, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath, img);
            }

            return returnToForm;

            #endregion

        }

        public void addBrand(string brandName, bool isDeleted, bool isActive, string brandImage)
        {
            cmd.CommandText = "INSERT INTO Brands(BrandName, Image, IsDeleted, IsActive) VALUES (@brandName, @brandImage, @isDeleted, @isActive)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.Parameters.AddWithValue("@brandImage", brandImage);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Brand added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add brand, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editBrand(string brandID, string brandName, bool isActive, bool isDeleted, string brandImage)
        {
            cmd.CommandText = "UPDATE Brands SET BrandName=@brandName, IsActive=@isActive, IsDeleted=@isDeleted, Image=@brandImage WHERE BrandID=@brandID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandID", brandID);
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@brandImage", brandImage);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Brand edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit brand, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editBrand(string brandID, bool isActive, bool isDeleted, string brandImage)
        {
            cmd.CommandText = "UPDATE Brands SET IsActive=@isActive, IsDeleted=@isDeleted, Image=@brandImage WHERE BrandID=@brandID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandID", brandID);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@brandImage", brandImage);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Brand edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit brand, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public byte listBrands(string checkBrandName)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT BrandName FROM Brands";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brands brand = new Brands();
                    brand.brandName = reader.GetString(0);
                    if (checkBrandName == brand.brandName)
                    {
                        checkCounter++;
                    }
                }
                return checkCounter;
            }
            finally
            {
                con.Close();
            }
        }

        public string listImageForEditBrands(string brandIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT Image FROM Brands WHERE BrandID=@brandID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandID", brandIDForCheck);
                con.Open();
                string imageName = Convert.ToString(cmd.ExecuteScalar());
                return imageName;
            }
            finally
            {
                con.Close();
            }
        }

        public bool isBrandDelete(string brandIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT IsDeleted FROM Brands WHERE BrandID=@brandID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandID", brandIDForCheck);
                con.Open();
                bool isDeleted = Convert.ToBoolean(cmd.ExecuteScalar());
                return isDeleted;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Categories Applications

        public DataTable categoryDataBind()
        {
            cmd.CommandText = "SELECT * FROM Categories";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(int));
            returnToForm.Columns.Add("CategoryID", typeof(int));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Is Category Active For Sale", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Category Image Name", typeof(string));
            returnToForm.Columns.Add("Category Image", typeof(System.Drawing.Image));
            short sequenceNumber = 0;

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                if (!isBrandDelete(row["BrandIDFK"].ToString()))
                {
                    sequenceNumber++;
                    string brandIDFK = row["BrandIDFK"].ToString();
                    string categoryID = row["CategoryID"].ToString();
                    string brandName = getBrandNameForCategories(brandIDFK);
                    string categoryName = row["CategoryName"].ToString();
                    string description = row["Description"].ToString();
                    bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
                    bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                    string imageFile = row["Image"].ToString();
                    string fullPath = Path.Combine(imagePath, imageFile);
                    System.Drawing.Image img = null;
                    if (File.Exists(fullPath))
                    {
                        img = System.Drawing.Image.FromFile(fullPath);
                    }
                    returnToForm.Rows.Add(sequenceNumber, brandIDFK, categoryID, brandName, categoryName, description, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath, img);
                }
            }
            return returnToForm;
        }

        public void addCategory(string brandIDFK, string categoryName, bool isDeleted, bool isActive, string description, string categoryImage)
        {
            cmd.CommandText = "INSERT INTO Categories(BrandIDFK, CategoryName, IsDeleted, IsActive, Description, Image ) VALUES (@brandIDFK, @categoryName, @isDeleted, @isActive, @description, @categoryImage)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@categoryImage", categoryImage);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add category, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editCategory(string categoryID, string brandIDFK, string categoryName, string description, bool isActive, bool isDeleted, string categoryImage)
        {
            cmd.CommandText = "UPDATE Categories SET BrandIDFK=@brandIDFK, CategoryName=@categoryName, Description=@description, IsActive=@isActive,IsDeleted=@isDeleted, Image=@categoryImage WHERE CategoryID=@categoryID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@categoryImage", categoryImage);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit category, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editCategory(string categoryID, string brandIDFK, string description, bool isActive, bool isDeleted, string categoryImage)
        {
            cmd.CommandText = "UPDATE Categories SET BrandIDFK=@brandIDFK, Description=@description, IsActive=@isActive,IsDeleted=@isDeleted, Image=@categoryImage WHERE CategoryID=@categoryID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@categoryImage", categoryImage);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit category, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public byte listCategories(string checkCategoryName, string checkBrandIDFKForCategory)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT CategoryName, BrandIDFK FROM Categories";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories();
                    category.categoryName = reader.GetString(0);
                    category.brandIDFK = reader.GetInt32(1);
                    if (checkCategoryName == category.categoryName && Convert.ToInt32(checkBrandIDFKForCategory) == category.brandIDFK)
                    {
                        checkCounter++;
                    }
                }
                return checkCounter;
            }
            finally
            {
                con.Close();
            }
        }

        public string getBrandNameForCategories(string brandIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT BrandName FROM Brands WHERE BrandID=@brandID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandID", brandIDForCheck);
                con.Open();
                string brandName = Convert.ToString(cmd.ExecuteScalar());
                return brandName;
            }
            finally
            {
                con.Close();
            }
        }


        public List<Brands> getBrandsForCategories()
        {
            List<Brands> brands = new List<Brands>();
            try
            {
                cmd.CommandText = "SELECT * FROM Brands";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brands brand = new Brands();
                    brand.brandID = reader.GetInt32(0);
                    brand.brandName = reader.GetString(1);
                    brand.isDeleted = reader.GetBoolean(3);
                    if (!brand.isDeleted)
                    {
                        brands.Add(brand);
                    }
                }
                return brands;
            }
            finally
            {
                con.Close();
            }
        }

        public string listImageForEditCategories(string categoryIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT Image FROM Categories WHERE CategoryID=@categoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryID", categoryIDForCheck);
                con.Open();
                string imageName = Convert.ToString(cmd.ExecuteScalar());
                return imageName;
            }
            finally
            {
                con.Close();
            }
        }
        public bool isCategoryDelete(string categoryIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT IsDeleted FROM Categories WHERE CategoryID=@categoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryID", categoryIDForCheck);
                con.Open();
                bool isDeleted = Convert.ToBoolean(cmd.ExecuteScalar());
                return isDeleted;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Products Applications

        public DataTable productsDataBind()
        {
            #region With fullPath (Image pulls database by string)

            cmd.CommandText = "SELECT * FROM Products";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("ProductID", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(string));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("CategoryIDFK", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("Product Name", typeof(string));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Quantity Per Unit", typeof(string));
            returnToForm.Columns.Add("Unit Price", typeof(decimal));
            returnToForm.Columns.Add("Units In Stock", typeof(string));
            returnToForm.Columns.Add("Units On Order", typeof(string));
            returnToForm.Columns.Add("Reorder Level", typeof(string));
            returnToForm.Columns.Add("Discontinued", typeof(string));
            returnToForm.Columns.Add("Is Product Active For Sale", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Product Image Name", typeof(string));
            returnToForm.Columns.Add("Product Image", typeof(System.Drawing.Image));
            short sequenceNumber = 0;
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                if (!isBrandDelete(row["BrandIDFK"].ToString()))
                {
                    if (!isCategoryDelete(row["CategoryIDFK"].ToString()))
                    {
                        sequenceNumber++;
                        string productID = row["ProductID"].ToString();
                        string brandIDFK = row["BrandIDFK"].ToString();
                        string brandName = getBrandNameForProducts(brandIDFK);
                        string categoryIDFK = row["CategoryIDFK"].ToString();
                        string categoryName = getCategoryNameForProducts(categoryIDFK);
                        string productName = row["ProductName"].ToString();
                        string description = row["Description"].ToString();
                        string quantityPerUnit = row["QuantityPerUnit"].ToString();
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                        string unitsInStock = row["UnitsInStock"].ToString();
                        string unitsOnOrder = row["UnitsOnOrder"].ToString();
                        string reorderLevel = row["ReorderLevel"].ToString();
                        bool discontinued = Convert.ToBoolean(row["Discontinued"]);
                        bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
                        bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                        string imageFile = row["Image"].ToString();
                        string fullPath = Path.Combine(imagePath, imageFile);

                        System.Drawing.Image img = null;
                        if (File.Exists(fullPath))
                        {
                            img = System.Drawing.Image.FromFile(fullPath);

                        }

                        returnToForm.Rows.Add(sequenceNumber, productID, brandIDFK, brandName, categoryIDFK, categoryName, productName, description, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued ? "Yes" : "No", isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath, img);
                    }
                }
            }
            return returnToForm;

            #endregion
        }

        public void addProduct(string brandIDFK, string categoryIDFK, string productName, string description, string productImage, string quantityPerUnit, decimal unitPrice, string unitInStock, string unitsOnOrder, string reorderLevel, bool discontinued, bool isDeleted, bool isActive)
        {
            cmd.CommandText = "INSERT INTO Products(BrandIDFK, CategoryIDFK, ProductName, Description, Image, QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,IsDeleted,IsActive ) VALUES (@brandIDFK, @categoryIDFK, @productName, @description, @image, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued, @isDeleted, @isActive)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@image", productImage);
            cmd.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@unitsInStock", unitInStock);
            cmd.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", discontinued);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add product, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editProduct(string productID, string brandIDFK, string categoryIDFK, string productName, string description, string productImage, string quantityPerUnit, decimal unitPrice, string unitInStock, string reorderLevel, bool discontinued, bool isDeleted, bool isActive)
        {
            cmd.CommandText = "UPDATE Products SET BrandIDFK=@brandIDFK, CategoryIDFK=@categoryIDFK, ProductName=@productName, Description=@description, Image=@productImage, QuantityPerUnit=@quantityPerUnit, UnitPrice=@unitPrice, UnitsInStock=@unitInStock, ReorderLevel=@reorderLevel, Discontinued=@discontinued, IsDeleted=@isDeleted, IsActive=@isActive WHERE ProductID=@productID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@productImage", productImage);
            cmd.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@unitInStock", unitInStock);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", discontinued);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit product, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editProduct(string productID, string brandIDFK, string categoryIDFK, string description, string productImage, string quantityPerUnit, decimal unitPrice, string unitInStock, string reorderLevel, bool discontinued, bool isDeleted, bool isActive)
        {
            cmd.CommandText = "UPDATE Products SET BrandIDFK=@brandIDFK, CategoryIDFK=@categoryIDFK, Description=@description, Image=@productImage, QuantityPerUnit=@quantityPerUnit, UnitPrice=@unitPrice, UnitsInStock=@unitInStock, ReorderLevel=@reorderLevel, Discontinued=@discontinued, IsDeleted=@isDeleted, IsActive=@isActive WHERE ProductID=@productID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@productID", productID);
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@productImage", productImage);
            cmd.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@unitInStock", unitInStock);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", discontinued);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit product, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public byte listProducts(string checkProductName, string checkBrandIDFKForProduct, string checkCategoryIDFKForProduct)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT BrandIDFK, CategoryIDFK, ProductName FROM Products";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product products = new Product();
                    products.brandIDFK = reader.GetInt32(0);
                    products.categoryIDFK = reader.GetInt32(1);
                    products.productName = reader.GetString(2);

                    if (checkProductName == products.productName && Convert.ToInt32(checkBrandIDFKForProduct) == products.brandIDFK && Convert.ToInt32(checkCategoryIDFKForProduct) == products.categoryIDFK)
                    {
                        checkCounter++;
                    }
                }
                return checkCounter;
            }
            finally
            {
                con.Close();
            }
        }

        public string getBrandNameForProducts(string brandIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT BrandName FROM Brands WHERE BrandID=@brandID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandID", brandIDForCheck);
                con.Open();
                string brandName = Convert.ToString(cmd.ExecuteScalar());
                return brandName;
            }
            finally
            {
                con.Close();
            }
        }

        public string getCategoryNameForProducts(string categoryIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT CategoryName FROM Categories WHERE CategoryID=@categoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryID", categoryIDForCheck);
                con.Open();
                string categoryName = Convert.ToString(cmd.ExecuteScalar());
                return categoryName;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Categories> getCategoriesForProducts(string brandIDFK)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                cmd.CommandText = "SELECT CategoryID, CategoryName, IsDeleted FROM Categories WHERE BrandIDFK=@brandIDFK";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories();
                    category.categoryID = reader.GetInt32(0);
                    category.categoryName = reader.GetString(1);
                    category.isDeleted = reader.GetBoolean(2);
                    if (!category.isDeleted)
                    {
                        categories.Add(category);
                    }
                }
                return categories;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Brands> getBrandsForProducts()
        {
            List<Brands> brands = new List<Brands>();
            try
            {
                cmd.CommandText = "SELECT * FROM Brands";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brands brand = new Brands();
                    brand.brandID = reader.GetInt32(0);
                    brand.brandName = reader.GetString(1);
                    brand.isDeleted = reader.GetBoolean(3);
                    if (!brand.isDeleted)
                    {
                        brands.Add(brand);
                    }
                }
                return brands;
            }
            finally
            {
                con.Close();
            }
        }

        public string listImageForEditProducts(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT Image FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string imageName = Convert.ToString(cmd.ExecuteScalar());
                return imageName;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Discount Rates

        public DataTable discountDataBind()
        {

            cmd.CommandText = "SELECT * FROM DiscountRatesSettings";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("DiscountID", typeof(int));
            returnToForm.Columns.Add("Discount Type", typeof(string));
            returnToForm.Columns.Add("Discount Amount", typeof(string));
            returnToForm.Columns.Add("Discount Image", typeof(System.Drawing.Image));
            short sequenceNumber = 0;

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ApplicationImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                sequenceNumber++;
                string discountID = row["DiscountID"].ToString();
                string discountType = row["DiscountType"].ToString();
                string discountAmount = row["DiscountAmount"].ToString();
                string imageFile;
                if("Gold"== row["DiscountType"].ToString())
                {
                    imageFile = "Gold.png";
                }
                else if("Silver"== row["DiscountType"].ToString())
                {
                    imageFile = "Silver.png";
                }
                else
                {
                    imageFile = "Bronze.png";
                }
          

                string fullPath = Path.Combine(imagePath, imageFile);
                System.Drawing.Image img = null;
                if (File.Exists(fullPath))
                {
                    img = System.Drawing.Image.FromFile(fullPath);
                }

                returnToForm.Rows.Add(sequenceNumber, discountID, discountType, discountAmount, img);
            }

            return returnToForm;
        }

        public void editDiscountRates(string discountID, byte discountRates)
        {
            cmd.CommandText = "UPDATE DiscountRatesSettings SET DiscountAmount=@discountAmount WHERE DiscountID=@discountID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@discountID", discountID);
            cmd.Parameters.AddWithValue("@discountAmount", discountRates);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Discount amount edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit discount amount, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }
        #endregion

        //#region SubDealers
        //public DataTable brandDataBind()
        //{
           
        //    cmd.CommandText = "SELECT * FROM Brands";
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
        //    commandBuilder.DataAdapter = da;
        //    da.SelectCommand = cmd;

        //    DataTable temporaryDataTable = new DataTable();
        //    da.Fill(temporaryDataTable);

        //    DataTable returnToForm = new DataTable();
        //    returnToForm.Columns.Add("S/N", typeof(string));
        //    returnToForm.Columns.Add("BrandID", typeof(int));
        //    returnToForm.Columns.Add("Brand Name", typeof(string));
        //    returnToForm.Columns.Add("Is Brand Active For Sale", typeof(string));
        //    returnToForm.Columns.Add("Is Deleted", typeof(string));
        //    returnToForm.Columns.Add("Brand Image Name", typeof(string));
        //    returnToForm.Columns.Add("Brand Image", typeof(System.Drawing.Image));
        //    short sequenceNumber = 0;

        //    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages");
        //    imagePath = Path.GetFullPath(imagePath);

        //    foreach (DataRow row in temporaryDataTable.Rows)
        //    {
        //        sequenceNumber++;
        //        string brandID = row["BrandID"].ToString();
        //        string brandName = row["BrandName"].ToString();
        //        bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
        //        bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
        //        string imageFile = row["Image"].ToString();
        //        string fullPath = Path.Combine(imagePath, imageFile);
        //        System.Drawing.Image img = null;
        //        if (File.Exists(fullPath))
        //        {
        //            img = System.Drawing.Image.FromFile(fullPath);
        //        }

        //        returnToForm.Rows.Add(sequenceNumber, brandID, brandName, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath, img);
        //    }

        //    return returnToForm;
        //}

        ////public void addBrand(string brandName, bool isDeleted, bool isActive, string brandImage)
        ////{
        ////    cmd.CommandText = "INSERT INTO Brands(BrandName, Image, IsDeleted, IsActive) VALUES (@brandName, @brandImage, @isDeleted, @isActive)";
        ////    cmd.Parameters.Clear();
        ////    cmd.Parameters.AddWithValue("@brandName", brandName);
        ////    cmd.Parameters.AddWithValue("@brandImage", brandImage);
        ////    cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
        ////    cmd.Parameters.AddWithValue("@isActive", isActive);
        ////    try
        ////    {
        ////        con.Open();
        ////        cmd.ExecuteNonQuery();
        ////        MessageBox.Show("Brand added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ////    }
        ////    catch (Exception)
        ////    {
        ////        MessageBox.Show("Unable to add brand, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////    }
        ////    finally
        ////    {
        ////        con.Close();
        ////    }
        ////}

        ////public void editBrand(string brandID, string brandName, bool isActive, bool isDeleted, string brandImage)
        ////{
        ////    cmd.CommandText = "UPDATE Brands SET BrandName=@brandName, IsActive=@isActive, IsDeleted=@isDeleted, Image=@brandImage WHERE BrandID=@brandID";
        ////    cmd.Parameters.Clear();
        ////    cmd.Parameters.AddWithValue("@brandID", brandID);
        ////    cmd.Parameters.AddWithValue("@brandName", brandName);
        ////    cmd.Parameters.AddWithValue("@isActive", isActive);
        ////    cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
        ////    cmd.Parameters.AddWithValue("@brandImage", brandImage);

        ////    try
        ////    {
        ////        con.Open();
        ////        cmd.ExecuteNonQuery();
        ////        MessageBox.Show("Brand edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ////    }
        ////    catch (Exception)
        ////    {
        ////        MessageBox.Show("Unable to edit brand, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////    }
        ////    finally
        ////    {
        ////        con.Close();
        ////    }
        ////}

        //#endregion
    }
}
