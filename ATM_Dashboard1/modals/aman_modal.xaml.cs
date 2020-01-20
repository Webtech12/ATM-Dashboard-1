using ATM_Dashboard1.DA_Layer;
using ATM_Dashboard1.helper;
using ATM_Dashboard1.PD_Layer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ATM_Dashboard1
{
    /// <summary>
    /// Interaction logic for aman_modal.xaml
    /// </summary>
    /// 

    public partial class aman_modal : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public aman_modal()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy'-'MM'-'dd";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
            txinitial.Text = DBhelper.credsUser;
            FillOnbehalf();
            FillSubjects();
            FillRate();
           // GetClosetime();
        }

        void FillOnbehalf()
        {
            var users =  DBhelper.GetUnitUsers();
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
        void FillSubjects()
        {
            var subjects =  DBhelper.GetSubjects();
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
                    userSubjects = dr["subject"].ToString();
                    userSubjectId = dr["id"].ToString();
                    subject.Items.Add(userSubjects);
                }
            }
        }
        void FillRate()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 40);
            foreach (int n in numbers)
            {
                rate.Items.Add(n);
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
        public string GetSubjectId()
        {
                var SubId = DBhelper.GetQuery("subjectform", "id", "subject", subject.Text);
                cmd = DBhelper.GetRelation(SubId);
                string sId = null;
                if (cmd != null)
                {
                    dt = new DataTable();
                    sda = new MySqlDataAdapter(cmd);
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        sId = dr["id"].ToString();
                    }
                }
                return sId;
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
            }if (status.Text == "Follow-Up")
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

        private void aman_submit(object sender, RoutedEventArgs e)
        {
            try
            {
                var datetime = txtdate.SelectedDate.Value.Date.ToShortDateString().ToString() + " " + txttime.SelectedTime.Value.ToLongTimeString().ToString();
                var Initial = GetInitials();
                var Onbehalf = GetOnbehalf();
                var Subject = GetSubjectId();
                var Status = GetStatus();
                var Ari_kpi = GetARR();
                var Dep_kpi = GetDEP();
                var Dans = GetDans();
                var closed_at = close_time.Text;
                var Description = rate.Text + " " + des.Text;
                var Roci = Convert.ToInt32(roci.Text);
                

                string insertQuery = "INSERT INTO atmars_testdb.generalentry(initial,onbehalf,subject,description,datetime,frn,frnstatus,actions,management,ate,roci,status,ari_kpi,dep_kpi,dans,updated,form_id,closed_at) " +
                    "VALUES(@Initial,@Onbehalf,@Subject,@Description,@datetime,'','','','','',@Roci,@Status,@Ari_kpi,@Dep_kpi,@Dans,'','',@closed_at)";
                cmd = DBhelper.Insert(insertQuery, Initial, Onbehalf, Subject, Description, datetime, Roci, Status, Ari_kpi, Dep_kpi, Dans, closed_at);
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

                    string log_type = "generalentry";
                    string log_table = "generalentry";
                    string message = "Inserted Generalentry Log";

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
