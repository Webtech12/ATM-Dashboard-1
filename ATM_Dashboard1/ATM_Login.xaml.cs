using ATM_Dashboard1.DA_Layer;
using ATM_Dashboard1.helper;
using ATM_Dashboard1.PD_Layer;
using System;
using System.Windows;

namespace ATM_Dashboard1
{
    /// <summary>
    /// Interaction logic for ATM_Login.xaml
    /// </summary>
    public partial class ATM_Login : Window
    {
        public ATM_Login()
        {
            InitializeComponent();
            DBhelper.EstablishConn();
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string username = txtname.Text;
            string password = txtpass.Password;
            
            if (username.Length < 1 || password.Length < 1)
            {
                MessageBox.Show("Fill all fields!");
            }
            else
            {
                try
                {
                    Users aUser = UsersDA.RetrieveUser(username);

                    if (aUser.Password.Equals(password))
                    {
                        MessageBox.Show("Login Success");
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed. Please try again");
                        txtname.Text = "";
                        txtpass.Password = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Username not found ");
                }
               
            }

        }
    }
}
