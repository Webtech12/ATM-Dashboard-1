using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Dashboard1.Model
{
    public class ElogJsonRootObject
    {
        public int Id { get; set; }
        public string Log_table { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Management_comments { get; set; }
        public string Ate_comments { get; set; }
        public string Unit_comments { get; set; }
        public int Roci { get; set; }
        public string Status { get; set; }
        public string Initial { get; set; }

    }
}
