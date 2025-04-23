using System;
using System.Collections.Generic;
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
    }
}
