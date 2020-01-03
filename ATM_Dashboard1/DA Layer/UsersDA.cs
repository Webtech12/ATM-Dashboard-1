using ATM_Dashboard1.helper;
using ATM_Dashboard1.PD_Layer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ATM_Dashboard1.DA_Layer
{
    public static class UsersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static Users RetrieveUser(string agentname)
        {
            string query = "SELECT * FROM atmars_testdb.tblagent where agentname = ?agentname limit 1";
            cmd = DBhelper.RunQuery(query, agentname);
            Users aUser = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string uName = dr["agentname"].ToString();
                    string password = dr["agentpassword"].ToString();
                    aUser = new Users(uName, password);
                }
            }
            return aUser;
        }
    }
}
