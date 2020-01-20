using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Dashboard1.PD_Layer
{
    public class LoggedInUser
    {
        private string unit;
        private string initial;
        private string uname;

        public LoggedInUser(string uname,string unit, string initial)
        {
            LoggedUser = uname;
            LoggedUnit = unit;
            LoggedInitial = initial;
        }

        public String LoggedUser
        {
            get { return uname; }
            set { uname = value; }
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
