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

        public bool isTextBoxesEmpty(Control checkTextBoxes, string nullableControlName)
        {
            bool empty = false;
            foreach (Control controller in checkTextBoxes.Controls)
            {
                if (controller is TextBox tb)
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        if (tb.Name != nullableControlName)
                        {
                            empty = true;
                        }
                    }
                }
            }
            return empty;
        }
        public bool isTextBoxesEmpty(Control checkTextBoxes)
        {
            bool empty = false;
            foreach (Control controller in checkTextBoxes.Controls)
            {
                if (controller is TextBox tb)
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        empty = true;
                    }
                }
            }
            return empty;
        }


        public void enableControls(Control checkTextBoxes)
        {
            foreach (Control controller in checkTextBoxes.Controls)
            {
                //if (controller is TextBox tb)
                //{
                //    tb.Enabled = true;
                //}
                if (!(controller is Label) && !(controller is DataGridView) && !(controller is Button))
                {
                    controller.Enabled = true;
                }
            }
        }
        public void disableControls(Control checkTextBoxes)
        {
            foreach (Control controller in checkTextBoxes.Controls)
            {
                if (!(controller is Label) && !(controller is DataGridView) && !(controller is Button))
                {
                    controller.Enabled = false;
                }
            }
        }

        public void clearControls(Control checkTextBoxes)
        {
            foreach (Control controller in checkTextBoxes.Controls)
            {
                if (controller is TextBox tb)
                {
                    if (tb.Name != "tb_tax")
                    {
                        tb.Text = string.Empty;
                    }
                }
                else if (controller is PictureBox pb)
                {
                    pb.ImageLocation = "";
                }
                else if (controller is CheckBox cb)
                {
                    cb.Checked = false;
                }
                else if (controller is ComboBox cbb && controller.Name != "cbb_userType")
                {
                    cbb.SelectedIndex = 0;
                }
                if (controller is NumericUpDown nud)
                {
                    nud.Value = 0;
                }
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

                returnToForm.Rows.Add(sequenceNumber, brandID, brandName, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", imageFile, img);
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

        public bool isBrandDeleteOrDeactive(string brandIDForCheck)
        {
            bool isDeleteOrDeactive = false;
            try
            {
                cmd.CommandText = "SELECT IsDeleted,IsActive FROM Brands WHERE BrandID=@brandID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@brandID", brandIDForCheck);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brands brand = new Brands();
                    brand.isDeleted = reader.GetBoolean(0);
                    brand.isActive = reader.GetBoolean(1);
                    if (brand.isDeleted == true || brand.isActive == false)
                    {
                        isDeleteOrDeactive = true;
                    }
                }
                return isDeleteOrDeactive;
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
            returnToForm.Columns.Add("CategoryID", typeof(int));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(int));
            returnToForm.Columns.Add("Brand Name", typeof(string));
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
                    string categoryID = row["CategoryID"].ToString();
                    string categoryName = row["CategoryName"].ToString();
                    string brandIDFK = row["BrandIDFK"].ToString();
                    string brandName = getBrandNameForCategories(brandIDFK);
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
                    returnToForm.Rows.Add(sequenceNumber, categoryID, categoryName, brandIDFK, brandName, description, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", imageFile, img);
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
        public bool isCategoryDeleteOrDeactive(string categoryIDForCheck)
        {
            bool isDeleteOrDeactive = false;
            try
            {
                cmd.CommandText = "SELECT IsDeleted,IsActive FROM Categories WHERE CategoryID=@categoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryID", categoryIDForCheck);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories();
                    category.isDeleted = reader.GetBoolean(0);
                    category.isActive = reader.GetBoolean(1);
                    if (category.isDeleted == true || category.isActive == false)
                    {
                        isDeleteOrDeactive = true;
                    }
                }
                return isDeleteOrDeactive;
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
            returnToForm.Columns.Add("Product Item Number", typeof(string));
            returnToForm.Columns.Add("Product Name", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(string));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("CategoryIDFK", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
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
                        string productItemNumber = "MD" + productID;
                        string productName = row["ProductName"].ToString();
                        string brandIDFK = row["BrandIDFK"].ToString();
                        string brandName = getBrandNameForProducts(brandIDFK);
                        string categoryIDFK = row["CategoryIDFK"].ToString();
                        string categoryName = getCategoryNameForProducts(categoryIDFK);
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

                        returnToForm.Rows.Add(sequenceNumber, productID, productItemNumber, productName, brandIDFK, brandName, categoryIDFK, categoryName, description, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued ? "Yes" : "No", isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", imageFile, img);
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

        public List<Categories> getCategoryForSendToSubDealer(string brandIDFK)
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                cmd.CommandText = "SELECT CategoryID, CategoryName, IsDeleted, IsActive FROM Categories WHERE BrandIDFK=@brandIDFK";
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
                    category.isActive = reader.GetBoolean(3);
                    if (!category.isDeleted && category.isActive)
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
        public List<Brands> getBrandsForSendToSubDealer()
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
                    brand.isActive = reader.GetBoolean(4);
                    if (!brand.isDeleted && brand.isActive)
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

        public List<Product> getProductForSendToSubDealers(string categoryIDFK)
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT ProductID, ProductName,IsDeleted, IsActive FROM Products WHERE CategoryIDFK=@categoryIDFK";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.productID = reader.GetInt32(0);
                    product.productName = reader.GetString(1);
                    product.isDeleted = reader.GetBoolean(2);
                    product.isActive = reader.GetBoolean(3);
                    if (!product.isDeleted && product.isActive)
                    {
                        products.Add(product);
                    }
                }
                return products;
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

        public bool isProductDeleteOrDeactive(string productIDForCheck)
        {
            bool isDeleteOrDeactive = false;
            try
            {
                cmd.CommandText = "SELECT IsDeleted,IsActive FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.isDeleted = reader.GetBoolean(0);
                    product.isActive = reader.GetBoolean(1);
                    if (product.isDeleted == true || product.isActive == false)
                    {
                        isDeleteOrDeactive = true;
                    }
                }
                return isDeleteOrDeactive;
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
                if ("Gold" == row["DiscountType"].ToString())
                {
                    imageFile = "Gold.png";
                }
                else if ("Silver" == row["DiscountType"].ToString())
                {
                    imageFile = "Silver.png";
                }
                else if ("Bronze" == row["DiscountType"].ToString())
                {
                    imageFile = "Bronze.png";
                }
                else
                {
                    imageFile = "Normaluser.png";
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

        public List<DiscountRates> getDiscountRates()
        {
            List<DiscountRates> drates = new List<DiscountRates>();
            try
            {
                cmd.CommandText = "SELECT * FROM DiscountRatesSettings";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DiscountRates dr = new DiscountRates();
                    dr.discountID = reader.GetInt32(0);
                    dr.discountType = reader.GetString(1);
                    dr.discountAmount = reader.GetByte(2);
                    drates.Add(dr);
                }
                return drates;
            }
            finally
            {
                con.Close();
            }
        }

        public string getDiscountType(string checkDiscountID)
        {
            try
            {
                cmd.CommandText = "SELECT DiscountType FROM DiscountRatesSettings WHERE DiscountID=@discountID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@discountID", checkDiscountID);
                con.Open();
                string discountType = Convert.ToString(cmd.ExecuteScalar());
                return discountType;
            }
            finally
            {
                con.Close();
            }
        }

        public string getDiscountAmount(string checkDiscountID)
        {
            try
            {
                cmd.CommandText = "SELECT DiscountAmount FROM DiscountRatesSettings WHERE DiscountID=@discountID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@discountID", checkDiscountID);
                con.Open();
                string discountAmount = Convert.ToString(cmd.ExecuteScalar());
                return discountAmount;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region SubDealers
        public DataTable subDealerDataBind()
        {
            cmd.CommandText = "SELECT * FROM SubDealerUsers";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("User ID", typeof(int));
            returnToForm.Columns.Add("Dealer Name", typeof(string));
            returnToForm.Columns.Add("Dealer Mail", typeof(string));
            returnToForm.Columns.Add("DiscountIDFK", typeof(string));
            returnToForm.Columns.Add("User Type", typeof(string));
            returnToForm.Columns.Add("Dealer Address", typeof(string));
            returnToForm.Columns.Add("Dealer City", typeof(string));
            returnToForm.Columns.Add("Dealer Postal Code", typeof(string));
            returnToForm.Columns.Add("Dealer Country", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            short sequenceNumber = 0;
            foreach (DataRow row in temporaryDataTable.Rows)
            {
                sequenceNumber++;
                string userID = row["SubDealerUserID"].ToString();
                string dealerName = row["DealerName"].ToString();
                string dealerMail = row["DealerMail"].ToString();
                string discountIDFK = row["DiscountIDFK"].ToString();
                string userType = getDiscountType(discountIDFK);
                string dealerAdress = row["DealerAddress"].ToString();
                string dealerCity = row["DealerCity"].ToString();
                string dealerPostalCode = row["DealerPostalCode"].ToString();
                string dealerCountry = row["DealerCountry"].ToString();
                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);

                returnToForm.Rows.Add(sequenceNumber, userID, dealerName, dealerMail, discountIDFK, userType, dealerAdress, dealerCity, dealerPostalCode, dealerCountry, isDeleted ? "Yes" : "No");
            }
            return returnToForm;
        }

        public byte listSubDealer(string checkSubDealerName, string checkSubDealerMail)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT DealerName, DealerMail FROM SubDealerUsers";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubDealer sd = new SubDealer();
                    sd.subDealerName = reader.GetString(0);
                    sd.subDealerMail = reader.GetString(1);

                    if (checkSubDealerName == sd.subDealerName && checkSubDealerMail == sd.subDealerMail)
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

        public void addSubDealers(string dealerName, string dealerMail, string dealerAddress, string dealerCity, string dealerPostalCode, string dealerCountry, string selectedDiscountID, bool isDeleted)
        {
            cmd.CommandText = "INSERT INTO SubDealerUsers(DealerName, DealerMail, DealerAddress,DealerCity,DealerPostalCode,DealerCountry,DiscountIDFK,IsDeleted) VALUES (@dealerName, @dealerMail, @dealerAddress,@dealerCity,@dealerPostalCode,@dealerCountry,@discountIDFK,@isDeleted)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dealerName", dealerName);
            cmd.Parameters.AddWithValue("@dealerMail", dealerMail);
            cmd.Parameters.AddWithValue("@dealerAddress", dealerAddress);
            cmd.Parameters.AddWithValue("@dealerCity", dealerCity);
            cmd.Parameters.AddWithValue("@dealerPostalCode", dealerPostalCode);
            cmd.Parameters.AddWithValue("@dealerCountry", dealerCountry);
            cmd.Parameters.AddWithValue("@discountIDFK", selectedDiscountID);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sub Dealer added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add sub dealer, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editSubDealers(string subDealerID, string dealerName, string dealerMail, string dealerAddress, string dealerCity, string dealerPostalCode, string dealerCountry, string selectedDiscountID, bool isDeleted)
        {
            cmd.CommandText = "UPDATE SubDealerUsers SET DealerName=@dealerName, DealerMail=@dealerMail, DealerAddress=@dealerAddress, DealerCity=@dealerCity, DealerPostalCode=@dealerPostalCode, DealerCountry=@dealerCountry, DiscountIDFK=@discountIDFK, IsDeleted=@isDeleted WHERE SubDealerUserID=@subDealerID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@subDealerID", subDealerID);
            cmd.Parameters.AddWithValue("@dealerName", dealerName);
            cmd.Parameters.AddWithValue("@dealerMail", dealerMail);
            cmd.Parameters.AddWithValue("@dealerAddress", dealerAddress);
            cmd.Parameters.AddWithValue("@dealerCity", dealerCity);
            cmd.Parameters.AddWithValue("@dealerPostalCode", dealerPostalCode);
            cmd.Parameters.AddWithValue("@dealerCountry", dealerCountry);
            cmd.Parameters.AddWithValue("@discountIDFK", selectedDiscountID);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sub Dealer edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit sub dealer, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editSubDealers(string subDealerID, string dealerAddress, string dealerCity, string dealerPostalCode, string dealerCountry, string selectedDiscountID, bool isDeleted)
        {
            cmd.CommandText = "UPDATE SubDealerUsers SET DealerAddress=@dealerAddress, DealerCity=@dealerCity, DealerPostalCode=@dealerPostalCode, DealerCountry=@dealerCountry, DiscountIDFK=@discountIDFK, IsDeleted=@isDeleted WHERE SubDealerUserID=@subDealerID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@subDealerID", subDealerID);
            cmd.Parameters.AddWithValue("@dealerAddress", dealerAddress);
            cmd.Parameters.AddWithValue("@dealerCity", dealerCity);
            cmd.Parameters.AddWithValue("@dealerPostalCode", dealerPostalCode);
            cmd.Parameters.AddWithValue("@dealerCountry", dealerCountry);
            cmd.Parameters.AddWithValue("@discountIDFK", selectedDiscountID);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sub Dealer edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit sub dealer, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region MainDealer
        public DataTable subMainDealerDataBind()
        {
            cmd.CommandText = "SELECT * FROM MainDealerSettings";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("User ID", typeof(int));
            returnToForm.Columns.Add("Dealer Name", typeof(string));
            returnToForm.Columns.Add("Dealer Mail", typeof(string));
            returnToForm.Columns.Add("Dealer Address", typeof(string));
            returnToForm.Columns.Add("Dealer City", typeof(string));
            returnToForm.Columns.Add("Dealer Postal Code", typeof(string));
            returnToForm.Columns.Add("Dealer Country", typeof(string));
            returnToForm.Columns.Add("Invoice Tax Amount", typeof(string));
            returnToForm.Columns.Add("Image", typeof(System.Drawing.Image));
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ApplicationImages");
            imagePath = Path.GetFullPath(imagePath);
            foreach (DataRow row in temporaryDataTable.Rows)
            {
                string userID = row["SettingID"].ToString();
                string dealerName = row["DealerName"].ToString();
                string dealerMail = row["Mail"].ToString();
                string dealerAdress = row["Adress"].ToString();
                string dealerCity = row["City"].ToString();
                string dealerPostalCode = row["PostalCode"].ToString();
                string dealerCountry = row["Country"].ToString();
                string invoiceTaxAmount = row["InvoiceTaxAmount"].ToString();
                string dealerImage = row["Image"].ToString();
                string fullPath = Path.Combine(imagePath, dealerImage);

                System.Drawing.Image img = null;
                if (File.Exists(fullPath))
                {
                    img = System.Drawing.Image.FromFile(fullPath);

                }
                returnToForm.Rows.Add(userID, dealerName, dealerMail, dealerAdress, dealerCity, dealerPostalCode, dealerCountry, invoiceTaxAmount, img);
            }
            return returnToForm;
        }

        public void editMainDealers(string mainDealerUserID, string mainDealerName, string mainDealerMail, string mainDealerAddress, string mainDealerCity, string mainDealerPostalCode, string mainDealerCountry, decimal mainTaxAmount, string image)
        {
            cmd.CommandText = "UPDATE MainDealerSettings SET DealerName=@dealerName, Mail=@dealerMail, Adress=@dealerAdress, City=@dealerCity, PostalCode=@dealerPostalCode, Country=@country, InvoiceTaxAmount=@invoiceTaxAmount, Image=@image  WHERE SettingID=@mainDealerUserID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mainDealerUserID", mainDealerUserID);
            cmd.Parameters.AddWithValue("@dealerName", mainDealerName);
            cmd.Parameters.AddWithValue("@dealerMail", mainDealerMail);
            cmd.Parameters.AddWithValue("@dealerAdress", mainDealerAddress);
            cmd.Parameters.AddWithValue("@dealerCity", mainDealerCity);
            cmd.Parameters.AddWithValue("@dealerPostalCode", mainDealerPostalCode);
            cmd.Parameters.AddWithValue("@country", mainDealerCountry);
            cmd.Parameters.AddWithValue("@invoiceTaxAmount", mainTaxAmount);
            cmd.Parameters.AddWithValue("@image", image);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Main Dealer edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit main dealer, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public string listImageForEditMainDealer(string mainDealerIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT Image FROM MainDealerSettings WHERE SettingID=@settingID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@settingID", mainDealerIDForCheck);
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

        #region MainUser
        public DataTable userDataBind()
        {
            cmd.CommandText = "SELECT * FROM MainDealerUsers";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("User ID", typeof(int));
            returnToForm.Columns.Add("User Name", typeof(string));
            returnToForm.Columns.Add("User Password", typeof(string));
            returnToForm.Columns.Add("User Type", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            short sequenceNumber = 0;
            foreach (DataRow row in temporaryDataTable.Rows)
            {
                sequenceNumber++;
                string userID = row["MainUserID"].ToString();
                string userName = row["UserName"].ToString();
                string userPassword = row["UserPassword"].ToString();
                string userType = row["UserType"].ToString();
                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);

                returnToForm.Rows.Add(sequenceNumber, userID, userName, userPassword, userType, isDeleted ? "Yes" : "No");
            }
            return returnToForm;
        }

        public byte listUser(string checkUserName, string checkUserPassword)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT UserName, UserPassword FROM MainDealerUsers";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MainUser mu = new MainUser();
                    mu.userName = reader.GetString(0);
                    mu.userPassword = reader.GetString(1);

                    if (checkUserName == mu.userName && checkUserPassword == mu.userPassword)
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

        public byte listUser(string checkUserName)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT UserName FROM MainDealerUsers";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MainUser mu = new MainUser();
                    mu.userName = reader.GetString(0);

                    if (checkUserName == mu.userName)
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

        public byte checkAdmin()
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT UserType FROM MainDealerUsers WHERE IsDeleted = @isDeleted";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isDeleted", false);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MainUser mu = new MainUser();
                    mu.userType = reader.GetString(0);

                    if (mu.userType == "Admin")
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

        public void addUser(string userName, string userPassword, string userType, bool isDeleted)
        {
            cmd.CommandText = "INSERT INTO MainDealerUsers(UserName, UserPassword, UserType, IsDeleted) VALUES (@userName, @userPassword, @userType, @isDeleted)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add user, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editUser(string userID, string userName, string userPassword, string userType, bool isDeleted)
        {
            cmd.CommandText = "UPDATE MainDealerUsers SET UserName=@userName, UserPassword=@userPassword, UserType=@userType,IsDeleted=@isDeleted WHERE MainUserID=@mainUserID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mainUserID", userID);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit user, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void editUser(string userID, string userPassword, string userType, bool isDeleted)
        {
            cmd.CommandText = "UPDATE MainDealerUsers SET UserPassword=@userPassword, UserType=@userType,IsDeleted=@isDeleted WHERE MainUserID=@mainUserID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mainUserID", userID);
            cmd.Parameters.AddWithValue("@userPassword", userPassword);
            cmd.Parameters.AddWithValue("@userType", userType);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit user, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region SendToSubDealer

        public DataTable SendToSubDealerDataBind()
        {
            cmd.CommandText = "SELECT * FROM SendToSubDealers";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;
            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);
            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("Shipment Number", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(string));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("CategoryIDFK", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("ProductIDFK", typeof(string));
            returnToForm.Columns.Add("Product Item Number", typeof(string));
            returnToForm.Columns.Add("Product Name", typeof(string));
            returnToForm.Columns.Add("Product Units In Stock", typeof(string));
            returnToForm.Columns.Add("Product Quantity Per Unit", typeof(string));
            returnToForm.Columns.Add("Product Description", typeof(string));
            returnToForm.Columns.Add("MainUserIDFK", typeof(string));
            returnToForm.Columns.Add("User Making Transaction", typeof(string));
            returnToForm.Columns.Add("SubDealerIDFK", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Name", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Type", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Discount Amount", typeof(string));
            returnToForm.Columns.Add("Send Date", typeof(DateTime));
            returnToForm.Columns.Add("Send Quantity", typeof(short));
            returnToForm.Columns.Add("Unit Price", typeof(decimal));
            returnToForm.Columns.Add("Sub Total Price", typeof(decimal));
            returnToForm.Columns.Add("Tax", typeof(decimal));
            returnToForm.Columns.Add("Total Price", typeof(decimal));
            returnToForm.Columns.Add("Discounted Price", typeof(decimal));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Product Image", typeof(System.Drawing.Image));
            returnToForm.Columns.Add("ImageFileName", typeof(string));
            short sequenceNumber = 0;
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                if (!isBrandDeleteOrDeactive(row["BrandIDFK"].ToString()))
                {
                    if (!isCategoryDeleteOrDeactive(row["CategoryIDFK"].ToString()))
                    {
                        if (!isProductDeleteOrDeactive(row["ProductIDFK"].ToString()))
                        {
                            bool checkDeleted = Convert.ToBoolean(row["IsDeleted"]);
                            if (!checkDeleted)
                            {
                                sequenceNumber++;
                                string shipmenNumber = row["SendID"].ToString();
                                string brandIDFK = row["BrandIDFK"].ToString();
                                string brandName = getBrandNameForProducts(brandIDFK);
                                string categoryIDFK = row["CategoryIDFK"].ToString();
                                string categoryName = getCategoryNameForProducts(categoryIDFK);
                                string productIDFK = row["ProductIDFK"].ToString();
                                string productItemNumber = row["ProductItemNumber"].ToString();
                                string productName = getProductNameForSendToSubDealer(row["ProductIDFK"].ToString());
                                string productUnitsInStock = getProductUnitsInStock(row["ProductIDFK"].ToString());
                                string productQuantityPerUnit = getProductQuantityPerUnit(row["ProductIDFK"].ToString());
                                string productDescription = getProductDescription(row["ProductIDFK"].ToString());
                                string mainUserIDFK = row["MainUserIDFK"].ToString();
                                string mainUserNameAndType = getMainUserNameAndType(row["mainUserIDFK"].ToString());
                                string subDealerIDFK = row["SubDealerUserIDFK"].ToString();
                                string subDealerName = getSubDealerName(subDealerIDFK);
                                string subDealerDiscountIDFK = getSubDealerDiscountIDFK(subDealerIDFK);
                                string subDealerDiscountType = getDiscountType(subDealerDiscountIDFK);
                                string subDealerDiscountAmount = getDiscountAmount(subDealerDiscountIDFK);
                                DateTime sendDate = Convert.ToDateTime(row["SendDate"]);
                                short sendQuantity = Convert.ToInt16(row["SendQuantity"]);
                                decimal unitPrice = Convert.ToDecimal(getUnitPrice(productIDFK));
                                decimal subTotalPrice = Convert.ToDecimal(row["SubTotalPrice"]);
                                decimal tax = Convert.ToDecimal(getTax("1"));
                                decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                                decimal discountedPrice = Convert.ToDecimal(row["DiscountedPrice"]);
                                string description = row["Description"].ToString();
                                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                                string imageFile = listImageForEditProducts(productIDFK);
                                string fullPath = Path.Combine(imagePath, imageFile);
                                System.Drawing.Image img = null;
                                if (File.Exists(fullPath))
                                {
                                    img = System.Drawing.Image.FromFile(fullPath);

                                }
                                returnToForm.Rows.Add(sequenceNumber, shipmenNumber, brandIDFK, brandName, categoryIDFK, categoryName, productIDFK, productItemNumber, productName, productUnitsInStock, productQuantityPerUnit, productDescription, mainUserIDFK, mainUserNameAndType, subDealerIDFK, subDealerName, subDealerDiscountType, subDealerDiscountAmount, sendDate, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, discountedPrice, description, isDeleted ? "Yes" : "No", img, imageFile);
                            }
                        }
                    }
                }
            }
            return returnToForm;
        }

        public DataTable SendToSubDealerListDataBind(DateTime checkStartDate, DateTime checkEndDate, bool listIsDeleted)
        {
            cmd.CommandText = "SELECT * FROM SendToSubDealers";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;
            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);
            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("Shipment Number", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(string));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("CategoryIDFK", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("ProductIDFK", typeof(string));
            returnToForm.Columns.Add("Product Item Number", typeof(string));
            returnToForm.Columns.Add("Product Name", typeof(string));
            returnToForm.Columns.Add("Product Description", typeof(string));
            returnToForm.Columns.Add("MainUserIDFK", typeof(string));
            returnToForm.Columns.Add("User Making Transaction", typeof(string));
            returnToForm.Columns.Add("SubDealerIDFK", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Name", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Type", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Discount Amount", typeof(string));
            returnToForm.Columns.Add("Send Date", typeof(DateTime));
            returnToForm.Columns.Add("Send Quantity", typeof(short));
            returnToForm.Columns.Add("Unit Price", typeof(decimal));
            returnToForm.Columns.Add("Sub Total Price", typeof(decimal));
            returnToForm.Columns.Add("Tax", typeof(decimal));
            returnToForm.Columns.Add("Total Price", typeof(decimal));
            returnToForm.Columns.Add("Discounted Price", typeof(decimal));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Product Image", typeof(System.Drawing.Image));
            returnToForm.Columns.Add("ImageFileName", typeof(string));
            short sequenceNumber = 0;
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                if (listIsDeleted == Convert.ToBoolean(row["IsDeleted"]))
                {
                    DateTime sendDate = Convert.ToDateTime(row["SendDate"]);
                    if (checkStartDate != null)
                    {
                        if (checkEndDate != null)
                        {
                            if (sendDate >= checkStartDate && sendDate <= checkEndDate)
                            {
                                sequenceNumber++;
                                string shipmenNumber = row["SendID"].ToString();
                                string brandIDFK = row["BrandIDFK"].ToString();
                                string brandName = getBrandNameForProducts(brandIDFK);
                                string categoryIDFK = row["CategoryIDFK"].ToString();
                                string categoryName = getCategoryNameForProducts(categoryIDFK);
                                string productIDFK = row["ProductIDFK"].ToString();
                                string productItemNumber = row["ProductItemNumber"].ToString();
                                string productName = getProductNameForSendToSubDealer(row["ProductIDFK"].ToString());
                                string productDescription = getProductDescription(row["ProductIDFK"].ToString());
                                string mainUserIDFK = row["MainUserIDFK"].ToString();
                                string mainUserNameAndType = getMainUserNameAndType(row["mainUserIDFK"].ToString());
                                string subDealerIDFK = row["SubDealerUserIDFK"].ToString();
                                string subDealerName = getSubDealerName(subDealerIDFK);
                                string subDealerDiscountIDFK = getSubDealerDiscountIDFK(subDealerIDFK);
                                string subDealerDiscountType = getDiscountType(subDealerDiscountIDFK);
                                string subDealerDiscountAmount = getDiscountAmount(subDealerDiscountIDFK);
                                short sendQuantity = Convert.ToInt16(row["SendQuantity"]);
                                decimal unitPrice = Convert.ToDecimal(getUnitPrice(productIDFK));
                                decimal subTotalPrice = Convert.ToDecimal(row["SubTotalPrice"]);
                                decimal tax = Convert.ToDecimal(getTax("1"));
                                decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                                decimal discountedPrice = Convert.ToDecimal(row["DiscountedPrice"]);
                                string description = row["Description"].ToString();
                                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                                string imageFile = listImageForEditProducts(productIDFK);
                                string fullPath = Path.Combine(imagePath, imageFile);
                                System.Drawing.Image img = null;
                                if (File.Exists(fullPath))
                                {
                                    img = System.Drawing.Image.FromFile(fullPath);

                                }
                                returnToForm.Rows.Add(sequenceNumber, shipmenNumber, brandIDFK, brandName, categoryIDFK, categoryName, productIDFK, productItemNumber, productName, productDescription, mainUserIDFK, mainUserNameAndType, subDealerIDFK, subDealerName, subDealerDiscountType, subDealerDiscountAmount, sendDate, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, discountedPrice, description, isDeleted ? "Yes" : "No", img, imageFile);
                            }
                        }
                        else
                        {
                            MessageBox.Show("End date not null, please select end date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start date not null, please select start date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return returnToForm;
        }
        public DataTable SendToSubDealerListDataBind(DateTime checkStartDate, DateTime checkEndDate, string SubDealerIDFK, bool listIsDeleted)
        {
            cmd.CommandText = "SELECT * FROM SendToSubDealers WHERE SubDealerUserIDFK=@subDealerUserIDFK";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@subDealerUserIDFK", SubDealerIDFK);
            da.SelectCommand = cmd;
            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);
            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("S/N", typeof(string));
            returnToForm.Columns.Add("Shipment Number", typeof(string));
            returnToForm.Columns.Add("BrandIDFK", typeof(string));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("CategoryIDFK", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("ProductIDFK", typeof(string));
            returnToForm.Columns.Add("Product Item Number", typeof(string));
            returnToForm.Columns.Add("Product Name", typeof(string));
            returnToForm.Columns.Add("Product Description", typeof(string));
            returnToForm.Columns.Add("MainUserIDFK", typeof(string));
            returnToForm.Columns.Add("User Making Transaction", typeof(string));
            returnToForm.Columns.Add("SubDealerIDFK", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Name", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Type", typeof(string));
            returnToForm.Columns.Add("Sub Dealer Discount Amount", typeof(string));
            returnToForm.Columns.Add("Send Date", typeof(DateTime));
            returnToForm.Columns.Add("Send Quantity", typeof(short));
            returnToForm.Columns.Add("Unit Price", typeof(decimal));
            returnToForm.Columns.Add("Sub Total Price", typeof(decimal));
            returnToForm.Columns.Add("Tax", typeof(decimal));
            returnToForm.Columns.Add("Total Price", typeof(decimal));
            returnToForm.Columns.Add("Discounted Price", typeof(decimal));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Product Image", typeof(System.Drawing.Image));
            returnToForm.Columns.Add("ImageFileName", typeof(string));
            short sequenceNumber = 0;
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\ProductImages");
            imagePath = Path.GetFullPath(imagePath);
            foreach (DataRow row in temporaryDataTable.Rows)
            {

                if (listIsDeleted == Convert.ToBoolean(row["IsDeleted"]))
                {
                    DateTime sendDate = Convert.ToDateTime(row["SendDate"]);
                    if (checkStartDate != null)
                    {
                        if (checkEndDate != null)
                        {
                            if (sendDate >= checkStartDate && sendDate <= checkEndDate)
                            {
                                sequenceNumber++;
                                string shipmenNumber = row["SendID"].ToString();
                                string brandIDFK = row["BrandIDFK"].ToString();
                                string brandName = getBrandNameForProducts(brandIDFK);
                                string categoryIDFK = row["CategoryIDFK"].ToString();
                                string categoryName = getCategoryNameForProducts(categoryIDFK);
                                string productIDFK = row["ProductIDFK"].ToString();
                                string productItemNumber = row["ProductItemNumber"].ToString();
                                string productName = getProductNameForSendToSubDealer(row["ProductIDFK"].ToString());
                                string productDescription = getProductDescription(row["ProductIDFK"].ToString());
                                string mainUserIDFK = row["MainUserIDFK"].ToString();
                                string mainUserNameAndType = getMainUserNameAndType(row["mainUserIDFK"].ToString());
                                string subDealerIDFK = row["SubDealerUserIDFK"].ToString();
                                string subDealerName = getSubDealerName(subDealerIDFK);
                                string subDealerDiscountIDFK = getSubDealerDiscountIDFK(subDealerIDFK);
                                string subDealerDiscountType = getDiscountType(subDealerDiscountIDFK);
                                string subDealerDiscountAmount = getDiscountAmount(subDealerDiscountIDFK);
                                short sendQuantity = Convert.ToInt16(row["SendQuantity"]);
                                decimal unitPrice = Convert.ToDecimal(getUnitPrice(productIDFK));
                                decimal subTotalPrice = Convert.ToDecimal(row["SubTotalPrice"]);
                                decimal tax = Convert.ToDecimal(getTax("1"));
                                decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                                decimal discountedPrice = Convert.ToDecimal(row["DiscountedPrice"]);
                                string description = row["Description"].ToString();
                                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                                string imageFile = listImageForEditProducts(productIDFK);
                                string fullPath = Path.Combine(imagePath, imageFile);
                                System.Drawing.Image img = null;
                                if (File.Exists(fullPath))
                                {
                                    img = System.Drawing.Image.FromFile(fullPath);

                                }
                                returnToForm.Rows.Add(sequenceNumber, shipmenNumber, brandIDFK, brandName, categoryIDFK, categoryName, productIDFK, productItemNumber, productName, productDescription, mainUserIDFK, mainUserNameAndType, subDealerIDFK, subDealerName, subDealerDiscountType, subDealerDiscountAmount, sendDate, sendQuantity, unitPrice, subTotalPrice, tax, totalPrice, discountedPrice, description, isDeleted ? "Yes" : "No", img, imageFile);
                            }
                        }
                        else
                        {

                            MessageBox.Show("End date not null, please select end date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Start date not null, please select start date!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return returnToForm;
        }

        public string getProductNameForSendToSubDealer(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT ProductName FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string productName = Convert.ToString(cmd.ExecuteScalar());
                return productName;
            }
            finally
            {
                con.Close();
            }
        }

        public string getProductUnitsInStock(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT UnitsInStock FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string productUnitsInStock = Convert.ToString(cmd.ExecuteScalar());
                return productUnitsInStock;
            }
            finally
            {
                con.Close();
            }
        }

        public string getProductQuantityPerUnit(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT QuantityPerUnit FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string productQuantityPerUnit = Convert.ToString(cmd.ExecuteScalar());
                return productQuantityPerUnit;
            }
            finally
            {
                con.Close();
            }
        }

        public string getProductDescription(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT Description FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string description = Convert.ToString(cmd.ExecuteScalar());
                return description;
            }
            finally
            {
                con.Close();
            }
        }
        public string getUnitPrice(string productIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT UnitPrice FROM Products WHERE ProductID=@productID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@productID", productIDForCheck);
                con.Open();
                string unitPrice = Convert.ToString(cmd.ExecuteScalar());
                return unitPrice;
            }
            finally
            {
                con.Close();
            }
        }

        public void updateUnitsInStock(string productIDForCheck, decimal newStock)
        {
            cmd.CommandText = "UPDATE Products SET UnitsInStock=@unitsInStock WHERE ProductID=@productID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@unitsInStock", newStock);
            cmd.Parameters.AddWithValue("@productID", productIDForCheck);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Product's stock level edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit product's stock level, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public string getSubDealerName(string subDealerIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT DealerName FROM SubDealerUsers WHERE SubDealerUserID=@subDealerUserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@subDealerUserID", subDealerIDForCheck);
                con.Open();
                string subDealerName = Convert.ToString(cmd.ExecuteScalar());
                return subDealerName;
            }
            finally
            {
                con.Close();
            }
        }

        public string getSubDealerDiscountIDFK(string subDealerIDForCheck)
        {
            try
            {
                cmd.CommandText = "SELECT DiscountIDFK FROM SubDealerUsers WHERE SubDealerUserID=@subDealerUserID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@subDealerUserID", subDealerIDForCheck);
                con.Open();
                string productName = Convert.ToString(cmd.ExecuteScalar());
                return productName;
            }
            finally
            {
                con.Close();
            }
        }

        public decimal getTax(string settingID)
        {
            try
            {
                cmd.CommandText = "SELECT InvoiceTaxAmount FROM MainDealerSettings WHERE SettingID=@settingID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@settingID", settingID);
                con.Open();
                decimal tax = Convert.ToDecimal(cmd.ExecuteScalar());
                return tax;
            }
            finally
            {
                con.Close();
            }
        }

        public List<SubDealer> getSubDealers()
        {
            List<SubDealer> subDealers = new List<SubDealer>();
            try
            {
                cmd.CommandText = "SELECT * FROM SubDealerUsers";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubDealer sd = new SubDealer();
                    sd.subDealerUserID = reader.GetInt32(0);
                    sd.subDealerName = reader.GetString(1);
                    sd.discountIDFK = reader.GetInt32(3);
                    sd.isDeleted = reader.GetBoolean(8);
                    if (!sd.isDeleted)
                    {
                        subDealers.Add(sd);
                    }
                }
                return subDealers;
            }
            finally
            {
                con.Close();
            }
        }

        public void sendToSubDealers(string brandIDFK, string categoryIDFK, string productIDFK, string productItemNumber, string mainUserIDFK, string subDealerUserIDFK, DateTime sendDate, short sendQuantity, decimal unitPrice, decimal subTotalPrice, decimal tax, decimal totalPrice, decimal discountedPrice, string description, bool isDeleted)
        {
            cmd.CommandText = "INSERT INTO SendToSubDealers(BrandIDFK, CategoryIDFK, ProductIDFK,ProductItemNumber, MainUserIDFK,SubDealerUserIDFK,SendDate,SendQuantity,UnitPrice,SubTotalPrice,Tax,TotalPrice,DiscountedPrice,Description,IsDeleted) VALUES (@brandIDFK, @categoryIDFK, @productIDFK ,@productItemNumber ,@mainUserIDFK, @subDealerUserIDFK, @sendDate, @sendQuantity, @unitPrice, @subTotalPrice, @tax, @totalPrice, @discountedPrice, @description, @isDeleted)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
            cmd.Parameters.AddWithValue("@productIDFK", productIDFK);
            cmd.Parameters.AddWithValue("@productItemNumber", productItemNumber);
            cmd.Parameters.AddWithValue("@mainUserIDFK", mainUserIDFK);
            cmd.Parameters.AddWithValue("@subDealerUserIDFK", subDealerUserIDFK);
            cmd.Parameters.AddWithValue("@sendDate", sendDate);
            cmd.Parameters.AddWithValue("@sendQuantity", sendQuantity);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@subTotalPrice", subTotalPrice);
            cmd.Parameters.AddWithValue("@tax", tax);
            cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
            cmd.Parameters.AddWithValue("@discountedPrice", discountedPrice);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your products added to list \"send to sub dealers.\"", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send sub dealer, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        //public void editSendToSubDealers(string sendID, string brandIDFK, string categoryIDFK, string productIDFK, string productItemNumber, string mainUserIDFK, string subDealerUserIDFK, short sendQuantity, decimal unitPrice, decimal subTotalPrice, decimal tax, decimal totalPrice, decimal discountedPrice, string description)
        //{
        //    cmd.CommandText = "UPDATE SendToSubDealers SET BrandIDFK=@brandIDFK, CategoryIDFK=@categoryIDFK, ProductIDFK=@productIDFK, ProductItemNumber=@productItemNumber, MainUserIDFK=@mainUserIDFK, SubDealerUserIDFK=@subDealerUserIDFK, SendQuantity=@sendQuantity, UnitPrice=@unitPrice, SubTotalPrice=@subTotalPrice, Tax=@tax, TotalPrice=@totalPrice, DiscountedPrice=@discountedPrice, Description=@description WHERE SendID=@sendID";

        //    cmd.Parameters.Clear();
        //    cmd.Parameters.AddWithValue("@sendID", sendID);
        //    cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
        //    cmd.Parameters.AddWithValue("@categoryIDFK", categoryIDFK);
        //    cmd.Parameters.AddWithValue("@productIDFK", productIDFK);
        //    cmd.Parameters.AddWithValue("@productItemNumber", productItemNumber);
        //    cmd.Parameters.AddWithValue("@mainUserIDFK", mainUserIDFK);
        //    cmd.Parameters.AddWithValue("@subDealerUserIDFK", subDealerUserIDFK);
        //    cmd.Parameters.AddWithValue("@sendQuantity", sendQuantity);
        //    cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
        //    cmd.Parameters.AddWithValue("@subTotalPrice", subTotalPrice);
        //    cmd.Parameters.AddWithValue("@tax", tax);
        //    cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
        //    cmd.Parameters.AddWithValue("@discountedPrice", discountedPrice);
        //    cmd.Parameters.AddWithValue("@description", description);

        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Shipment list edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Unable to edit shipment list, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public void editSendToSubDealers(string sendID, string description, bool isDeleted)
        {
            cmd.CommandText = "UPDATE SendToSubDealers SET Description=@description, IsDeleted=@isDeleted WHERE SendID=@sendID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sendID", sendID);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Shipment list edited successfully.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit shipment list, please check the information you entered!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        //public List<SendListProductToSubDealers> getSendInformationList()
        //{
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM SendToSubDealers";
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        List<SendListProductToSubDealers> sl = new List<SendListProductToSubDealers>();
        //        while (reader.Read())
        //        {
        //            SendListProductToSubDealers slp = new SendListProductToSubDealers();
        //            slp.sendID = reader.GetInt32(0);
        //            slp.brandIDFK = reader.GetInt32(1);
        //            slp.categoryIDFK = reader.GetInt32(2);
        //            slp.productIDFK = reader.GetInt32(3);
        //            slp.productItemNumber = reader.GetString(4);
        //            slp.mainUserIDFK = reader.GetInt32(5);
        //            slp.subDealerUserIDFK = reader.GetInt32(6);
        //            slp.sendDate = reader.GetDateTime(7);
        //            slp.sendQuantity = reader.GetInt16(8);
        //            slp.unitPrice = reader.GetDecimal(9);
        //            slp.subTotalPrice = reader.GetDecimal(10);
        //            slp.tax = reader.GetDecimal(11);
        //            slp.totalPrice = reader.GetDecimal(12);
        //            slp.discountedPrice = reader.GetDecimal(13);
        //            slp.description = reader.GetString(14);
        //            sl.Add(slp);
        //        }
        //        return sl;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        #endregion

        #region Login

        public MainUser getUserInformation(string userName, string password)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM MainDealerUsers WHERE UserName=@userName AND UserPassword=@userPassword";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@userPassword", password);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                MainUser mu = null;
                while (reader.Read())
                {
                    mu = new MainUser();
                    mu.mainUserID = reader.GetInt32(0);
                    mu.userName = reader.GetString(1);
                    mu.userPassword = reader.GetString(2);
                    mu.userType = reader.GetString(3);
                    mu.isDeleted = reader.GetBoolean(4);
                }
                return mu;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public string getMainUserNameAndType(string mainUserIDFK)
        {
            try
            {
                cmd.CommandText = "SELECT UserName, UserType FROM MainDealerUsers WHERE MainUserID=@mainUserIDFK";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mainUserIDFK", mainUserIDFK);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                MainUser mu = null;
                while (reader.Read())
                {
                    mu = new MainUser();
                    mu.userName = reader.GetString(0);
                    mu.userType = reader.GetString(1);

                }
                return mu.userName + "/" + mu.userType;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

    }
}
