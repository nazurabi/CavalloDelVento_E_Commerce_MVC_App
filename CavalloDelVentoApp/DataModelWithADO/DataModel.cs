using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

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
            DataTable dt = new DataTable();
            dt.Columns.Add("Brand Name");
            dt.Columns.Add("Is Brand Active For Sale");
            dt.Columns.Add("Brand Image");
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
            commandBuilder.DataAdapter = da;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }

        #endregion
    }
}
