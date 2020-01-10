using ATM_Dashboard1.helper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace ATM_Dashboard1.modals
{
    /// <summary>
    /// Interaction logic for dapo_modal.xaml
    /// </summary>
    public partial class dapo_modal : Window
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public dapo_modal()
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
        }

        void FillOnbehalf()
        {
            var users = DBhelper.GetUnitUsers();
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
            var subjects = DBhelper.GetSubjects();
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


    }

}
