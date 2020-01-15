using ATM_Dashboard1.helper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ATM_Dashboard1.modals
{
    /// <summary>
    /// Interaction logic for fault_modal.xaml
    /// </summary>
    public partial class fault_modal : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public fault_modal()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy'-'MM'-'dd";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
            FillOnbehalf();
            FillPositions();
            FillConsoleNumber();
            Fillsystem_equipment();
        }


        void FillPositions()
        {
            var subjects = DBhelper.GetDatas("positionname");
            cmd = DBhelper.GetRelation(subjects);
            string userSubjects = null;
            string userSubjectId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    userSubjects = dr["name"].ToString();
                    userSubjectId = dr["id"].ToString();
                    position.Items.Add(userSubjects);
                }
            }
        }
        void FillConsoleNumber()
        {
            var subjects = DBhelper.GetDatas("consolenumber");
            cmd = DBhelper.GetRelation(subjects);
            string userSubjects = null;
            string userSubjectId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    userSubjects = dr["name"].ToString();
                    userSubjectId = dr["id"].ToString();
                    console.Items.Add(userSubjects);
                }
            }
        }
        void Fillsystem_equipment()
        {
            var subjects = DBhelper.GetDatas("system_equipment");
            cmd = DBhelper.GetRelation(subjects);
            string userSubjects = null;
            string userSubjectId = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    userSubjects = dr["name"].ToString();
                    userSubjectId = dr["id"].ToString();
                    equipment.Items.Add(userSubjects);
                }
            }
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
        public string GetStatus()
        {
            if (status.Text == "Open")
            {
                //close_time.Visibility = Visibility.Hidden;
                status.Text = "1";
            }
            if (status.Text == "Close")
            {
                status.Text = "0";
            }
            if (status.Text == "Follow-Up")
            {
                status.Text = "2";
            }
            return status.Text;
        }

        public string GetARR()
        {
            if (arr.IsChecked.HasValue && arr.IsChecked.Value)
            {
                arr.IsChecked = false;
                arr.Name = "on";
            }
            else
            {
                arr.Name = "";
            }
            return arr.Name;
        }
        public string GetDEP()
        {
            if (dep.IsChecked.HasValue && dep.IsChecked.Value)
            {
                dep.IsChecked = false;
                dep.Name = "on";
            }
            else
            {
                dep.Name = "";
            }
            return dep.Name;
        }
        public string GetDans()
        {
            if (dans.IsChecked.HasValue && dans.IsChecked.Value)
            {
                dans.IsChecked = false;
                dans.Name = "on";
            }
            else
            {
                dans.Name = "";
            }
            return dans.Name;
        }

        private void fault_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!DBhelper.IsValid(position.Text) || !DBhelper.IsValid(errtxt.Text))
                {
                    MessageBox.Show("Fill the required field");
                    return;
                }
                else
                {
               
                var datetime = txtdate.SelectedDate.Value.Date.ToShortDateString().ToString() + " " + txttime.SelectedTime.Value.ToLongTimeString().ToString();
                var Initial = GetInitials();
                var Onbehalf = GetOnbehalf();
                var Subject = "Fault Reporting";
                var Position_name = position.Text;
                var Console_number = console.Text;
                var System_equipment = equipment.Text;
                var Error_text = errtxt.Text;
                var Status = GetStatus();
                var Ari_kpi = GetARR();
                var Dep_kpi = GetDEP();
                var Dans = GetDans();
                var closed_at = close_time.Text;
                var Description = des.Text;
                var Roci = Convert.ToInt32(roci.Text);

                string insertQuery = "INSERT INTO atmars_testdb.fault_reporting(subject, datetime, initial, " +
                    "onbehalf, actions, management, " +
                    "ate, any_other_details, position_name, " +
                    "console_number, system_equipment, purpose_of_release, " +
                    "form_datetime, frn, frnstatus, " +
                    "frn_update_time, error_text, faultNum, " +
                    "action_perfomed, Remarks, sendbckdetail, " +
                    "readed, roci, status, " +
                    "ari_kpi, dep_kpi, dans, closed_at) " +

                  "VALUES(@Subject, @datetime, @Initial, @Onbehalf, '', '', " +
                  "'', @Description, @Position_name, @Console_number, @System_equipment, " +
                  "'', '', '', '', '', " +
                  "@Error_text, '', '', '', '', " +
                  "'', @Roci, @Status, @Ari_kpi, @Dep_kpi, @Dans, @closed_at)";
                cmd = DBhelper.Insert(insertQuery, Subject, datetime, Initial, Onbehalf, Description, Position_name, Console_number, System_equipment, Error_text, Roci, Status, Ari_kpi, Dep_kpi, Dans, closed_at);
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
                    string log_table = "fault_reporting";
                    string message = "Inserted Fault Reporting.";

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
            }
            catch (Exception ex)
            {

                MessageBox.Show("Fill in all the fields \n" + ex.Message);
            }
        }

        private void status_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                string statusSelect = (e.AddedItems[0] as ComboBoxItem).Content as string;
                if (statusSelect == "Close")
                {
                    close_time.Visibility = Visibility.Visible;
                }
                else
                {
                    close_time.Visibility = Visibility.Hidden;
                    close_time.Text = "";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

       
    }
}
