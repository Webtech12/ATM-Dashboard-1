using ATM_Dashboard1.helper;
using ATM_Dashboard1.modals;
using ATM_Dashboard1.Model;
using MySql.Data.MySqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace ATM_Dashboard1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;
        private string Url = "http://localhost/atlog_api_new/api/";
        public MainWindow()
        {
            InitializeComponent();
            Json_Deserialize();
            //Fillomdm_met();

        }


        public void Json_Deserialize()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(UpdatedMet);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();

        }

    private void UpdatedMet(object sender, EventArgs e)
        {
            int[] units = new int[5] { 5, 6, 7, 13, 14 };
            try
            {
                var client = new RestClient();
                
                foreach (int unit_id in units)
                {
                    var request = new RestRequest(Url + DBhelper.Fill_met());
                    request.AddUrlSegment("met_condition", "met_condition");
                    request.AddUrlSegment("condition", "condition");
                    request.AddUrlSegment("unit_id", unit_id);
                
                    request.AddHeader("Accept", "application/json");
                    IRestResponse<List<METJsonRootObject>> response = client.Get<List<METJsonRootObject>>(request);

                    if (response.IsSuccessful)
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                        Console.WriteLine("Content " + response.Content);
                        Console.WriteLine("Size of List " + response.Data.Count);
                        Console.WriteLine("ID  " + response.Data[0].Condition);
                        if (unit_id == 13)
                        {
                            omsj_met.Text = response.Data[0].Condition.ToUpper();
                        }
                        if (unit_id == 14)
                        {
                            omdm_met.Text = response.Data[0].Condition.ToUpper();
                        }
                        if (unit_id == 5)
                        {
                            omdb_met.Text = response.Data[0].Condition.ToUpper();
                        }
                        if (unit_id == 6)
                        {
                            omdw_met.Text = response.Data[0].Condition.ToUpper();
                        }
                        if (unit_id == 7)
                        {
                            efta_met.Text = response.Data[0].Condition.ToUpper();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                        omsj_met.Text = "VMC";
                        omdm_met.Text = "VMC";
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("There might be some problem while updating the mets" + ex.Message);
            }
            
        }

        private void aman_modal(object sender, RoutedEventArgs e)
        {
            aman_modal aman = new aman_modal();
            aman.Show();
        }

        private void wt_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            wt_modal wtmodal = new wt_modal();
            wtmodal.Show();
        }

        private void dpo_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            dapo_modal dapo = new dapo_modal();
            dapo.Show();
        }
        private void dw_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            down_modal downwind = new down_modal();
            downwind.Show();
        }
        
        private void watch_view(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("this");
        }

        private void fault_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            fault_modal fault = new fault_modal();
            fault.Show();
        }
        
        private void gen_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gen_modal general = new gen_modal();
            general.Show();
        }
        private void omsj_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rwy_modal  omsj = new rwy_modal();
            omsj.Show();
        }
        
        private void omdm_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            rwy_modal1 omdm = new rwy_modal1();
            omdm.Show();
        }
        
        private void met_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            met_modal met = new met_modal();
            met.Show();
        }
        
        private void met1_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            met_modal1 met1 = new met_modal1();
            met1.Show();
        }

        private void rosi(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        
        private void epl(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
