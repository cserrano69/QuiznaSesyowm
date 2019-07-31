using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Quiz3.Models
{
    public class DBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Test2"].ToString();
            con = new SqlConnection(constring);
        }

        public bool InsertItem(User iList)
        {
            connection();
            string query = "INSERT INTO User VALUES('" + iList.Name + "','" + iList.SalesAgent + "','" + iList.VehicleName + "','" + iList.OSP + "','" + iList.DSP + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<User> GetList()
        {
            connection();
            List<User> ilist = new List<User>();
            string query = "SELECT * FROM User";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                ilist.Add(new User
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Name = Convert.ToString(dr["Name"]),
                    SalesAgent = Convert.ToString(dr["Agent"]),
                    VehicleName = Convert.ToString(dr["Item"]),
                    OSP = Convert.ToDouble(dr["SRP"]),
                    DSP = Convert.ToDouble(dr["TSP"])

                });
            }

            return ilist;
        }
    }
}