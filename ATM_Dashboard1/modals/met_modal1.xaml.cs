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
    /// Interaction logic for met_modal1.xaml
    /// </summary>
    public partial class met_modal1 : Window
    {
        string met;
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        public met_modal1()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "yyyy'-'MM'-'dd";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
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

        private void met_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!DBhelper.IsValid(met))
                {
                    MessageBox.Show("Fill the required field");
                    return;
                }
                else
                {

                    var datetime = txtdate.SelectedDate.Value.Date.ToShortDateString().ToString() + " " + txttime.SelectedTime.Value.ToLongTimeString().ToString();
                    var Initial = GetInitials();
                    var Subject = "MET Condition";
                    var Unit_id = Convert.ToString(14);
                    var Condition = met;

                    string insertQuery = "INSERT INTO atmars_testdb.met_condition(`subject`, `datetime`, `initial`, `unit_id`, `condition`, `no_runway`, `actions`, `management`, `ate`, `roci`) " +
                        "VALUES(@Subject,@datetime,@Initial,@Unit_id,@Condition,'','','','','')";
                    cmd = DBhelper.Insert(insertQuery, Subject, datetime, Initial, Unit_id, Condition);
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
                        string log_table = "met_condition";
                        string message = "Inserted MET Condition.";

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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            met = "VMC";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            met = "IMC";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            met = "LVP";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            met = "LVS";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            met = "LVO";
        }

    }
}
