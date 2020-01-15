using ATM_Dashboard1.modals;
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
