using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    public class Tasks
    {
        private string user;
        private string tasks;
        public int day { get; private set; }
        public int month { get; private set; }

        public Tasks(string user ,string tasks, int day,int month)
        {
            this.user = user;
            this.tasks = tasks;
            this.month = month;
            this.day = day;
        }

        public string gettask()
        {
            return tasks;
        }

        public string GetUser()
        {
            return user;
        }

        public string GetTaskinfo()
        {
            return $"{this.day}/t {this.tasks} /t assigned to {this.user}";
        }
    }
}
