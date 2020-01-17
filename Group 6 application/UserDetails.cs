using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    public class UserDetails
    {
        private static int userIdSeeder = 0;
        private int userId;
        private string username;
        private string password;
        private int Strike;
        private List<Tasks> usertasks;
        private List<string> notifications;


        public UserDetails(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.usertasks = new List<Tasks>();
            this.Strike = 0;
            this.userId = userIdSeeder;
            this.notifications = new List<string>();
            userIdSeeder++;
        }

        public void Assigntask(Tasks t)
        {
            usertasks.Add(t);
        }

        public void Strikeuser()
        {
            ++Strike;
        }

        public void Addnotification(string Warning)
        {
            notifications.Add(Warning);
        }

        public void deletnotiflist()
        {
            notifications.Clear();
        }

        public List<string> Displaynotif()
        {
            return notifications;
        }

        public void RemoveTask(Tasks t)
        {
            usertasks.Remove(t);
        }
        public void DeletePtasks()
        {
            usertasks.Clear();
        }

        public List<Tasks> DisplayPersonalTasks()
        {
            return usertasks;
        }

        public string ShowUserDetails()
        {
            return userId + " - " + username + "  " + password + " Strikes: " + Strike.ToString();
        }

        public string ShowlogedUser()
        {
            return "Welcome " + username;
        }

        public string ShowUsername()
        {
            return username;
        }
        public string ShowPassword()
        {
            return password;
        }
    }
}
