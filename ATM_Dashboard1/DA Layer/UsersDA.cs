﻿using ATM_Dashboard1.helper;
using ATM_Dashboard1.PD_Layer;
using MySql.Data.MySqlClient;
using System.Data;

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
            cmd = DBhelper.GetRelation(query, agentname);
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
                    string Initial = dr["agentcode"].ToString();
                    string Unit = dr["agentunit"].ToString();

                    aUser = new Users(uName, password, Unit, Initial);

                }
            }
            return aUser;
        }
    }
}
