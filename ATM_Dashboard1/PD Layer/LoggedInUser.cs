using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Dashboard1.PD_Layer
{
    public class LoggedInUser
    {
        private string loggedUser;
        public LoggedInUser(string Uname)
        {
            loggedUser = Uname;
        }

        public string LoggedUser
        {
            get { return loggedUser; }
            set {
                loggedUser = value;
            }
        }


    }
}
