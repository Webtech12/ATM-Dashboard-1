using ATM_Dashboard1.helper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
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

        public aman_modal()
        {
            InitializeComponent();
            CultureInfo ci = new CultureInfo(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd'/'MM'/'yyyy";
            ci.DateTimeFormat.LongTimePattern = "hh':'mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            DBhelper.EstablishConn();
        }

        private void aman_submit(object sender, RoutedEventArgs e)
        {
            try
            {
                var datetime = txtdate.SelectedDate.Value.Date.ToShortDateString().ToString() + " " + txttime.SelectedTime.Value.ToLongTimeString().ToString();
                string insertQuery = "INSERT INTO atmars_testdb.generalentry(initial,onbehalf,subject,description," +
                    "datetime,frn,frnstatus,actions,management,ate," +
                    "roci,status,ari_kpi,dep_kpi,dans,updated,form_id,closed_at)" +
                    " VALUES('" + txinitial.Text + "','" + txtOnbehalf.Text + "'," + txtsubject.Text + "'," + txtrate.Text + " " + txdesc.Text + "" +
                    "'," + datetime + "'," + null + "'," + null + "'," + null + "'," + null + "'," + null + "" +
                    "'," + txtrosi.Text + "'," + txtstatus.Text + "'," + null + "'," + null + "'," + null + "" +
                    "'," + null + "'," + null + "'," + null + ")";

                cmd = DBhelper.RunQuery(insertQuery, txinitial.Text);
                if (cmd != null)
                {
                    MessageBox.Show("Data Inserted");
                }
                else
                {
                    MessageBox.Show("Data Not Inserted");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill in all the fields \n" + ex.Message);
            }
           
            

        }
    }
}
