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

namespace ATM_Dashboard1
{
    /// <summary>
    /// Interaction logic for aman_modal.xaml
    /// </summary>
    public partial class aman_modal : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        //public static LoggedInUser loggedInUser;

        public aman_modal()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy'-'MM'-'dd";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
            FillOnbehalf();
            FillSubjects();
            FillRate();
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
                status.Text = "1";
            }if (status.Text == "Close")
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
                var ARR = GetARR();
                var DEP = GetDEP();
                var Dans = GetDans();
                var Desc = rate.Text + " " + des.Text;
                var Roci = Convert.ToInt32(roci.Text);
                MessageBox.Show(ARR);
                //DBhelper.EstablishConn();
                string insertQuery = "INSERT INTO atmars_testdb.generalentry(initial,onbehalf,subject,description,datetime,frn,frnstatus,actions,management,ate,roci,status,ari_kpi,dep_kpi,dans,updated,form_id,closed_at) " +
                    "VALUES(@Initial,@Onbehalf,@Subject,@Desc,@datetime,'','','','','',@Roci,@Status,@ARR,@DEP,@Dans,'','','')";
                cmd = DBhelper.Insert(insertQuery, Initial, Onbehalf, Subject, Desc, datetime, Roci, Status, ARR, DEP, Dans);
                if (cmd != null)
                {
                    MessageBox.Show(cmd.CommandText);
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
