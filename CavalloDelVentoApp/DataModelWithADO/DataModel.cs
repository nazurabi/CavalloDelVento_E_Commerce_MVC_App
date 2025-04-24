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
            cmd.CommandText = "SELECT * FROM Brands";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;

            DataTable temporaryDataTable = new DataTable();
            da.Fill(temporaryDataTable);

            DataTable returnToForm = new DataTable();
            returnToForm.Columns.Add("Brand Name", typeof(string));
            returnToForm.Columns.Add("Is Brand Active For Sale", typeof(string));
            returnToForm.Columns.Add("Brand Image", typeof(System.Drawing.Image));


            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\..\FormForDataModel\Images\BrandImages");
            imagePath = Path.GetFullPath(imagePath);

            foreach (DataRow row in temporaryDataTable.Rows)
            {
                string brandName = row["BrandName"].ToString();
                bool isActiveForSale = Convert.ToBoolean(row["IsDeleted"]);
                string imageFile = row["Image"].ToString();

                string fullPath = Path.Combine(imagePath, imageFile);
                System.Drawing.Image img = null;

                if (File.Exists(fullPath))
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        img = System.Drawing.Image.FromStream(fs);
                    }
                }
                returnToForm.Rows.Add(brandName, isActiveForSale ? "Yes" : "No", img);
            }
            return returnToForm;
        }

        #endregion
    }
}
