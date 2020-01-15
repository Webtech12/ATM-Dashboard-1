using ATM_Dashboard1.helper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace ATM_Dashboard1.modals
{
    /// <summary>
    /// Interaction logic for rwy_modal1.xaml
    /// </summary>
    public partial class rwy_modal1 : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public rwy_modal1()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy'-'MM'-'dd";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
            FillOnbehalf();
        }

        void FillOnbehalf()
        {
            var users = DBhelper.GetUnitUsers();
            cmd = DBhelper.GetRelation(users);
            string agents = null;
            string agentcodes = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    agents = dr["agentname"].ToString();
                    agentcodes = dr["agentcode"].ToString();
                    Onbehalf.Items.Add(agents);
                }
            }
        }
        public string GetInitials()
        {
            var Initial = DBhelper.GetQuery("tblagent", "agentcode", "agentname", txinitial.Text);
            cmd = DBhelper.GetRelation(Initial);
            string uId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    uId = dr["agentcode"].ToString();
                }
            }
            return uId;
        }
        public string GetOnbehalf()
        {
            var Initial = DBhelper.GetQuery("tblagent", "agentcode", "agentname", Onbehalf.Text);
            cmd = DBhelper.GetRelation(Initial);
            string uId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    uId = dr["agentcode"].ToString();
                }
            }
            return uId;
        }

        public string Getarrival()
        {
            var Unit_id = 14;
            var Initial = DBhelper.GetQueryRWY("runway", "runway_id", "runway", arrival.Text, Unit_id);
            cmd = DBhelper.GetRelation(Initial);
            string uId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    uId = dr["runway_id"].ToString();
                }
            }
            return uId;
        }
        public string Getdeparture()
        {
            var Unit_id = 14;
            var Initial = DBhelper.GetQueryRWY("runway", "runway_id", "runway", departure.Text, Unit_id);
            cmd = DBhelper.GetRelation(Initial);
            string uId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    uId = dr["runway_id"].ToString();
                }
            }
            return uId;
        }

        private void rwy1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var datetime = txtdate.SelectedDate.Value.Date.ToShortDateString().ToString() + " " + txttime.SelectedTime.Value.ToLongTimeString().ToString();
                var Initial = GetInitials();
                var Onbehalf = GetOnbehalf();
                var Description = des.Text;
                var Subject = "Runway In Use";
                var Unit_id = 14;
                var Runway_in_use = Getarrival();
                var Runway_in_use_depart = Getdeparture();

                string insertQuery = "INSERT INTO atmars_testdb.rwy(runway_in_use, runway_in_use_depart, unit_id, subject, datetime, initial, onbehalf, description) " +
                  "VALUES(@Runway_in_use,@Runway_in_use_depart,@Unit_id,@Subject,@datetime,@Initial,@Onbehalf,@Description)";
                cmd = DBhelper.Insert(insertQuery, Runway_in_use, Runway_in_use_depart, Unit_id, Subject, datetime, Initial, Onbehalf, Description);
                long log_id = cmd.LastInsertedId;

                if (cmd != null)
                {
                    var Units = DBhelper.getAgentUnits(int.Parse(Initial));
                    cmd = DBhelper.GetRelation(Units);

                    string unit_id = null;
                    if (cmd != null)
                    {
                        dt = new DataTable();
                        sda = new MySqlDataAdapter(cmd);
                        sda.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            unit_id = dr["agentunit"].ToString();
                        }
                    }

                    string log_type = Subject;
                    string log_table = "rwy";
                    string message = "Inserted Runway In Use.";

                    string insertFormlog = "INSERT INTO atmars_testdb.form_logs(log_type,log_table,log_id,datetime, unit_id) " +
                        "VALUES(@log_type,@log_table,@log_id,@datetime,@unit_id)";
                    cmd = DBhelper.insertLog(insertFormlog, log_id, datetime, unit_id, log_type, log_table);
                    long form_log_id = cmd.LastInsertedId;

                    if (cmd != null)
                    {
                        string agentcode = Initial;
                        string log_datetime = datetime;
                        string insertAccesslog = "INSERT INTO atmars_testdb.access_logs(agentcode,message,form_log_id,log_datetime, unit_id) " +
                        "VALUES(@agentcode,@message,@form_log_id,@log_datetime,@unit_id)";
                        cmd = DBhelper.insertAccesslog(insertAccesslog, Initial, message, form_log_id, log_datetime, unit_id);
                    }

                    MessageBox.Show("Insertion successful");
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("Insertion error");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Fill in all the fields \n" + ex.Message);
            }
        }
    }
}
