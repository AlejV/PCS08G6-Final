using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    class Events
    {
        private string subject;
        private string description;
        private string date;

        public Events(string subject, string description,string date)
        {
            this.subject = subject;
            this.description = description;
            this.date = date;
        }
    }
}
