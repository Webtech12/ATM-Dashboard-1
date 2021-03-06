﻿using MySql.Data.MySqlClient;
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

        // Session Credentials
        public static string credsUnits;
        public static string credsInitial;
        public static string credsUser;



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

        public  static string GetQueryRwy(string table, string column, string reference, string input)
        {
            //input = '"'+input+'"';
            string rwy = "";
            string query = "SELECT " + column + " FROM atmars_testdb." + table + " where " + reference + " = "+input+"";

            cmd = GetRelation(query);
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    rwy = dr["runway"].ToString().ToUpper();
                }
            }
            return rwy;
        } 

        public  static string GetQueryRWY(string table, string column, string reference, string input, int unit_id)
        {
            input = '"'+input+'"';
            string query = "SELECT " + column + " FROM atmars_testdb." + table + " where " + reference + " = "+input+" AND unit_id ="+unit_id+" limit 1";
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
        
        public  static string GetDatas(string tblname)
        {
            string query = "SELECT * FROM atmars_testdb."+ tblname + " ";
            return query;
        }

        public static string Fill_met()
        {
            string paramUrl = "GetLatestUpdates/GetLatestUpdates/lastEntry/{met_condition}/{condition}/{unit_id}";
            return paramUrl;
        }
        
        public static string Fill_rwy()
        {
            string paramUrl = "GetLatestUpdates/GetLatestUpdates/lastEntryRwy/{rwy}/{runway_in_use}/{runway_in_use_depart}/{unit_id}";
            return paramUrl;
        }

        public static string Fill_Subjects()
        {
            string paramUrl = "GetLatestUpdates/GetLatestUpdates/lastEntrySubject/{generalentry}/{description}/{id}";
            return paramUrl;
        }
        public static string Fill_Faults()
        {
            string paramUrl = "GetLatestUpdates/GetLatestUpdates/TotalOpenFaults/{initial}";
            return paramUrl;
        }
        public static string Fill_Grid()
        {
            string paramUrl = "GetLatestUpdates/ElogSearch/elog_search/{limit}/{offset}";
            return paramUrl;
        }

        public static bool IsValid(string value)
        {
            if (value.Length < 1 || String.IsNullOrEmpty(value) || value.Equals("Select"))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        // Insert query Rwy(overloaded method)
        public static MySqlCommand Insert(string query, string Runway_in_use, string Runway_in_use_depart, int Unit_id, 
                                          string Subject, string datetime, string Initial, string Onbehalf, string Description)
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
                    cmd.Parameters.AddWithValue("@runway_in_use", Runway_in_use);
                    cmd.Parameters.AddWithValue("@runway_in_use_depart", Runway_in_use_depart);
                    cmd.Parameters.AddWithValue("@unit_id", Unit_id);
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

        // Insert query MET(overloaded method)
        public static MySqlCommand Insert(string query, string Subject, string datetime, string Initial, string Unit_id, string Condition)
        {
            //MessageBox.Show(Condition);
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@subject", Subject);
                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@Initial", Initial);
                    cmd.Parameters.AddWithValue("@unit_id", Unit_id);
                    cmd.Parameters.AddWithValue("@condition", Condition);
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

        // Insert query Gen(overloaded method)
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

        // Insert query Fal(overloaded method)
        public static MySqlCommand Insert(string query, string Subject, string datetime, string Initial,
                                         string Onbehalf, string Description, string Position_name, string Console_number,
                                         string System_equipment, string Error_text, int Roci,
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
                    cmd.Parameters.AddWithValue("@position_name", Position_name);
                    cmd.Parameters.AddWithValue("@console_number", Console_number);
                    cmd.Parameters.AddWithValue("@system_equipment", System_equipment);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@datetime", datetime);
                    cmd.Parameters.AddWithValue("@roci", Roci);
                    cmd.Parameters.AddWithValue("@error_text", Error_text);
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
        
        public static MySqlCommand insertAccesslog(string query, string agentcode, string message, long form_log_id, string log_datetime, string unit_id)
        {
            ;
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@agentcode", agentcode);
                    cmd.Parameters.AddWithValue("@log_datetime", log_datetime);
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@unit_id", unit_id);
                    cmd.Parameters.AddWithValue("@form_log_id", form_log_id);
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
