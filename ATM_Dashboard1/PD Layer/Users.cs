using System;

namespace ATM_Dashboard1.PD_Layer
{
    public class Users
    {
        private string username;
        private string password;
        private string unit;
        private string initial;

        public Users(string username, string password, string unit, string initial)
        {
            UserName = username;
            Password = password;
            LoggedUnit = unit;
            LoggedInitial = initial;
        }

        public String UserName
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String LoggedUnit
        {
            get { return unit; }
            set { unit = value; }
        }
        public String LoggedInitial
        {
            get { return initial; }
            set { initial = value; }
        }
    }
}
