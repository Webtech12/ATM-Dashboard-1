using System.Windows;

namespace ATM_Dashboard1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aman_modal(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("works");
        }

        private void wt_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("works");
        }

        private void dpo_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        private void dw_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        
        private void watch_view(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("this");
        }

        private void fault_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        
        private void gen_modal(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void rosi(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
        
        private void epl(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
