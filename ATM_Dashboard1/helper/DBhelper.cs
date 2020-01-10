using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace ATM_Dashboard1.helper
{
    public static class DBhelper
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        // Connection to the database
        public static void EstablishConn()
        {
            try
            {
                /* MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Database = "atmars_testdb";
                builder.Password = "admin";
                builder.SslMode = MySqlSslMode.None; */
                connection = new MySqlConnection("datasource=localhost;port=3306;username=root;Convert Zero Datetime=True;; password=;AllowUserVariables=True;");
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed"+ e.Message);
            }
        }

        public static MySqlCommand GetRelation(string query, string agentname)
        {
            try
            {
                
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@agentname", agentname);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed" + e.Message);
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand GetRelation(string query)
        {

            try
            {

                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed " + e.Message);
                connection.Close();
            }

            return cmd;
        }

        public  static string GetQuery(string table, string column, string reference, string input)
        {
            input = '"'+input+'"';
            string query = "SELECT " + column + " FROM atmars_testdb." + table + " where " + reference + " = "+input+" limit 1";
            return query;
        } 
        public  static string GetUnitUsers()
        {
            string query = "SELECT * FROM atmars_testdb.tblagent";
            return query;
        }

        public  static string getAgentUnits(int Initial)
        {
            string query = "SELECT agentunit FROM atmars_testdb.tblagent where agentcode = " + Initial +" ";
            return query;
        }

        public  static string GetSubjects()
        {
            string query = "SELECT * FROM atmars_testdb.subjectform";
            return query;
        }

        // Insert query (overloaded method)
        public static MySqlCommand Insert(string query, string Initial, string Onbehalf, string Subject,
                                         string Description, string datetime, int Roci,
                                         string Status, string Ari_kpi, string Dep_kpi, 
                                         string Dans, string closed_at)
        {
            //MessageBox.Show(closed_at);
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Initial", Initial);
                    cmd.Parameters.AddWithValue("@onbehalf", Onbehalf);
                    cmd.Parameters.AddWithValue("@subject", Subject);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@roci", Roci);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@ari_kpi", Ari_kpi);
                    cmd.Parameters.AddWithValue("@dep_kpi", Dep_kpi);
                    cmd.Parameters.AddWithValue("@dans", Dans);
                    cmd.Parameters.AddWithValue("@closed_at", closed_at);
                    cmd.ExecuteNonQuery();
                    
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed" + e.Message);
                connection.Close();
            }
            return cmd;
        }
        
        public static MySqlCommand insertLog(string query, long log_id, string datetime, string unit_id, string log_type, string log_table)
        {
            MessageBox.Show(log_table);
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@log_id", log_id);
                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@unit_id", unit_id);
                    cmd.Parameters.AddWithValue("@log_type", log_type);
                    cmd.Parameters.AddWithValue("@log_table", log_table);
                    cmd.ExecuteNonQuery();
                    
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed" + e.Message);
                connection.Close();
            }
            return cmd;
        }

    }
}
