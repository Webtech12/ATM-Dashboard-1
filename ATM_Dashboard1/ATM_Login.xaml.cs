using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Welocme: {txtname.Text} with password {txtpass.Password}");
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
        }
    }
}
