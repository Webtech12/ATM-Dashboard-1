using MySql.Data.MySqlClient;
using System;
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
                connection = new MySqlConnection("datasource=localhost;port=3306;username=root;Convert Zero Datetime=True; password=");
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("connection Failed"+ e.Message);
            }
        }

        public static MySqlCommand RunQuery(string query, string agentname)
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


    }
}
