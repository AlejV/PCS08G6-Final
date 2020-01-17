using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    public class Activities
    {
        public string owner { get; private set; }
        public string subject { get; set; }
        public string description { get; set; }
        public int day { get; private set; }
        public int month { get; private set; }
        public bool isCancelled { get; set; }
        public int voteCount { get; set; }
        private Months setMonth;

        public Activities(string owner, string subject, string description, int day, int month)
        {
            this.owner = owner;
            this.subject = subject;
            this.description = description;
            this.day = day;
            this.month = month;
            this.isCancelled = false;
            this.voteCount = 0;
        }

        public string GetActivityDetails()
        {
            if (this.isCancelled)
                return $"{this.day}: \t {this.subject} \t {this.description} by {this.owner} \t cancelled";
            else
            return $"{this.day}: \t {this.subject} \t {this.description} by {this.owner}";
        }

        public string FullActivityDetails()
        {
            setMonth = (Months)(this.month - 1);
            if (this.isCancelled)
                return $"{this.day} \t {setMonth} \t {this.subject} \t {this.description} by {this.owner} \t cancelled";
            else
            return $"{this.day} \t {setMonth} \t {this.subject} \t {this.description} by {this.owner}";
        }



    }
}
