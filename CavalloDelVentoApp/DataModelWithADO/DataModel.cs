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
            returnToForm.Columns.Add("BrandID", typeof(int));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("Is Brand Active For Sale", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Brand Image", typeof(string));


            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\BrandImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                string brandID = row["BrandID"].ToString();
                string brandName = row["BrandName"].ToString();
                bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                string imageFile = row["Image"].ToString();
                string fullPath = Path.Combine(imagePath, imageFile);

                returnToForm.Rows.Add(brandID, brandName, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath);
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
                MessageBox.Show("Brand added successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add brand, please check the information you entered!");
            }
            finally
            {
                con.Close();
            }
        }

        public void editBrand(string brandID, string brandName, bool isActive, string brandImage)
        {
            cmd.CommandText = "UPDATE Brands SET BrandName=@brandName, IsActive=@isActive, Image=@brandImage WHERE BrandID=@brandID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandID", brandID);
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.Parameters.AddWithValue("@brandImage", brandImage);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Brand edited successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit brand, please check the information you entered!");
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
        #endregion

        #region Categories Applications

        public DataTable categoryDataBind()
        {
            #region With fullPath (Image pulls database by string)

            cmd.CommandText = "SELECT * FROM Categories";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("BrandIDFK", typeof(int));
            returnToForm.Columns.Add("CategoryID", typeof(int));
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("Category Name", typeof(string));
            returnToForm.Columns.Add("Description", typeof(string));
            returnToForm.Columns.Add("Is Category Active For Sale", typeof(string));
            returnToForm.Columns.Add("Is Deleted", typeof(string));
            returnToForm.Columns.Add("Category Image", typeof(string));


            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\FormForDataModel\Images\CategoriesImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                string brandIDFK = row["BrandIDFK"].ToString();
                string categoryID = row["CategoryID"].ToString();
                string brandName = getBrandNameForCategories(brandIDFK);
                string categoryName = row["CategoryName"].ToString();
                string description = row["Description"].ToString();
                bool isActiveForSale = Convert.ToBoolean(row["IsActive"]);
                bool isDeleted = Convert.ToBoolean(row["IsDeleted"]);
                string imageFile = row["Image"].ToString();
                string fullPath = Path.Combine(imagePath, imageFile);

                returnToForm.Rows.Add(brandIDFK, categoryID, brandName, categoryName,description, isActiveForSale ? "Yes" : "No", isDeleted ? "Yes" : "No", fullPath);
            }

            return returnToForm;

            #endregion
        }

        public void addCategory(string brandIDFK, string categoryName, bool isDeleted, bool isActive, string description, string categoryImage)
        {
            cmd.CommandText = "INSERT INTO Categories(BrandIDFK, CategoryName, Description, Image, IsDeleted, IsActive) VALUES (@brandIDFK, @categoryName, @description, @categoryImage, @isDeleted, @isActive)";
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
                MessageBox.Show("Category added successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add category, please check the information you entered!");
            }
            finally
            {
                con.Close();
            }
        }

        public void editCategory(string categoryID, string brandIDFK, string categoryName, string description, bool isActive, string categoryImage)
        {
            cmd.CommandText = "UPDATE Categories SET BrandIDFK=@brandIDFK, CategoryName=@categoryName, Description=@description, IsActive=@isActive, Image=@categoryImage WHERE CategoryID=@categoryID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@brandIDFK", brandIDFK);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@categoryImage", categoryImage);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category edited successfully.");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to edit category, please check the information you entered!");
            }
            finally
            {
                con.Close();
            }
        }

        public byte listCategories(string checkCategoryName)
        {
            byte checkCounter = 0;
            try
            {
                cmd.CommandText = "SELECT CategoryName FROM Categories";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories();
                    category.categoryName = reader.GetString(0);
                    if (checkCategoryName == category.categoryName)
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
                    brands.Add(brand);
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

        #endregion
    }
}
