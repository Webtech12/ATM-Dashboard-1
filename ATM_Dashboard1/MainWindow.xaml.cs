﻿using ATM_Dashboard1.helper;
using ATM_Dashboard1.modals;
using ATM_Dashboard1.Model;
using MySql.Data.MySqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
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
            DBhelper.EstablishConn();
            //Json_Deserialize();
            ElogGrid();

        }

        // Code For Calling All The Update Functions With Timer
        public void Json_Deserialize()
        {
             DispatcherTimer dispatcherTimer = new DispatcherTimer();
             dispatcherTimer.Tick += new EventHandler(UpdatedSubjects);
             dispatcherTimer.Tick += new EventHandler(UpdatedMet);
             dispatcherTimer.Tick += new EventHandler(UpdatedFaults);
             dispatcherTimer.Tick += new EventHandler(UpdatedRwy);
             //dispatcherTimer.Tick += new EventHandler(ElogGrid);
             dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
             dispatcherTimer.Start();

        }

        


        // Elog Grid View
        private void ElogGrid()
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest(Url + DBhelper.Fill_Grid());
                request.AddHeader("Accept", "application/json");
                IRestResponse<List<ElogJsonRootObject>> response = client.Get<List<ElogJsonRootObject>>(request);
                //var response = GetRestResponseAsync<List<ElogJsonRootObject>>(client, request).GetAwaiter().GetResult();

                if (response.IsSuccessful)
                {
                    Console.WriteLine("Status Code " + response.StatusCode);
                    Console.WriteLine("Content " + response.Content);
                    Console.WriteLine("Size of List " + response.Data.Count);
                    Console.WriteLine("ID  " + response.Data[0].Id);
                    List<ElogJsonRootObject> items = new List<ElogJsonRootObject>();
                    for (int i = 0; i < response.Data.Count; ++i)
                    {
                        items.Add(new ElogJsonRootObject()
                        {
                            Subject = response.Data[i].Subject.ToString(),
                            Description = response.Data[i].Description.ToString(),
                            Unit_comments = response.Data[i].Unit_comments.ToString(),
                            Management_comments = response.Data[i].Management_comments.ToString(),
                            Ate_comments = response.Data[i].Ate_comments.ToString(),
                            Initial = response.Data[i].Initial.ToString(),
                            Date = response.Data[i].Date.ToString(),
                            Time = response.Data[i].Time.ToString()

                        });

                        elog_grid.ItemsSource = items;
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There might be some problem while updating the Elog " + ex.Message);
            }
        }


        // Elog Grid View Async
        private async Task<IRestResponse<T>> GetRestResponseAsync<T>(RestClient client, IRestRequest request) where T : class, new()
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            client.ExecuteAsync<T>(request, response =>
            {
                if (response.ErrorException != null)
                {
                    const string message = "Error during fetching...";
                    throw new ApplicationException(message, response.ErrorException);
                }
                taskCompletionSource.SetResult(response);
            });

            return await taskCompletionSource.Task;
        }

        // Update Dashboard Interval Code
        private void UpdatedFaults(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest(Url + DBhelper.Fill_Faults());
                request.AddUrlSegment("initial", DBhelper.credsInitial);
                request.AddHeader("Accept", "application/json");
                IRestResponse<List<FaultJsonRootObject>> response = client.Get<List<FaultJsonRootObject>>(request);

                if (response.IsSuccessful)
                {
                    Console.WriteLine("Status Code " + response.StatusCode);
                    Console.WriteLine("Content " + response.Content);
                    Console.WriteLine("Size of List " + response.Data.Count);
                    Console.WriteLine("ID  " + response.Data[0].Id);

                    fault_val.Text = response.Data[0].Id.ToString();
                }
                else
                {
                    Console.WriteLine("Status Code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There might be some problem while updating the faults" + ex.Message);
            }
        }

        private void UpdatedRwy(object sender, EventArgs e)
        {
            int[] units = new int[5] { 5, 6, 7, 13, 14 };
            try
            {
                var client = new RestClient();

                foreach (int unit_id in units)
                {
                    var request = new RestRequest(Url + DBhelper.Fill_rwy());
                    request.AddUrlSegment("rwy", "rwy");
                    request.AddUrlSegment("runway_in_use", "runway_in_use");
                    request.AddUrlSegment("runway_in_use_depart", "runway_in_use_depart");
                    request.AddUrlSegment("unit_id", unit_id);

                    request.AddHeader("Accept", "application/json");
                    IRestResponse<List<RWYJsonRootObject>> response = client.Get<List<RWYJsonRootObject>>(request);

                    if (response.IsSuccessful)
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                        Console.WriteLine("Content " + response.Content);
                        Console.WriteLine("Size of List " + response.Data.Count);
                        Console.WriteLine("Runway_in_use  " + response.Data[0].Runway_in_use);
                        Console.WriteLine("Runway_in_use_depart  " + response.Data[0].Runway_in_use_depart);

                        if (unit_id == 5)
                        {
                            var arrival = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use);
                            omdb_rwy_arr.Text = arrival;
                            var departure = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use_depart);
                            omdb_rwy_dep.Text = departure;
                        } 
                        if (unit_id == 13)
                        {
                            var arrival = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use);
                            omsj_rwy_arr.Text = arrival;
                            var departure = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use_depart);
                            omsj_rwy_dep.Text = departure;
                        }
                        if (unit_id == 14)
                        {
                            var arrival = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use);
                            omdm_rwy_arr.Text = arrival;
                            var departure = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use_depart);
                            omdm_rwy_dep.Text = departure;
                        }
                        if (unit_id == 6)
                        {
                            var arrival = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use);
                            omdw_rwy_arr.Text = arrival;
                            var departure = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use_depart);
                            omdw_rwy_dep.Text = departure;
                        }
                        if (unit_id == 7)
                        {
                            var arrival = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use);
                            efta_rwy_arr.Text = arrival;
                            var departure = DBhelper.GetQueryRwy("runway", "runway", "runway_id", response.Data[0].Runway_in_use_depart);
                            efta_rwy_dep.Text = departure;
                        } 

                    }
                    else
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There might be some problem while updating the Runways " + ex.Message);
            }

        }

        private void UpdatedSubjects(object sender, EventArgs e)
        {
            try
            {
                int[] subjects = new int[4] { 1, 79, 161, 162 };
                foreach (int subjects_id in subjects)
                {
                    var client = new RestClient();

                    var request = new RestRequest(Url + DBhelper.Fill_Subjects());
                    request.AddUrlSegment("generalentry", "generalentry");
                    request.AddUrlSegment("description", "description");
                    request.AddUrlSegment("id", subjects_id);

                    request.AddHeader("Accept", "application/json");
                    IRestResponse<List<SubjectsJsonRootObject>> response = client.Get<List<SubjectsJsonRootObject>>(request);

                    if (response.IsSuccessful)
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                        Console.WriteLine("Content " + response.Content);
                        Console.WriteLine("Size of List " + response.Data.Count);
                        Console.WriteLine("ID  " + response.Data[0].Description);
                        if (subjects_id == 1)
                        {
                            aman_val.Text = response.Data[0].Description.Substring(0, 2);
                        }
                        if (subjects_id == 79)
                        {
                            dapo_subject.Text = response.Data[0].Description;
                        }
                        if (subjects_id == 161)
                        {
                            wt_subject.Text = response.Data[0].Description;
                        }
                        if (subjects_id == 162)
                        {
                            down_subject.Text = response.Data[0].Description;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Status Code " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There might be some problem while updating the subjects " + ex.Message);
            }
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


        // Modals Pop-Up Code
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;
            MessageBox.Show(btn.Name);
        }
    }

}

